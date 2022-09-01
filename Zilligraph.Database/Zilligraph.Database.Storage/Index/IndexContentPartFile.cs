using Zillifriends.Shared.Common;

namespace Zilligraph.Database.Storage.Index
{
    public class IndexContentPartFile
    {
        private static readonly int _enumerationChunkSize = 2000;
        private readonly int _hashBytesLength;
        private readonly string _filePath;
        private readonly object _fileLock = new();

        public IndexContentPartFile(ZilligraphTableIndexBase tableFieldIndex, int hashBytesLength, ushort hashPrefix16Bit, byte hashPart4Bit)
        {
            _hashBytesLength = hashBytesLength;
            TableFieldIndex = tableFieldIndex;
            var prefixHex = BitConverter.GetBytes(hashPrefix16Bit).ByteArrayToHexString();
            var partHex = hashPart4Bit.ByteToHexString().Substring(1);
            _filePath = tableFieldIndex.PathBuilder.GetFilePath($"{tableFieldIndex.Name}_content_{prefixHex}_{partHex}.bin");
        }

        public ZilligraphTableIndexBase TableFieldIndex { get; }

        public void Append(byte[] valueHash, ulong recordPoint)
        {
            if (valueHash.Length != _hashBytesLength) throw new RuntimeException("index hash length mismatch");
            lock (_fileLock)
            {
                using (var fileStream = File.Open(_filePath, FileMode.OpenOrCreate))
                {
                    fileStream.Seek(0, SeekOrigin.End);
                    fileStream.Write(valueHash);
                    fileStream.Write(BitConverter.GetBytes(recordPoint));
                }
            }
        }

        public void Append(List<(byte[], ulong)> appendList)
        {
            if (!appendList.Any()) return;
            if (appendList[0].Item1.Length != _hashBytesLength) throw new RuntimeException("index hash length mismatch");
            lock (_fileLock)
            {
                using (var fileStream = File.Open(_filePath, FileMode.OpenOrCreate))
                {
                    fileStream.Seek(0, SeekOrigin.End);
                    foreach (var appendItem in appendList)
                    {
                        fileStream.Write(appendItem.Item1);
                        fileStream.Write(BitConverter.GetBytes(appendItem.Item2));
                    }
                }
            }
        }

        public IndexRecord? GetFirstIndex(byte[] valueHash)
        {
            lock (_fileLock)
            {
                try
                {
                    using (var fileStream = File.Open(_filePath, FileMode.Open))
                    {
                        while (fileStream.Position < fileStream.Length)
                        {
                            var indexEntryPoint = fileStream.Position + 1;
                            var hashBuffer = new byte[_hashBytesLength];
                            var recordPointBuffer = new byte[8];
                            if (fileStream.Read(hashBuffer, 0, _hashBytesLength) != _hashBytesLength)
                                throw new RuntimeException($"index content read fatal error (hashBuffer) - File {_filePath}");
                            if (valueHash.SequenceEqual(hashBuffer))
                            {
                                if (fileStream.Read(recordPointBuffer, 0, 8) != 8)
                                    throw new RuntimeException($"index content read fatal error (positionBuffer) - File {_filePath}");
                                return new IndexRecord(hashBuffer,
                                    BitConverter.ToUInt64(recordPointBuffer),
                                    Convert.ToUInt64(indexEntryPoint),
                                    0);
                            }
                            fileStream.Seek(8, SeekOrigin.Current);
                        }
                    }
                }
                catch (FileNotFoundException)
                {
                    // index part is empty
                }
            }

            return null;
        }

        public IEnumerable<IndexRecord> EnumerateIndexes(byte[] valueHash)
        {
            return new IndexContentPartEnumerable(this, valueHash, _enumerationChunkSize);
        }

        public List<IndexRecord> ReadIndexesChunkt(ulong lastIndexEntryPoint, byte[] valueHash, int maxCount = 0)
        {
            var indexList = new List<IndexRecord>();
            lock (_fileLock)
            {
                try
                {
                    using (var fileStream = File.Open(_filePath, FileMode.Open))
                    {
                        if (lastIndexEntryPoint > 0)
                        {
                            var advancePosition = Convert.ToInt64(lastIndexEntryPoint) - 1 + _hashBytesLength + 8;
                            if (fileStream.Seek(advancePosition, SeekOrigin.Begin) != advancePosition)
                                throw new RuntimeException($"index content read fatal error (Seek) - File {_filePath}");
                        }
                        while (fileStream.Position < fileStream.Length
                               && (maxCount == 0 || maxCount > indexList.Count))
                        {
                            var indexEntryPoint = fileStream.Position + 1;
                            var hashBuffer = new byte[_hashBytesLength];
                            var recordPointBuffer = new byte[8];
                            if (fileStream.Read(hashBuffer, 0, _hashBytesLength) != _hashBytesLength)
                                throw new RuntimeException($"index content read fatal error (hashBuffer) - File {_filePath}");
                            if (valueHash.SequenceEqual(hashBuffer))
                            {
                                if (fileStream.Read(recordPointBuffer, 0, 8) != 8)
                                    throw new RuntimeException($"index content read fatal error (positionBuffer) - File {_filePath}");
                                indexList.Add(
                                    new IndexRecord(hashBuffer,
                                        BitConverter.ToUInt64(recordPointBuffer),
                                        Convert.ToUInt64(indexEntryPoint),
                                        0)
                                );
                            }
                            else
                            {
                                if (fileStream.Seek(8, SeekOrigin.Current) != 8)
                                    throw new RuntimeException($"index content read fatal error (Seek) - File {_filePath}");
                            }
                        }
                    }
                }
                catch (FileNotFoundException)
                {
                    // index part is empty
                }
            }
            return indexList;
        }

    }
}
