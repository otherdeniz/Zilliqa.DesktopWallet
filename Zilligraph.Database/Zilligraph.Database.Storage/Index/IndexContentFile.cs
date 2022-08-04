using Zillifriends.Shared.Common;

namespace Zilligraph.Database.Storage.Index
{
    public class IndexContentFile
    {
        private readonly int _hashBytesLength;
        private readonly string _filePath;
        private readonly object _fileLock = new();
        private readonly byte[] _lastRecordPointer = BitConverter.GetBytes((long)0);

        public IndexContentFile(ZilligraphFieldIndex fieldIndex, int hashBytesLength)
        {
            _hashBytesLength = hashBytesLength;
            FieldIndex = fieldIndex;
            _filePath = fieldIndex.Table.PathBuilder.GetFilePath($"{fieldIndex.PropertyName}_index_content.bin");
        }

        public ZilligraphFieldIndex FieldIndex { get; }

        public ulong CreateChain(IndexItem index)
        {
            if (index.IndexHash.Length != _hashBytesLength) throw new RuntimeException("index hash length mismatch");
            lock (_fileLock)
            {
                using (var fileStream = File.Open(_filePath, FileMode.OpenOrCreate))
                {
                    return AppendToStream(fileStream, index);
                }
            }
        }

        public void AppendToChain(ulong chainEntryPoint, IndexItem index)
        {
            if (index.IndexHash.Length != _hashBytesLength) throw new RuntimeException("index hash length mismatch");
            lock (_fileLock)
            {
                using (var fileStream = File.Open(_filePath, FileMode.OpenOrCreate))
                {
                    var addedPosition = AppendToStream(fileStream, index);
                    long currentPosition = fileStream.Seek(0, SeekOrigin.Begin);
                    var nextPositionBuffer = new byte[8];
                    var nextEntryPoint = Convert.ToInt64(chainEntryPoint - 1);
                    var hasMoreEntries = true;
                    while (hasMoreEntries)
                    {
                        currentPosition = fileStream.Seek(nextEntryPoint + _hashBytesLength + 8 - currentPosition, SeekOrigin.Current);
                        if (fileStream.Read(nextPositionBuffer, 0, 8) != 8) throw new RuntimeException("index content read fatal error (nextPositionBuffer)");
                        currentPosition += 8;
                        nextEntryPoint = Convert.ToInt64(BitConverter.ToUInt64(nextPositionBuffer));
                        hasMoreEntries = nextEntryPoint > currentPosition;
                    }

                    fileStream.Seek(-8, SeekOrigin.Current);
                    fileStream.Write(BitConverter.GetBytes(addedPosition));
                }
            }
        }

        public IEnumerable<IndexItem> GetIndexes(ulong chainEntryPoint)
        {
            var indexList = new List<IndexItem>();
            lock (_fileLock)
            {
                using (var fileStream = File.Open(_filePath, FileMode.OpenOrCreate))
                {
                    long currentPosition = 0;
                    var nextEntryPoint = Convert.ToInt64(chainEntryPoint - 1);
                    var positionBuffer = new byte[8];
                    var nextPositionBuffer = new byte[8];
                    var hasMoreEntries = true;
                    while (hasMoreEntries)
                    {
                        var hashBuffer = new byte[_hashBytesLength];
                        if (nextEntryPoint > 0)
                        {
                            currentPosition = fileStream.Seek(nextEntryPoint - currentPosition, SeekOrigin.Current);
                        }
                        if (fileStream.Read(hashBuffer, 0, _hashBytesLength) != _hashBytesLength) throw new RuntimeException("index content read fatal error (hashBuffer)");
                        if (fileStream.Read(positionBuffer, 0, 8) != 8) throw new RuntimeException("index content read fatal error (positionBuffer)");
                        if (fileStream.Read(nextPositionBuffer, 0, 8) != 8) throw new RuntimeException("index content read fatal error (nextPositionBuffer)");
                        currentPosition += _hashBytesLength + 16;
                        indexList.Add(new IndexItem(hashBuffer, BitConverter.ToUInt64(positionBuffer)));
                        nextEntryPoint = Convert.ToInt64(BitConverter.ToUInt64(nextPositionBuffer));
                        hasMoreEntries = nextEntryPoint > currentPosition;
                    }
                }
            }
            return indexList;
        }

        private ulong AppendToStream(Stream fileStream, IndexItem index)
        {
            fileStream.Seek(0, SeekOrigin.End);
            var entryPosition = Convert.ToUInt64(fileStream.Position + 1);
            fileStream.Write(index.IndexHash);
            fileStream.Write(BitConverter.GetBytes(index.RecordPosition));
            fileStream.Write(_lastRecordPointer);
            return entryPosition;
        }
    }
}
