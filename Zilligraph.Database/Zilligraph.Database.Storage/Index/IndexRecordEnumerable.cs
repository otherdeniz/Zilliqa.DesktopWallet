using System.Collections;

namespace Zilligraph.Database.Storage.Index
{
    public class IndexRecordEnumerable : IEnumerable<IndexRecord>
    {
        private readonly IndexContentFile _contentFile;
        private readonly ulong _chainEntryPoint;
        private readonly int _chunkSize;
        private List<IndexRecord>? _recordChunk;
        private int _listPosition = -1;

        public IndexRecordEnumerable(IndexContentFile contentFile, ulong chainEntryPoint, int chunkSize)
        {
            _contentFile = contentFile;
            _chainEntryPoint = chainEntryPoint;
            _chunkSize = chunkSize;
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
            if (_recordChunk == null || _listPosition > _recordChunk.Count - 1)
            {
                _recordChunk = _contentFile.ReadIndexesChunkt(GetNextEntryPoint(), _chunkSize);
                _listPosition = -1;
            }

            _listPosition++;
            if (_listPosition > _recordChunk.Count)
            {
                return null;
            }

            return _recordChunk[_listPosition];
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
            private readonly IndexRecordEnumerable _indexRecordEnumerable;

            public IndexRecordEnumerator(IndexRecordEnumerable indexRecordEnumerable)
            {
                _indexRecordEnumerable = indexRecordEnumerable;
            }

            public bool MoveNext()
            {
                var nextRecord = _indexRecordEnumerable.ReadNextRecord();
                if (nextRecord != null)
                {
                    Current = nextRecord;
                    return true;
                }

                return false;
            }

            public void Reset()
            {
                _indexRecordEnumerable._recordChunk = null;
                _indexRecordEnumerable._listPosition = -1;
            }

            public IndexRecord Current { get; private set; } = null!;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                // nothing to do yet
            }
        }
    }

}
