using System.Collections;

namespace Zilligraph.Database.Storage.Index;

public class IndexContentPartEnumerable : IEnumerable<IndexRecord>
{
    private readonly IndexContentPartFile _contentPartFile;
    private readonly byte[] _valueHash;
    private readonly int _chunkSize;
    private List<IndexRecord>? _recordChunk;
    private int _chunkPosition = -1;

    public IndexContentPartEnumerable(IndexContentPartFile contentPartFile, byte[] valueHash, int chunkSize)
    {
        _contentPartFile = contentPartFile;
        _valueHash = valueHash;
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
        _chunkPosition++;
        if (_recordChunk == null || _chunkPosition > _recordChunk.Count - 1)
        {
            var lastIndexEntryPoint = GetLastIndexEntryPoint();
            _recordChunk = _contentPartFile.ReadIndexesChunkt(lastIndexEntryPoint, _valueHash, _chunkSize);
            _chunkPosition = 0;
        }

        if (_chunkPosition >= _recordChunk.Count)
        {
            return null;
        }

        return _recordChunk[_chunkPosition];
    }

    private ulong GetLastIndexEntryPoint()
    {
        if (_recordChunk == null)
        {
            return 0;
        }

        return _recordChunk.Last().EntryPoint;
    }

    public class IndexRecordEnumerator : IEnumerator<IndexRecord>
    {
        private readonly IndexContentPartEnumerable _indexContentEnumerable;

        public IndexRecordEnumerator(IndexContentPartEnumerable indexContentEnumerable)
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