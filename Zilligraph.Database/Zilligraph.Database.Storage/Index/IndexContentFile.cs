using Zillifriends.Shared.Common;

namespace Zilligraph.Database.Storage.Index
{
    public class IndexContentFile
    {
        private static readonly int _enumerationChunkSize = 50;
        private readonly int _hashBytesLength;
        private readonly string _filePath;
        private readonly object _fileLock = new();
        private readonly byte[] _lastRecordPointer = BitConverter.GetBytes((ulong)0);

        public IndexContentFile(ZilligraphTableIndexBase tableFieldIndex, int hashBytesLength)
        {
            _hashBytesLength = hashBytesLength;
            TableFieldIndex = tableFieldIndex;
            _filePath = tableFieldIndex.Table.PathBuilder.GetFilePath($"{tableFieldIndex.Name}_index_content.bin");
        }

        public ZilligraphTableIndexBase TableFieldIndex { get; }

        public ulong CreateChain(byte[] indexHash, ulong recordPoint)
        {
            if (indexHash.Length != _hashBytesLength) throw new RuntimeException("index hash length mismatch");
            lock (_fileLock)
            {
                using (var fileStream = File.Open(_filePath, FileMode.OpenOrCreate))
                {
                    return Convert.ToUInt32(AppendToStream(fileStream, indexHash, recordPoint) + 1);
                }
            }
        }

        public void AppendToChain(ulong chainEntryPoint, byte[] valueHash, ulong recordPoint)
        {
            if (valueHash.Length != _hashBytesLength) throw new RuntimeException("index hash length mismatch");
            lock (_fileLock)
            {
                using (var fileStream = File.Open(_filePath, FileMode.OpenOrCreate))
                {
                    var addedPosition = AppendToStream(fileStream, valueHash, recordPoint);
                    long currentPosition = fileStream.Seek(0, SeekOrigin.Begin);
                    var nextPositionBuffer = new byte[8];
                    var nextEntryPosition = Convert.ToInt64(chainEntryPoint - 1);
                    var hasMoreEntries = true;
                    var chainLength = 0;
                    while (hasMoreEntries)
                    {
                        chainLength++;
                        if (chainLength >= 500)
                        {
                            // this chain has already 500 entries, we upgrade to index-content-part
                            // we undo the AppendToStream
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
            }
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
            var indexList = new List<IndexRecord>();
            lock (_fileLock)
            {
                using (var fileStream = File.Open(_filePath, FileMode.OpenOrCreate))
                {
                    long currentPosition = 0;
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
                        hasMoreEntries = nextEntryPosition > currentPosition;
                    }
                }
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
