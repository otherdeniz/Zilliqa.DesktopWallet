using System.Collections;

namespace Zilligraph.Database.Storage.Table
{
    public class DataFileEnumerable : IEnumerable<CompressedDataRowBinary>
    {
        private readonly DataFile _dataFile;

        public DataFileEnumerable(DataFile dataFile)
        {
            _dataFile = dataFile;
        }

        public IEnumerator<CompressedDataRowBinary> GetEnumerator()
        {
            return new DataFileEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class DataFileEnumerator : IEnumerator<CompressedDataRowBinary>
        {
            private const int ChunkSize = 1000;
            private readonly DataFileEnumerable _enumerable;
            private bool _endOfFile;
            private List<CompressedDataRowBinary>? _currentChunk;
            private int _currentChunkIndex;
            private bool _readNextChunk = true;

            public DataFileEnumerator(DataFileEnumerable enumerable)
            {
                _enumerable = enumerable;
            }

            public bool MoveNext()
            {
                if (_endOfFile)
                {
                    return false;
                }

                if (_readNextChunk && _currentChunk == null)
                {
                    var nextRecordPoint = Current == null
                        ? 1
                        : Convert.ToUInt64(Current.RowPosition + 1 + Current.RowLength + 4);
                    _currentChunk = _enumerable._dataFile.ReadChunked(nextRecordPoint, ChunkSize);
                    _currentChunkIndex = 0;
                    _readNextChunk = _currentChunk.Count == ChunkSize;
                }
                try
                {
                    if (_currentChunk?.Count > _currentChunkIndex)
                    {
                        Current = _currentChunk[_currentChunkIndex];
                        _currentChunkIndex++;
                        if (_currentChunkIndex >= _currentChunk.Count)
                        {
                            _currentChunk = null;
                        }
                    }
                    else
                    {
                        // End of File
                        _endOfFile = true;
                        Current = null;
                    }
                    return Current != null;
                }
                catch (Exception)
                {
                    // End of File
                    _endOfFile = true;
                    Current = null;
                    return false;
                }
            }

            public void Reset()
            {
                Current = null;
                _endOfFile = false;
            }

#pragma warning disable CS8766 //Nullability
            public CompressedDataRowBinary? Current { get; private set; }
#pragma warning restore CS8766

            object? IEnumerator.Current => Current;

            public void Dispose()
            {
                // nothing to do yet
            }
        }
    }
}
