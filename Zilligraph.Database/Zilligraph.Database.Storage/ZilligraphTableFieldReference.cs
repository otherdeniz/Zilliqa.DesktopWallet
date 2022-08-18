using System.Reflection;
using Zillifriends.Shared.Common;

namespace Zilligraph.Database.Storage
{
    public class ZilligraphTableFieldReference
    {
        private PropertyInfo? _keyPropertyInfo;
        private PropertyInfo? _referencePropertyInfo;

        public ZilligraphTableFieldReference(IZilligraphTable table, 
            string referencePropertyName, 
            string keyPropertyName,
            Type foreignType,
            string foreignKey)
        {
            Table = table;
            ReferencePropertyName = referencePropertyName;
            KeyPropertyName = keyPropertyName;
            ForeignType = foreignType;
            ForeignKey = foreignKey;
        }

        public IZilligraphTable Table { get; }

        public string ReferencePropertyName { get; }

        public PropertyInfo ReferencePropertyInfo =>
            _referencePropertyInfo ??= Table.RecordType.GetProperty(ReferencePropertyName)
                                       ?? throw new RuntimeException(
                                           $"Reference Property '{ReferencePropertyName}' not found on Type '{Table.RecordType.FullName}'");

        public string KeyPropertyName { get; }

        public PropertyInfo KeyPropertyInfo =>
            _keyPropertyInfo ??= Table.RecordType.GetProperty(KeyPropertyName)
                                 ?? throw new RuntimeException(
                                     $"Key Property '{KeyPropertyName}' not found on Type '{Table.RecordType.FullName}'");

        public Type ForeignType { get; }

        public string ForeignKey { get; }

    }
}
