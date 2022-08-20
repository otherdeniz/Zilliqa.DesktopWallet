﻿using Zilligraph.Database.Storage.Index;

namespace Zilligraph.Database.Storage
{
    public abstract class ZilligraphTableIndexBase
    {
        private IndexTypeInfoBase? _indexTypeInfo;
        private IndexHeadSingleFile? _indexHeadFile;
        private IndexContentFile? _indexContentFile;
        private bool? _indexExists;

        protected ZilligraphTableIndexBase(IZilligraphTable table, string name)
        {
            Table = table;
            Name = name;
        }

        public IZilligraphTable Table { get; }

        public string Name { get; }

        public abstract Type ValueType { get; }

        public IndexTypeInfoBase IndexTypeInfo => _indexTypeInfo ??= IndexTypeInfoBase.Create(ValueType);

        public bool IndexExists => _indexExists ??= IndexHeadFile.FileExists();

        protected IndexHeadSingleFile IndexHeadFile => _indexHeadFile ??= new IndexHeadSingleFile(this);

        protected IndexContentFile IndexContentFile =>
            _indexContentFile ??= new IndexContentFile(this, IndexTypeInfo.HashLength);

        public abstract void AddRecordIndex(ulong recordPoint, object record);

        protected void AddRecordIndexValue(ulong recordPoint, object value)
        {
            var hashBytes = IndexTypeInfo.GetHashBytes(value);
            var hashPrefix16Bit = BitConverter.ToUInt16(hashBytes, 0);
            var indexChainEntry = IndexHeadFile.GetIndexPoint(hashPrefix16Bit);
            if (indexChainEntry == 0)
            {
                indexChainEntry = IndexContentFile.CreateChain(hashBytes, recordPoint);
                IndexHeadFile.SetIndexPoint(hashPrefix16Bit, indexChainEntry);
            }
            else
            {
                IndexContentFile.AppendToChain(indexChainEntry, hashBytes, recordPoint);
            }

            _indexExists = true;
        }

        public IndexRecord? GetFirstIndex(object propertyValue)
        {
            var hashBytes = IndexTypeInfo.GetHashBytes(propertyValue);
            var hashPrefix16Bit = BitConverter.ToUInt16(hashBytes, 0);
            var indexChainEntry = IndexHeadFile.GetIndexPoint(hashPrefix16Bit);
            if (indexChainEntry == 0)
            {
                return null;
            }

            return IndexContentFile.GetFirstIndex(indexChainEntry, hashBytes);
        }

        public IEnumerable<IndexRecord> SearchIndexes(object? propertyValue)
        {
            var hashBytes = IndexTypeInfo.GetHashBytes(propertyValue);
            var hashPrefix16Bit = BitConverter.ToUInt16(hashBytes, 0);
            var indexChainEntry = IndexHeadFile.GetIndexPoint(hashPrefix16Bit);
            if (indexChainEntry == 0)
            {
                return Enumerable.Empty<IndexRecord>();
            }

            return IndexContentFile.EnumerateIndexes(indexChainEntry, hashBytes);
        }
    }
}
