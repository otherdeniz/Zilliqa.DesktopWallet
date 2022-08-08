using System.Collections;
using Zilligraph.Database.Storage.FilterQuery;
using Zilligraph.Database.Storage.Index;

namespace Zilligraph.Database.Storage.Table
{
    public class RecordsResultEnumerable<TRecordModel> : IEnumerable<TRecordModel> where TRecordModel : class, new()
    {
        private readonly ZilligraphTable<TRecordModel> _table;
        private readonly IFilterSearcher _filterSearcher;

        public RecordsResultEnumerable(ZilligraphTable<TRecordModel> table, IFilterSearcher filterSearcher)
        {
            _table = table;
            _filterSearcher = filterSearcher;
        }

        public IEnumerator<TRecordModel> GetEnumerator()
        {
            return new RecordsResultEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class RecordsResultEnumerator : IEnumerator<TRecordModel>
        {
            private readonly RecordsResultEnumerable<TRecordModel> _recordsResultEnumerable;

            public RecordsResultEnumerator(RecordsResultEnumerable<TRecordModel> recordsResultEnumerable)
            {
                _recordsResultEnumerable = recordsResultEnumerable;
            }

            public bool MoveNext()
            {
                var nextRecordPoint = _recordsResultEnumerable._filterSearcher.GetNextRecordPoint();
                if (nextRecordPoint == null)
                {
                    Current = null;
                    return false;
                }

                Current = _recordsResultEnumerable._table.ReadRecord(nextRecordPoint.Value);

                return true;
            }

            public void Reset()
            {
                throw new NotSupportedException("RecordsResultEnumerable can not restart");
            }

#pragma warning disable CS8766 //Nullability
            public TRecordModel? Current { get; private set; }
#pragma warning restore CS8766

            object? IEnumerator.Current => Current;

            public void Dispose()
            {
                // nothing to do yet
            }
        }
    }
}
