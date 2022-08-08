namespace Zilligraph.Database.Storage.FilterQuery
{
    public class FilterCombination : IFilterQuery
    {
        public List<IFilterQuery> Queries { get; set; }

        public FilterQueryCombinationMethod Method { get; set; } = FilterQueryCombinationMethod.And;
    }

    public enum FilterQueryCombinationMethod
    {
        And = 1,
        Or = 2
    }
}
