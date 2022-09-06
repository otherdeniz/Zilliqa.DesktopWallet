using System.Diagnostics;
using Zillifriends.Shared.Common;

namespace Zilligraph.Database.Storage.Index
{
    public class IndexContentFile
    {
        private static readonly int _enumerationChunkSize = 250;
        private readonly int _hashBytesLength;
        private readonly string _filePath;
        private readonly object _fileLock = new();
        private readonly byte[] _lastRecordPointer = BitConverter.GetBytes((ulong)0);
        private FileStream? _bulkInsertFileStream;

        public IndexContentFile(ZilligraphTableIndexBase tableFieldIndex, int hashBytesLength)
        {
            _hashBytesLength = hashBytesLength;
            TableFieldIndex = tableFieldIndex;
            _filePath = tableFieldIndex.PathBuilder.GetFilePath($"{tableFieldIndex.Name}_content.bin");
        }

        public ZilligraphTableIndexBase TableFieldIndex { get; }

        public ulong CreateChain(byte[] indexHash, ulong recordPoint)
        {
            if (indexHash.Length != _hashBytesLength) throw new RuntimeException("index hash length mismatch");
            if (_bulkInsertFileStream != null)
            {
                return Convert.ToUInt32(AppendToStream(_bulkInsertFileStream, indexHash, recordPoint) + 1);
            }
            lock (_fileLock)
            {
                using (var fileStream = File.Open(_filePath, FileMode.OpenOrCreate))
                {
                    return Convert.ToUInt32(AppendToStream(fileStream, indexHash, recordPoint) + 1);
                }
            }
        }

        public void RemoveChain(ulong chainEntryPoint, IndexHeadSingleFile indexHeadFile)
        {
            //TODO: still buggy , fix it !
            var removeIndexes = ReadIndexesChunkt(chainEntryPoint);
            if (removeIndexes.Count == 0) return;
            var removeIndexesHashed = removeIndexes.Select(r => r.EntryPoint).ToHashSet();
            var chainEntryIndexPointers = indexHeadFile.IndexPointers;
            var chainEntriesDict = new Dictionary<ulong, int>();
            for (int i = 0; i < chainEntryIndexPointers.Length; i++)
            {
                if (chainEntryIndexPointers[i] > 0 && chainEntryIndexPointers[i] < ulong.MaxValue)
                {
                    chainEntriesDict.Add(chainEntryIndexPointers[i], i);
                }
            }
            lock (_fileLock)
            {
                var tempFilePath = Path.ChangeExtension(_filePath, ".tmp");
                using (var sourceFileStream = File.Open(_filePath, FileMode.Open))
                {
                    using (var targetFileStream = File.Open(tempFilePath, FileMode.Create))
                    {
                        long truncateSize = 0;
                        var hashBuffer = new byte[_hashBytesLength];
                        var recordPointBuffer = new byte[8];
                        var nextPositionBuffer = new byte[8];
                        while (sourceFileStream.Position < sourceFileStream.Length)
                        {
                            var currentEntryPoint = Convert.ToUInt64(sourceFileStream.Position + 1);
                            if (truncateSize > 0 && chainEntriesDict.TryGetValue(currentEntryPoint, out var headIndex))
                            {
                                chainEntryIndexPointers[headIndex] =
                                    Convert.ToUInt64(Convert.ToInt64(chainEntryIndexPointers[headIndex]) -
                                                     truncateSize);
                            }
                            if (removeIndexesHashed.Contains(currentEntryPoint)) //removeIndexes.Any(r => r.EntryPoint == Convert.ToUInt64(sourceFileStream.Position + 1)))
                            {
                                truncateSize += _hashBytesLength + 16;
                                sourceFileStream.Seek(_hashBytesLength + 16, SeekOrigin.Current);
                            }
                            else
                            {
                                if (sourceFileStream.Read(hashBuffer, 0, _hashBytesLength) != _hashBytesLength) throw new RuntimeException("index content read fatal error (hashBuffer)");
                                if (sourceFileStream.Read(recordPointBuffer, 0, 8) != 8) throw new RuntimeException("index content read fatal error (positionBuffer)");
                                if (sourceFileStream.Read(nextPositionBuffer, 0, 8) != 8) throw new RuntimeException("index content read fatal error (nextPositionBuffer)");
                                targetFileStream.Write(hashBuffer);
                                targetFileStream.Write(recordPointBuffer);
                                if (nextPositionBuffer.SequenceEqual(_lastRecordPointer))
                                {
                                    targetFileStream.Write(_lastRecordPointer);
                                }
                                else
                                {
                                    var newNextPosition = Convert.ToInt64(BitConverter.ToUInt64(nextPositionBuffer)) - truncateSize;
                                    targetFileStream.Write(BitConverter.GetBytes(Convert.ToUInt64(newNextPosition)));
                                }
                            }
                        }
                        Debug.WriteLine($"Truncated {truncateSize} bytes on File {_filePath}");
                    }
                }
                indexHeadFile.SaveFile();
                File.Delete(_filePath);
                File.Move(tempFilePath, _filePath);
            }
        }

        public void StartBulkInsert()
        {
            _bulkInsertFileStream = File.Open(_filePath, FileMode.OpenOrCreate);
        }

        public void EndBulkInsert()
        {
            _bulkInsertFileStream?.Dispose();
            _bulkInsertFileStream = null;
        }

