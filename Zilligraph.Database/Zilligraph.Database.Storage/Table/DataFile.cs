using Zillifriends.Shared.Common;

namespace Zilligraph.Database.Storage.Table
{
    public class DataFile : IDisposable
    {
        private bool? _hasRows;
        private object _streamLock = new();

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

        public ulong Append(DataRowBinary row)
        {
            lock (_streamLock)
            {
                using (var stream = GetStream())
                {
                    stream.Seek(0, SeekOrigin.End);
                    ulong recordPoint = Convert.ToUInt64(stream.Position + 1);
                    row.WriteToStream(stream);
                    _hasRows = true;
                    return recordPoint;
                }
            }
        }

        public DataRowBinary? Read(ulong recordPoint)
        {
            lock (_streamLock)
            {
                try
                {
                    using (var stream = GetStream())
                    {
                        stream.Seek(Convert.ToInt64(recordPoint - 1), SeekOrigin.Begin);
                        var row = DataRowBinary.ReadFromStream(stream);
                        if (row.RowLength > 0)
                        {
                            return row;
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new RuntimeException($"Read record point {recordPoint} failed on Table {Table.TableName}", e);
                }
            }

            return null;
        }

        public IEnumerable<DataRowBinary> AllRows()
        {
            if (!HasRows)
            {
                return Enumerable.Empty<DataRowBinary>();
            }
            return new DataFileEnumerable(this);
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
