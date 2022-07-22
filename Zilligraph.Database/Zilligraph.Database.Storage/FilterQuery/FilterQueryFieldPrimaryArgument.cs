namespace Zilligraph.Database.Storage.FilterQuery
{
    public class FilterQueryFieldPrimaryArgument : FilterQueryBase
    {
        public string FieldId { get; set; }

        public FilterQueryPrimaryCompare Compare { get; set; } = FilterQueryPrimaryCompare.Equals;

        public string Value { get; set; }
    }

    public enum FilterQueryPrimaryCompare
    {
        Equals = 1,
        NotEquals = 2
    }

}
