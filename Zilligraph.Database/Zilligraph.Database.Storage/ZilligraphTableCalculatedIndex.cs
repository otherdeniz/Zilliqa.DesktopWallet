using System.Reflection;
using Zilligraph.Database.Contract;

namespace Zilligraph.Database.Storage;

public class ZilligraphTableCalculatedIndex : ZilligraphTableIndexBase
{
    private readonly MethodInfo _methodInfo;

    internal ZilligraphTableCalculatedIndex(IZilligraphTable table, MethodInfo methodInfo, IndexAttributeBase indexAttribute)
        : base(table, methodInfo.Name, indexAttribute)
    {
        _methodInfo = methodInfo;
    }

    public override Type ValueType => _methodInfo.ReturnType;

    public override void AddRecordIndex(ulong recordPoint, object record)
    {
        var propertyValue = _methodInfo.Invoke(record, new object?[]{});
        if (propertyValue != null)
        {
            AddRecordIndexValue(recordPoint, propertyValue);
        }
    }

}