using Zillifriends.Shared.Common;

namespace Zilligraph.Database.Storage.Index
{
    /// <summary>
    /// An IndexHeadSingleFile is to hold In-Memory, it holds the first 2 Bytes of the Hash and redirects to the position of the Index for the Entry-Position to all the records
    /// The file has the following structure in binary format:
    /// 8 bytes = index-position (int64)
    /// total number of records = 2^16
    /// file size = 524’288 bytes (0.5 MB)
    /// </summary>
    public class IndexHeadSingleFile
    {
        private readonly string _filePath;
        private readonly object _fileLock = new();
        private ulong[]? _indexPointers;

        public IndexHeadSingleFile(ZilligraphTableIndexBase tableFieldIndex)
        {
            TableFieldIndex = tableFieldIndex;
            _filePath = tableFieldIndex.Table.PathBuilder.GetFilePath($"{tableFieldIndex.Name}_index_head.bin");
        }

        public ZilligraphTableIndexBase TableFieldIndex { get; }

        public IEnumerable<ulong> GetAllIndexPoints()
        {
            if (_indexPointers == null)
            {
                _indexPointers = LoadOrCreateFile();
            }

            return _indexPointers.Where(i => i > 0);
        }

        public ulong GetIndexPoint(UInt16 hashPrefix16Bit)
        {
            if (_indexPointers == null)
            {
                _indexPointers = LoadOrCreateFile();
            }

            return _indexPointers[hashPrefix16Bit];
        }

        public void SetIndexPoint(UInt16 hashPrefix16Bit, ulong indexPoint)
        {
            if (_indexPointers == null)
            {
                throw new RuntimeException($"index file {_filePath} not loaded");
            }
            _indexPointers[hashPrefix16Bit] = indexPoint;
            lock (_fileLock)
            {
                using (var fileStream = File.Open(_filePath, FileMode.Open))
                {
                    var filePosition = hashPrefix16Bit * 8;
                    fileStream.Position = filePosition;
                    var writeBuffer = BitConverter.GetBytes(indexPoint);
                    fileStream.Write(writeBuffer);
                }
            }
        }

        internal bool FileExists()
        {
            return File.Exists(_filePath);
        }

        private ulong[] LoadOrCreateFile()
        {
            var pointerArray = new ulong[65536];
            lock (_fileLock)
            {
                if (File.Exists(_filePath))
                {
                    using (var fileStream = File.Open(_filePath, FileMode.Open))
                    {
                        var readBuffer = new byte[8];
                        for (int i = 0; i < pointerArray.Length; i++)
                        {
                            if (fileStream.Read(readBuffer, 0, 8) != 8)
                            {
                                throw new RuntimeException($"Read of index file {_filePath} failed");
                            }

                            pointerArray[i] = BitConverter.ToUInt64(readBuffer, 0);
                        }
                    }
                }
                else
                {
                    using (var fileStream = File.Open(_filePath, FileMode.CreateNew))
                    {
                        var writeBuffer = new byte[8];
                        for (int i = 0; i < pointerArray.Length; i++)
                        {
                            fileStream.Write(writeBuffer);
                        }
                    }
                }
            }

            return pointerArray;
        }
    }
}
