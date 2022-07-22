namespace Zilligraph.Database.Storage.FilterQuery
{
    public class FilterQueryCombination : FilterQueryBase
    {
        public List<FilterQueryBase> Queries { get; set; }

        public FilterQueryCombinationMethod Method { get; set; } = FilterQueryCombinationMethod.And;
    }

    public enum FilterQueryCombinationMethod
    {
        And = 1,
        Or = 2
    }
}
