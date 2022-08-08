using Zillifriends.Shared.Common;
using Zilligraph.Database.Storage.FilterQuery;

namespace Zilligraph.Database.Storage.Index
{
    public static class FilterSearcherFactory
    {
        public static IFilterSearcher CreateFilterSearcher(IZilligraphTable table, IFilterQuery filterQuery)
        {
            if (filterQuery is FilterQueryField queryField)
            {
                return new FilterFieldSearcher(table, queryField);
            }
            if (filterQuery is FilterCombination filterCombination)
            {
                var childSearchers = filterCombination.Queries.Select(q => CreateFilterSearcher(table, q));
                return filterCombination.Method == FilterQueryCombinationMethod.And
                    ? new FilterAndCombinationSearcher(table, childSearchers)
                    : new FilterOrCombinationSearcher(table, childSearchers);
            }

            throw new RuntimeException("FilterQuery type not supporteed");
        }
    }
}
