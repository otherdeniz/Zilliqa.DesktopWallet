using System.Collections;
using Zilligraph.Database.Storage.FilterQuery;

namespace Zilligraph.Database.Storage.Table
{
    public class RecordsResultEnumerable<TRecordModel> : IEnumerable<TRecordModel> where TRecordModel : class, new()
    {
        private readonly ZilligraphTable<TRecordModel> _table;
        private readonly IFilterQuery _queryFilter;

        public RecordsResultEnumerable(ZilligraphTable<TRecordModel> table, IFilterQuery queryFilter)
        {
            _table = table;
            _queryFilter = queryFilter;
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
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
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
