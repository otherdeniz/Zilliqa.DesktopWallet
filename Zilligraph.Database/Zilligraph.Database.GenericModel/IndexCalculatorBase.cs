namespace Zilligraph.Database.Contract
{
    public abstract class IndexCalculatorBase<TRecord, TIndexValue> : IIndexCalculator
    {
        public Type ValueType => typeof(TIndexValue);

        object? IIndexCalculator.CalculateIndex(object record)
        {
            return CalculateIndex((TRecord)record);
        }

        public abstract TIndexValue? CalculateIndex(TRecord record);
    }
}
