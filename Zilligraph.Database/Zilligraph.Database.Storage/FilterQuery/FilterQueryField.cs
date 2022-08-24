namespace Zilligraph.Database.Storage.FilterQuery
{
    public class FilterQueryField : IFilterQuery
    {
        public FilterQueryField(string propertyName, object? value)
        {
            PropertyName = propertyName;
            Value = value;
        }

        public object? Value { get; }

        public string PropertyName { get; }
    }

}
