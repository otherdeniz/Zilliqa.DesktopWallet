using System.Reflection;
using Zillifriends.Shared.Common;

namespace Zilligraph.Database.Storage
{
    public class ZilligraphFieldIndex
    {
        private readonly PropertyInfo _propertyInfo;

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
