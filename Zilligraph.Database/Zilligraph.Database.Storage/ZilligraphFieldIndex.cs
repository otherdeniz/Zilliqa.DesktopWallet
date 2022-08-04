using System.Reflection;
using Zillifriends.Shared.Common;
using Zilligraph.Database.Storage.Index;

namespace Zilligraph.Database.Storage
{
    public class ZilligraphFieldIndex
    {
        private readonly PropertyInfo _propertyInfo;
        private readonly Type _propertyType;
        private readonly IndexTypeInfoBase _indexTypeInfo;
        private IndexHeadSingleFile? _indexHeadFile;

        public ZilligraphFieldIndex(IZilligraphTable table, string propertyName)
        {
            Table = table;
            PropertyName = propertyName;
            _propertyInfo = Table.RecordType.GetProperty(propertyName) ??
                            throw new MissingCodeException(
                                $"Property {propertyName} not found on Type {Table.RecordType.FullName}");
            _propertyType = _propertyInfo.PropertyType;
            _indexTypeInfo = IndexTypeInfoBase.Create(_propertyType);
        }

        public IZilligraphTable Table { get; }

        public string PropertyName { get; }

        public Type PropertyType => _propertyType;

        public IndexTypeInfoBase IndexTypeInfo => _indexTypeInfo;
    }

}
