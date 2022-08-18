using System.Reflection;
using Zillifriends.Shared.Common;

namespace Zilligraph.Database.Storage
{
    public class ZilligraphTableFieldReference
    {
        private PropertyInfo? _keyPropertyInfo;

        public ZilligraphTableFieldReference(IZilligraphTable table,
            PropertyInfo referencePropertyInfo, 
            string keyPropertyName,
            Type foreignType,
            string foreignKey,
            bool isLazy)
        {
            Table = table;
            ReferencePropertyInfo = referencePropertyInfo;
            KeyPropertyName = keyPropertyName;
            ForeignType = foreignType;
            ForeignKey = foreignKey;
            IsLazy = isLazy;
        }

        public IZilligraphTable Table { get; }

        public PropertyInfo ReferencePropertyInfo { get; }

        public string KeyPropertyName { get; }

        public PropertyInfo KeyPropertyInfo =>
            _keyPropertyInfo ??= Table.RecordType.GetProperty(KeyPropertyName)
                                 ?? throw new RuntimeException(
                                     $"Key Property '{KeyPropertyName}' not found on Type '{Table.RecordType.FullName}'");

        public Type ForeignType { get; }

        public string ForeignKey { get; }

        public bool IsLazy { get; }
    }
}