        public void AppendToChain(ulong chainEntryPoint, byte[] valueHash, ulong recordPoint)
        {
            if (valueHash.Length != _hashBytesLength) throw new RuntimeException("index hash length mismatch");
            if (_bulkInsertFileStream != null)
            {
                AppendToChain(_bulkInsertFileStream, chainEntryPoint, valueHash, recordPoint);
            }
            else
            {
                lock (_fileLock)
                {
                    using (var fileStream = File.Open(_filePath, FileMode.OpenOrCreate))
                    {
                        AppendToChain(fileStream, chainEntryPoint, valueHash, recordPoint);
                    }
                }
            }
        }

        private void AppendToChain(FileStream fileStream, ulong chainEntryPoint, byte[] valueHash, ulong recordPoint)
        {
            var addedPosition = AppendToStream(fileStream, valueHash, recordPoint);
            var currentPosition = fileStream.Position;
            var nextPositionBuffer = new byte[8];
            var nextEntryPosition = Convert.ToInt64(chainEntryPoint - 1);
            var hasMoreEntries = true;
            var chainLength = 0;
            var maxChainLength = TableFieldIndex.IndexAttribute.OverrideMaxChainLength > -1
                ? TableFieldIndex.IndexAttribute.OverrideMaxChainLength
                : TableFieldIndex.IndexTypeInfo.MaxIndexChainLength;
            while (hasMoreEntries)
            {
                chainLength++;
                if (maxChainLength > 0
                    && chainLength >= maxChainLength)
                {
                    // this chain has already MAX entries, we upgrade to index-content-parts
                    // we undo the latest AppendToStream
                    fileStream.SetLength(addedPosition);
                    // and throw the upgrade needed Exception
                    throw new UpgradeNeededException();
                }
                currentPosition = fileStream.Seek(nextEntryPosition + _hashBytesLength + 8 - currentPosition, SeekOrigin.Current);
                if (fileStream.Read(nextPositionBuffer, 0, 8) != 8) throw new RuntimeException("index content read fatal error (nextPositionBuffer)");
                currentPosition += 8;
                nextEntryPosition = Convert.ToInt64(BitConverter.ToUInt64(nextPositionBuffer));
                hasMoreEntries = nextEntryPosition >= currentPosition;
            }

            fileStream.Seek(-8, SeekOrigin.Current);
            fileStream.Write(BitConverter.GetBytes(Convert.ToUInt64(addedPosition)));
        }

        public IndexRecord? GetFirstIndex(ulong chainEntryPoint, byte[] valueHash)
        {
            return new IndexContentEnumerable(this, chainEntryPoint, valueHash, 1).FirstOrDefault();
        }

        public IEnumerable<IndexRecord> EnumerateIndexes(ulong chainEntryPoint, byte[] valueHash)
        {
            return new IndexContentEnumerable(this, chainEntryPoint, valueHash, _enumerationChunkSize);
        }

        public List<IndexRecord> ReadIndexesChunkt(ulong chainEntryPoint, byte[]? valueHash = null, int maxCount = 0)
        {
            if (_bulkInsertFileStream != null)
            {
                return ReadIndexesChunkt(_bulkInsertFileStream, chainEntryPoint, valueHash, maxCount);
            }
            lock (_fileLock)
            {
                try
                {
                    using (var fileStream = File.Open(_filePath, FileMode.Open))
                    {
                        return ReadIndexesChunkt(fileStream, chainEntryPoint, valueHash, maxCount);
                    }
                }
                catch (FileNotFoundException)
                {
                    // index is empty
                }
            }
            return new List<IndexRecord>();
        }

        private List<IndexRecord> ReadIndexesChunkt(FileStream fileStream, ulong chainEntryPoint, byte[]? valueHash, int maxCount)
        {
            var indexList = new List<IndexRecord>();
            long currentPosition = fileStream.Position;
            var nextEntryPosition = Convert.ToInt64(chainEntryPoint - 1);
            var hashBuffer = new byte[_hashBytesLength];
            var recordPointBuffer = new byte[8];
            var nextPositionBuffer = new byte[8];
            var hasMoreEntries = true;
            while (hasMoreEntries
                   && (maxCount == 0 || maxCount > indexList.Count))
            {
                if (nextEntryPosition > 0)
                {
                    currentPosition = fileStream.Seek(nextEntryPosition - currentPosition, SeekOrigin.Current);
                }
                if (fileStream.Read(hashBuffer, 0, _hashBytesLength) != _hashBytesLength) throw new RuntimeException("index content read fatal error (hashBuffer)");
                if (fileStream.Read(recordPointBuffer, 0, 8) != 8) throw new RuntimeException("index content read fatal error (positionBuffer)");
                if (fileStream.Read(nextPositionBuffer, 0, 8) != 8) throw new RuntimeException("index content read fatal error (nextPositionBuffer)");
                nextEntryPosition = Convert.ToInt64(BitConverter.ToUInt64(nextPositionBuffer));
                if (valueHash == null
                    || valueHash.SequenceEqual(hashBuffer))
                {
                    indexList.Add(
                        new IndexRecord(hashBuffer,
                            BitConverter.ToUInt64(recordPointBuffer),
                            Convert.ToUInt64(currentPosition + 1),
                            Convert.ToUInt64(nextEntryPosition == 0 ? 0 : nextEntryPosition + 1))
                    );
                }
                currentPosition += _hashBytesLength + 16;
                hasMoreEntries = nextEntryPosition >= currentPosition;
            }
            return indexList;
        }

        private long AppendToStream(Stream fileStream, byte[] indexHash, ulong recordPoint)
        {
            fileStream.Seek(0, SeekOrigin.End);
            var entryPosition = fileStream.Position;
            fileStream.Write(indexHash);
            fileStream.Write(BitConverter.GetBytes(recordPoint));
            fileStream.Write(_lastRecordPointer);
            return entryPosition;
        }

        public class UpgradeNeededException : Exception
        {
        }
    }
}
