namespace Zilligraph.Database.Contract
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class CalculatedIndexAttribute : Attribute
    {
        public string IndexName { get; }

        public Type IndexCalculator { get; }

        public CalculatedIndexAttribute(string indexName, Type indexCalculator)
        {
            IndexName = indexName;
            IndexCalculator = indexCalculator;
        }
    }
}
