using System.Reflection;
using Zillifriends.Shared.Common;
using Zilligraph.Database.Contract;
using Zilligraph.Database.Storage.Table;

namespace Zilligraph.Database.Storage
{
    public class ZilligraphMutableTable<TRecordModel> 
        : ZilligraphTable<TRecordModel> where TRecordModel : class, new()
    {
        private readonly List<MutableFieldInfo> _fieldInfos;
        private readonly PropertyInfo _primaryKeyProperty;

        public ZilligraphMutableTable(ZilligraphDatabase database)
            : base(database)
        {
            var fields = GetFields();
            _fieldInfos = fields.Fields;
            _primaryKeyProperty = fields.PrimaryKey;
        }

        public override List<DataFile> CompressedDataFiles { get; } = new();

        public override void UpdateRecord(object record)
        {
            throw new NotImplementedException();
        }

        protected override void AddRecordInternal(TRecordModel record)
        {
            throw new NotImplementedException();
        }

        protected override void Initialise(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private (PropertyInfo PrimaryKey, List<MutableFieldInfo> Fields) GetFields()
        {
            var fields = new List<MutableFieldInfo>();
            PropertyInfo? primaryKey = null;
            var recordType = typeof(TRecordModel);
            var pos = 0;
            foreach (var fieldProperty in recordType.GetProperties())
            {
                pos++;
                fields.Add(new MutableFieldInfo
                {
                    FieldPosition = pos,
                    Length = GetFieldLength(fieldProperty),
                    ValueType = fieldProperty.PropertyType,
                    PropertyName = fieldProperty.Name
                });
                if (fieldProperty.GetCustomAttribute<PrimaryKeyAttribute>() != null)
                {
                    primaryKey = fieldProperty;
                }
            }
            if (primaryKey == null)
            {
                throw new RuntimeException(
                    $"Table '{TableName}' must have a field notated with PrimaryKeyAttribute");
            }
            return (primaryKey, fields);
        }

        private int GetFieldLength(PropertyInfo propertyInfo)
        {
            if (propertyInfo.PropertyType == typeof(bool)) return 1;
            if (propertyInfo.PropertyType == typeof(int)) return 4;
            if (propertyInfo.PropertyType == typeof(long)) return 8;
            if (propertyInfo.PropertyType == typeof(decimal)) return 24;
            if (propertyInfo.PropertyType == typeof(DateTime)) return 8;
            if (propertyInfo.PropertyType == typeof(string))
            {
                return propertyInfo.GetCustomAttribute<FieldLengthAttribute>()?.Length
                       ?? throw new MissingCodeException(
                           $"Table '{TableName}' Field '{propertyInfo.Name}' must have FieldLengthAttribute");
            }
            throw new RuntimeException(
                $"Table '{TableName}' Field '{propertyInfo.Name}' has an unsupported Type for mutable Fields: {propertyInfo.PropertyType}");
        }
    }
}
