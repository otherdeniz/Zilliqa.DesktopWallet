using Zillifriends.Shared.Common;
using Zilligraph.Database.Contract;

namespace Zilligraph.Database.Storage;

public class ZilligraphTableCalculatedIndex : ZilligraphTableIndexBase
{
    private readonly IIndexCalculator _indexCalculator;

    internal ZilligraphTableCalculatedIndex(IZilligraphTable table, string name, Type indexCalculatorType)
        : base(table, name)
    {
        if (!(Activator.CreateInstance(indexCalculatorType) is IIndexCalculator iIndexCalculator))
        {
            throw new MissingCodeException(
                $"Error in Calculated Index definition '{name}' (Table {table.TableName}). The IndexCalculator must implement Interface 'IIndexCalculator'");
        }
        _indexCalculator = iIndexCalculator;
    }

    public override Type ValueType => _indexCalculator.ValueType;

    public override void AddRecordIndex(ulong recordPoint, object record)
    {
        var propertyValue = _indexCalculator.CalculateIndex(record);
        if (propertyValue != null)
        {
            AddRecordIndexValue(recordPoint, propertyValue);
        }
    }

}