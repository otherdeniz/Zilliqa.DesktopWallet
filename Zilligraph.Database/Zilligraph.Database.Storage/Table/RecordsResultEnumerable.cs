using System.Collections;
using Zilligraph.Database.Storage.Index;

namespace Zilligraph.Database.Storage.Table
{
    public class RecordsResultEnumerable<TRecordModel> : IEnumerable<TRecordModel> where TRecordModel : class, new()
    {
        private readonly ZilligraphTable<TRecordModel> _table;
        private readonly IFilterSearcher _filterSearcher;
        private readonly Func<TRecordModel, bool>? _additionalFilter;
        private readonly bool _resolveReferences;

        public RecordsResultEnumerable(ZilligraphTable<TRecordModel> table, 
            IFilterSearcher filterSearcher, 
            Func<TRecordModel, bool>? additionalFilter, 
            bool resolveReferences)
        {
            _table = table;
            _filterSearcher = filterSearcher;
            _additionalFilter = additionalFilter;
            _resolveReferences = resolveReferences;
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
            private readonly RecordsResultEnumerable<TRecordModel> _enumerable;

            internal RecordsResultEnumerator(RecordsResultEnumerable<TRecordModel> enumerable)
            {
                _enumerable = enumerable;
            }

            public bool MoveNext()
            {
                while (true)
                {
                    var nextRecordPoint = _enumerable._filterSearcher.GetNextRecordPoint();
                    if (nextRecordPoint == null)
                    {
                        Current = null;
                        return false;
                    }

                    var record = _enumerable._table.ReadRecord(nextRecordPoint.Value, _enumerable._resolveReferences);
                    if (_enumerable._additionalFilter == null
                        || _enumerable._additionalFilter(record))
                    {
                        Current = record;
                        return true;
                    }
                }
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
