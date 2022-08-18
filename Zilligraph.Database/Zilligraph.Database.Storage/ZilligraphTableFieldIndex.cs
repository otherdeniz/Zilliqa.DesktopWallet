using System.Reflection;
using Zillifriends.Shared.Common;
using Zilligraph.Database.Storage.Index;

namespace Zilligraph.Database.Storage
{
    public class ZilligraphTableFieldIndex
    {
        private readonly PropertyInfo _propertyInfo;
        private readonly Type _propertyType;
        private readonly IndexTypeInfoBase _indexTypeInfo;
        private readonly IndexHeadSingleFile _indexHeadFile;
        private readonly IndexContentFile _indexContentFile;

        internal ZilligraphTableFieldIndex(IZilligraphTable table, string propertyName)
        {
            Table = table;
            PropertyName = propertyName;
            _propertyInfo = Table.RecordType.GetProperty(propertyName) ??
                            throw new MissingCodeException(
                                $"Property {propertyName} not found on Type {Table.RecordType.FullName}");
            _propertyType = _propertyInfo.PropertyType;
            _indexTypeInfo = IndexTypeInfoBase.Create(_propertyType);
            _indexHeadFile = new IndexHeadSingleFile(this);
            _indexContentFile = new IndexContentFile(this, _indexTypeInfo.HashLength);
        }

        public IZilligraphTable Table { get; }

        public string PropertyName { get; }

        public Type PropertyType => _propertyType;

        public IndexTypeInfoBase IndexTypeInfo => _indexTypeInfo;

        public void AddRecordIndex(ulong recordPoint, object record)
        {
            var propertyValue = _propertyInfo.GetValue(record);
            var hashBytes = IndexTypeInfo.GetHashBytes(propertyValue);
            var hashPrefix16Bit = BitConverter.ToUInt16(hashBytes, 0);
            var indexChainEntry = _indexHeadFile.GetIndexPoint(hashPrefix16Bit);
            if (indexChainEntry == 0)
            {
                indexChainEntry = _indexContentFile.CreateChain(hashBytes, recordPoint);
                _indexHeadFile.SetIndexPoint(hashPrefix16Bit, indexChainEntry);
            }
            else
            {
                _indexContentFile.AppendToChain(indexChainEntry, hashBytes, recordPoint);
            }
        }

        public IndexRecord? GetFirstIndex(object propertyValue)
        {
            var hashBytes = IndexTypeInfo.GetHashBytes(propertyValue);
            var hashPrefix16Bit = BitConverter.ToUInt16(hashBytes, 0);
            var indexChainEntry = _indexHeadFile.GetIndexPoint(hashPrefix16Bit);
            if (indexChainEntry == 0)
            {
                return null;
            }

            return _indexContentFile.GetFirstIndex(indexChainEntry, hashBytes);
        }

        public IEnumerable<IndexRecord> SearchIndexes(object? propertyValue)
        {
            var hashBytes = IndexTypeInfo.GetHashBytes(propertyValue);
            var hashPrefix16Bit = BitConverter.ToUInt16(hashBytes, 0);
            var indexChainEntry = _indexHeadFile.GetIndexPoint(hashPrefix16Bit);
            if (indexChainEntry == 0)
            {
                return Enumerable.Empty<IndexRecord>();
            }

            return _indexContentFile.EnumerateIndexes(indexChainEntry, hashBytes);
        }
    }

}
