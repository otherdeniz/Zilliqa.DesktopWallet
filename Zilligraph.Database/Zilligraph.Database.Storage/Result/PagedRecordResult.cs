using Zilligraph.Database.Storage.Index;

namespace Zilligraph.Database.Storage.Result
{
    public class PagedRecordResult<TRecordModel> where TRecordModel : class, new()
    {
        private readonly IFilterSearcher _filterSearcher;
        private readonly List<ulong> _recordPoints = new();
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
            ReadIndexes();
        }

        public ZilligraphTable<TRecordModel> Table { get; }

        public int PageSize { get; }

        public int PageCount { get; private set; }

        public int RecordCount { get; private set; }

        public IEnumerable<TRecordModel> GetPage(int pageNumber)
        {
            if (_inverseOrder)
            {
                var firstRecord = RecordCount - ((pageNumber - 1) * PageSize);
                var lastRecord = RecordCount - (pageNumber * PageSize) + 1;
                for (int i = firstRecord; i >= lastRecord; i--)
                {
                    if (i >= 1)
                    {
                        yield return Table.ReadRecord(_recordPoints[i - 1], _resolveReferences);
                    }
                }
            }
            else
            {
                var firstRecord = (pageNumber - 1) * PageSize + 1;
                var lastRecord = pageNumber * PageSize;
                for (int i = firstRecord; i <= lastRecord; i++)
                {
                    if (RecordCount >= i)
                    {
                        yield return Table.ReadRecord(_recordPoints[i - 1], _resolveReferences);
                    }
                }
            }
        }

        private void ReadIndexes()
        {
            while (!_filterSearcher.NoMoreRecords)
            {
                var recordPoint = _filterSearcher.GetNextRecordPoint();
                if (recordPoint != null)
                {
                    _recordPoints.Add(recordPoint.Value);
                }
                else
                {
                    break;
                }
            }

            RecordCount = _recordPoints.Count;

            var pagesFraction = Convert.ToDecimal(RecordCount) / Convert.ToDecimal(PageSize);
            var pageCount = Math.Floor(pagesFraction);
            if (pagesFraction > pageCount)
            {
                pageCount += 1;
            }
            PageCount = Convert.ToInt32(pageCount);

        }
    }
}
