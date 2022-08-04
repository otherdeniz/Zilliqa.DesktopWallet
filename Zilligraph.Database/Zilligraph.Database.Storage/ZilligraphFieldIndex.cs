using System.Reflection;
using Zillifriends.Shared.Common;
using Zilligraph.Database.Storage.Index;

namespace Zilligraph.Database.Storage
{
    public class ZilligraphFieldIndex
    {
        private readonly PropertyInfo _propertyInfo;
        private IndexHeadSingleFile? _indexHeadFile;

        public ZilligraphFieldIndex(IZilligraphTable table, string propertyName)
        {
            Table = table;
            PropertyName = propertyName;
            _propertyInfo = Table.RecordType.GetProperty(propertyName) ??
                            throw new MissingCodeException(
                                $"Property {propertyName} not found on Type {Table.RecordType.FullName}");
        }

        public IZilligraphTable Table { get; }

        public string PropertyName { get; }

        public Type PropertyType => _propertyInfo.PropertyType;
    }

}
