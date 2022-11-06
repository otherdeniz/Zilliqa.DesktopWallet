namespace Zilligraph.Database.Contract.Statistics
{
    public class StatisticCalculatorFieldSum<TValue>
    {
        public StatisticCalculatorFieldSum(string propertyName)
        {
            PropertyName = propertyName;
            if (typeof(TValue) == typeof(int))
            {
                StatisticDataLength = 4;
            }

            throw new NotSupportedException($"StatisticCalculatorFieldSum: Type {typeof(TValue)} not supported");
        }

        public int StatisticDataLength { get; }

        public string PropertyName { get; }

        public byte[] AddToStatistics(byte[] currentData, TValue addValue)
        {
            return null;
        }
    }
}
