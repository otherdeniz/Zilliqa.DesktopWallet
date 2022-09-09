namespace Zilligraph.Database.Storage.FilterQuery
{
    public class FilterQueryField : IFilterQuery
    {
        public FilterQueryField(string propertyName, object? value,
            FilterIndexCompare compare = FilterIndexCompare.Equals)
        {
            PropertyName = propertyName;
            Value = value;
        }

        public object? Value { get; }

        public string PropertyName { get; }

        public FilterIndexCompare Compare { get; }
    }

    public enum FilterIndexCompare
    {
        Equals = 1,
        NotEquals = 2,
        GreatherThan = 3,
        GreatherOrEqualsThan = 4,
        SmallerThan = 5,
        SmallerOrEqualsThan = 6,
        IsNull = 10,
        IsNotNull = 11
    }

}
