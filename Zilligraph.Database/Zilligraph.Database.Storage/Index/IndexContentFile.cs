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

        public IndexContentFile(ZilligraphFieldIndex fieldIndex, int hashBytesLength)
        {
            _hashBytesLength = hashBytesLength;
            FieldIndex = fieldIndex;
            _filePath = fieldIndex.Table.PathBuilder.GetFilePath($"{fieldIndex.PropertyName}_index_content.bin");
        }

        public ZilligraphFieldIndex FieldIndex { get; }

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
                    while (hasMoreEntries)
                    {
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

        public IEnumerable<IndexRecord> EnumerateIndexes(ulong chainEntryPoint, byte[] valueHash)
        {
            return new IndexRecordEnumerable(this, chainEntryPoint, valueHash, _enumerationChunkSize);
        }

        public List<IndexRecord> ReadIndexesChunkt(ulong chainEntryPoint, byte[] valueHash, int maxCount = 0)
        {
            var indexList = new List<IndexRecord>();
            lock (_fileLock)
            {
                using (var fileStream = File.Open(_filePath, FileMode.OpenOrCreate))
                {
                    long currentPosition = 0;
                    var nextEntryPosition = Convert.ToInt64(chainEntryPoint - 1);
                    var positionBuffer = new byte[8];
                    var nextPositionBuffer = new byte[8];
                    var hasMoreEntries = true;
                    while (hasMoreEntries 
                           && (maxCount == 0 || maxCount > indexList.Count))
                    {
                        var hashBuffer = new byte[_hashBytesLength];
                        if (nextEntryPosition > 0)
                        {
                            currentPosition = fileStream.Seek(nextEntryPosition - currentPosition, SeekOrigin.Current);
                        }
                        if (fileStream.Read(hashBuffer, 0, _hashBytesLength) != _hashBytesLength) throw new RuntimeException("index content read fatal error (hashBuffer)");
                        if (fileStream.Read(positionBuffer, 0, 8) != 8) throw new RuntimeException("index content read fatal error (positionBuffer)");
                        if (fileStream.Read(nextPositionBuffer, 0, 8) != 8) throw new RuntimeException("index content read fatal error (nextPositionBuffer)");
                        nextEntryPosition = Convert.ToInt64(BitConverter.ToUInt64(nextPositionBuffer));
                        if (valueHash.SequenceEqual(hashBuffer))
                        {
                            indexList.Add(
                                new IndexRecord(hashBuffer,
                                    BitConverter.ToUInt64(positionBuffer),
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
    }
}
