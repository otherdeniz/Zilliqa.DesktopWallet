namespace Zilligraph.Database.Contract
{
    public interface IIndexCalculator
    {
        Type ValueType { get; }

        object? CalculateIndex(object record);
    }
}
