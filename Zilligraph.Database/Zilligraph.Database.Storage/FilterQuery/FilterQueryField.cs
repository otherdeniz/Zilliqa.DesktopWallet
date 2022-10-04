namespace Zilligraph.Database.Storage.FilterQuery
{
    public class FilterQueryField : IFilterQuery
    {
        public FilterQueryField(string propertyName, object? value,
            FilterIndexCompare compare = FilterIndexCompare.Equals,
            bool cache = false)
        {
            PropertyName = propertyName;
            Value = value;
            Compare = compare;
            Cache = cache;
        }

        public object? Value { get; }

        public string PropertyName { get; }

        public FilterIndexCompare Compare { get; }

        public bool Cache { get; }
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
