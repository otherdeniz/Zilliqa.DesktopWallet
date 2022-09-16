using System.Collections;

namespace Zilligraph.Database.Storage.Index
{
    public class IndexContentEnumerable : IEnumerable<IndexRecord>
    {
        private readonly IndexContentFile _contentFile;
        private readonly ulong _chainEntryPoint;
        private readonly byte[] _valueHash;
        private int _chunkSize;
        private List<IndexRecord>? _recordChunk;
        private int _chunkPosition = -1;

        public IndexContentEnumerable(IndexContentFile contentFile, ulong chainEntryPoint, byte[] valueHash, int initialChunkSize)
        {
            _contentFile = contentFile;
            _chainEntryPoint = chainEntryPoint;
            _valueHash = valueHash;
            _chunkSize = initialChunkSize;
        }

        public IEnumerator<IndexRecord> GetEnumerator()
        {
            return new IndexRecordEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IndexRecord? ReadNextRecord()
        {
            _chunkPosition++;
            if (_recordChunk == null || _chunkPosition > _recordChunk.Count - 1)
            {
                var nextEntryPoint = GetNextEntryPoint();
                if (nextEntryPoint == 0)
                {
                    return null;
                }
                if (_recordChunk != null)
                {
                    // increase the chunks
                    _chunkSize *= 2;
                }
                _recordChunk = _contentFile.ReadIndexesChunkt(nextEntryPoint, _valueHash, _chunkSize);
                _chunkPosition = 0;
            }

            if (_chunkPosition >= _recordChunk.Count)
            {
                return null;
            }

            return _recordChunk[_chunkPosition];
        }

        private ulong GetNextEntryPoint()
        {
            if (_recordChunk == null)
            {
                return _chainEntryPoint;
            }

            return _recordChunk.Last().NextEntryPoint;
        }

        public class IndexRecordEnumerator : IEnumerator<IndexRecord>
        {
            private readonly IndexContentEnumerable _indexContentEnumerable;

            public IndexRecordEnumerator(IndexContentEnumerable indexContentEnumerable)
            {
                _indexContentEnumerable = indexContentEnumerable;
            }

            public bool MoveNext()
            {
                Current = _indexContentEnumerable.ReadNextRecord();
                return Current != null;
            }

            public void Reset()
            {
                _indexContentEnumerable._recordChunk = null;
                _indexContentEnumerable._chunkPosition = -1;
            }

#pragma warning disable CS8766 //Nullability
            public IndexRecord? Current { get; private set; }
#pragma warning restore CS8766

            object? IEnumerator.Current => Current;

            public void Dispose()
            {
                // nothing to do yet
            }
        }
    }

}
