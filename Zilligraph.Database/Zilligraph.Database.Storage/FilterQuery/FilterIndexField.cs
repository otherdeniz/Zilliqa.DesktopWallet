namespace Zilligraph.Database.Storage.FilterQuery
{
    public abstract class FilterIndexField : IFilterQuery
    {
        public static FilterIndexField<string> FromStringEquals(string propertyName, string value)
        {
            return new FilterIndexField<string>
            {
                PropertyName = propertyName,
                Compare = FilterIndexCompare.Equals,
                Value = value
            };
        }

        public static FilterIndexField<int> FromInt32(string propertyName, int value,
            FilterIndexCompare compare = FilterIndexCompare.Equals)
        {
            return new FilterIndexField<int>
            {
                PropertyName = propertyName,
                Compare = compare,
                Value = value
            };
        }

        public static FilterIndexField<long> FromInt64(string propertyName, long value,
            FilterIndexCompare compare = FilterIndexCompare.Equals)
        {
            return new FilterIndexField<long>
            {
                PropertyName = propertyName,
                Compare = compare,
                Value = value
            };
        }

        public static FilterIndexField<decimal> FromDecimal(string propertyName, decimal value,
            FilterIndexCompare compare = FilterIndexCompare.Equals)
        {
            return new FilterIndexField<decimal>
            {
                PropertyName = propertyName,
                Compare = compare,
                Value = value
            };
        }

        public static FilterIndexField<DateTime> FromDateTime(string propertyName, DateTime value,
            FilterIndexCompare compare = FilterIndexCompare.Equals)
        {
            return new FilterIndexField<DateTime>
            {
                PropertyName = propertyName,
                Compare = compare,
                Value = value
            };
        }

        public abstract Type ValueType { get; }

        public abstract string? ValueString { get; }

        public string PropertyName { get; private init; } = null!;

        public FilterIndexCompare Compare { get; set; } = FilterIndexCompare.Equals;

    }

    public class FilterIndexField<TValueType> : FilterIndexField
    {
        public override Type ValueType => typeof(TValueType);

        public override string? ValueString => Value?.ToString();

        public TValueType? Value { get; set; }
    }

    public enum FilterIndexCompare
    {
        Equals = 1,
        NotEquals = 2,
        GreatherThan = 3,
        GreatherOrEqualsThan = 4,
        SmallerThan = 5,
        SmallerOrEqualsThan = 6
    }
}
