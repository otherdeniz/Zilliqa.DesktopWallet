using System.Reflection;
using Zilligraph.Database.Contract;

namespace Zilligraph.Database.Storage
{
    public class ZilligraphTableFieldIndex : ZilligraphTableIndexBase
    {
        private readonly PropertyInfo _propertyInfo;

        internal ZilligraphTableFieldIndex(IZilligraphTable table, PropertyInfo propertyInfo, IndexAttributeBase indexAttribute)
            : base(table, propertyInfo.Name, indexAttribute)
        {
            _propertyInfo = propertyInfo;
            ValueType = _propertyInfo.PropertyType;
        }

        public override Type ValueType { get; }

        public override void AddRecordIndex(ulong recordPoint, object record)
        {
            var propertyValue = _propertyInfo.GetValue(record);
            if (propertyValue != null)
            {
                AddRecordIndexValue(recordPoint, propertyValue);
            }
        }

    }

}
