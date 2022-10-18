using Zillifriends.Shared.Common;

namespace Zilligraph.Database.Storage.Table
{
    public class DataFile : IDisposable
    {
        private bool? _hasRows;
        private readonly object _streamLock = new();
        private FileStream? _bulkOperationFileStream;

        public DataFile(IZilligraphTable table, int fileNumber)
        {
            Table = table;
            FileNumber = fileNumber;
            FilePath = table.PathBuilder.GetFilePath($"data{fileNumber:000}.bin");
        }

        public IZilligraphTable Table { get; }

        public int FileNumber { get; }

        public string FilePath { get; }

        public bool HasRows => _hasRows ??= GetHasRows();

        public void StartBulkOperation()
        {
            _bulkOperationFileStream = File.Open(FilePath, FileMode.OpenOrCreate);
        }

        public void EndBulkOperation()
        {
            _bulkOperationFileStream?.Dispose();
            _bulkOperationFileStream = null;
        }

        public ulong Append(CompressedDataRowBinary row)
        {
            if (_bulkOperationFileStream != null)
            {
                return AppendToStream(row, _bulkOperationFileStream);
            }

            lock (_streamLock)
            {
                using (var stream = GetStream())
                {
                    return AppendToStream(row, stream);
                }
            }
        }

        private ulong AppendToStream(CompressedDataRowBinary row, FileStream fileStream)
        {
            fileStream.Seek(0, SeekOrigin.End);
            ulong recordPoint = Convert.ToUInt64(fileStream.Position + 1);
            row.WriteToStream(fileStream);
            _hasRows = true;
            return recordPoint;
        }

        public CompressedDataRowBinary? Read(ulong recordPoint)
        {
            if (_bulkOperationFileStream != null)
            {
                return ReadFromStream(recordPoint, _bulkOperationFileStream);
            }
            
            lock (_streamLock)
            {
                using (var stream = GetStream())
                {
                    return ReadFromStream(recordPoint, stream);
                }
            }
        }

        public List<CompressedDataRowBinary> Read(IEnumerable<ulong> recordPoints)
        {
            var rowBinaries = new List<CompressedDataRowBinary>();
            if (_bulkOperationFileStream != null)
            {
                foreach (var recordPoint in recordPoints)
                {
                    var row = ReadFromStream(recordPoint, _bulkOperationFileStream);
                    if (row != null)
                    {
                        rowBinaries.Add(row);
                    }
                }
            }
            else
            {
                lock (_streamLock)
                {
                    using (var stream = GetStream())
                    {
                        foreach (var recordPoint in recordPoints)
                        {
                            var row = ReadFromStream(recordPoint, stream);
                            if (row != null)
                            {
                                rowBinaries.Add(row);
                            }
                        }
                    }
                }
            }
            return rowBinaries;
        }

        private CompressedDataRowBinary? ReadFromStream(ulong recordPoint, FileStream fileStream)
        {
            try
            {
                fileStream.Seek(Convert.ToInt64(recordPoint - 1), SeekOrigin.Begin);
                var row = CompressedDataRowBinary.ReadFromStream(fileStream);
                if (row?.RowLength > 0)
                {
                    return row;
                }
            }
            catch (Exception e)
            {
                throw new RuntimeException($"Read record point {recordPoint} failed on Table {Table.TableName}", e);
            }
            return null;
        }

        public List<CompressedDataRowBinary> ReadChunked(ulong firstRecordPoint, int maxLength)
        {
            if (_bulkOperationFileStream != null)
            {
                return ReadChunkedFromStream(firstRecordPoint, maxLength, _bulkOperationFileStream);
            }

            lock (_streamLock)
            {
                using (var stream = GetStream())
                {
                    return ReadChunkedFromStream(firstRecordPoint, maxLength, stream);
                }
            }
        }

        private List<CompressedDataRowBinary> ReadChunkedFromStream(ulong firstRecordPoint, int maxLength, FileStream fileStream)
        {
            var resultList = new List<CompressedDataRowBinary>();
            fileStream.Seek(Convert.ToInt64(firstRecordPoint - 1), SeekOrigin.Begin);
            for (int i = 0; i < maxLength; i++)
            {
                try
                {
                    var row = CompressedDataRowBinary.ReadFromStream(fileStream);
                    if (row?.RowLength > 0)
                    {
                        resultList.Add(row);
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    throw new RuntimeException($"ReadChunked on firstRecordPoint {firstRecordPoint} failed on Table {Table.TableName}", e);
                }
            }
            return resultList;
        }

        public IEnumerable<CompressedDataRowBinary> AllRows()
        {
            if (!HasRows)
            {
                return Enumerable.Empty<CompressedDataRowBinary>();
            }
            return new DataFileEnumerable(this);
        }

        public IList<long> AllRowPositions()
        {
            if (!HasRows)
            {
                return new List<long>();
            }
            if (_bulkOperationFileStream != null)
            {
                return AllRowPositionsFromStream(_bulkOperationFileStream);
            }

            lock (_streamLock)
            {
                using (var stream = GetStream())
                {
                    return AllRowPositionsFromStream(stream);
                }
            }
        }

        private IList<long> AllRowPositionsFromStream(FileStream fileStream)
        {
            var result = new List<long>();
            try
            {
                fileStream.Position = 0;
                while (fileStream.Position < fileStream.Length - 5)
                {
                    result.Add(fileStream.Position);
                    var lengthBuffer = new byte[4];
                    _ = fileStream.Read(lengthBuffer, 0, 4);
                    var rowLength = Convert.ToInt32(BitConverter.ToUInt32(lengthBuffer));
                    fileStream.Seek(rowLength, SeekOrigin.Current);
                }
            }
            catch (EndOfStreamException)
            {
                // end of stream
            }

            return result;
        }

        public void Dispose()
        {
            lock (_streamLock)
            {
                // just wait to unlock
            }
        }

        private bool GetHasRows()
        {
            var fileInfo = new FileInfo(FilePath);
            return fileInfo.Exists && fileInfo.Length > 0;
        }

        private FileStream GetStream()
        {
            return File.Open(FilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
        }
    }
}
