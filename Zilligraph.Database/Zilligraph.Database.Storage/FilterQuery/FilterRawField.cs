namespace Zilligraph.Database.Storage.FilterQuery
{
    public class FilterRawField<TValueType> : IFilterQuery
    {
        public FilterRawField(string propertyName, TValueType value, FilterRawCompare compare = FilterRawCompare.Equals)
        {
            PropertyName = propertyName;
            Value = value;
            Compare = compare;
        }

        public string PropertyName { get; }

        public TValueType Value { get; }

        public FilterRawCompare Compare { get; }
    }

    public enum FilterRawCompare
    {
        Equals = 1,
        NotEquals = 2,
        GreatherThan = 3,
        GreatherOrEqualsThan = 4,
        SmallerThan = 5,
        SmallerOrEqualsThan = 6,
        TextContains = 11,
        TextNotContains = 12,
        TextBeginsWith = 13,
        TextEndsWith = 14,
        IsNull = 91,
        IsNotNull = 92
    }

}
