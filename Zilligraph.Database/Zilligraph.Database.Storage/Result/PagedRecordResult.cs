using Zilligraph.Database.Storage.Index;

namespace Zilligraph.Database.Storage.Result
{
    public class PagedRecordResult<TRecordModel> where TRecordModel : class, new()
    {
        private readonly IFilterSearcher _filterSearcher;
        private readonly bool _resolveReferences;
        private readonly bool _inverseOrder;

        public PagedRecordResult(ZilligraphTable<TRecordModel> table, 
            IFilterSearcher filterSearcher,
            bool resolveReferences,
            bool inverseOrder,
            int pageSize)
        {
            _filterSearcher = filterSearcher;
            _resolveReferences = resolveReferences;
            _inverseOrder = inverseOrder;
            Table = table;
            PageSize = pageSize;
        }

        public ZilligraphTable<TRecordModel> Table { get; }

        public int PageSize { get; }

        public int PageCount { get; private set; }

        public int RecordCount { get; private set; }

        //public IEnumerable<TRecordModel> GetPage(int pageNumber)
        //{

        //}

        //private void ReadIndexes()
        //{
        //    _filterSearcher
        //}
    }
}
