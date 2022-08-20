using System.Reflection;
using Zillifriends.Shared.Common;

namespace Zilligraph.Database.Storage
{
    public class ZilligraphTableFieldIndex : ZilligraphTableIndexBase
    {
        private readonly PropertyInfo _propertyInfo;

        internal ZilligraphTableFieldIndex(IZilligraphTable table, string propertyName)
            : base(table, propertyName)
        {
            _propertyInfo = Table.RecordType.GetProperty(propertyName) ??
                            throw new MissingCodeException(
                                $"Property {propertyName} not found on Type {Table.RecordType.FullName}");
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
