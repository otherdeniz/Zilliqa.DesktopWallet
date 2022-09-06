using Zillifriends.Shared.Common;
using Zilligraph.Database.Contract;
using Zilligraph.Database.Storage.Index;

namespace Zilligraph.Database.Storage
{
    public abstract class ZilligraphTableIndexBase
    {
        private IndexTypeInfoBase? _indexTypeInfo;
        private IndexHeadSingleFile? _indexHeadFile;
        private IndexContentFile? _indexContentFile;
        private readonly Dictionary<ushort, List<IndexContentPartFile>> _indexContentPartFiles = new();
        private bool? _indexExists;

        protected ZilligraphTableIndexBase(IZilligraphTable table, string name, IndexAttributeBase indexAttribute)
        {
            IndexAttribute = indexAttribute;
            Table = table;
            Name = name;
            PathBuilder = new DataPathBuilder(Path.Combine(table.StoragePath, $"Index-{name}"));
        }

        public IZilligraphTable Table { get; }

        public string Name { get; }

        public abstract Type ValueType { get; }

        public IndexTypeInfoBase IndexTypeInfo => _indexTypeInfo ??= IndexTypeInfoBase.Create(ValueType);

        public IndexAttributeBase IndexAttribute { get; }

        public DataPathBuilder PathBuilder { get; }

        public bool IndexExists => _indexExists ??= IndexHeadFile.FileExists();

        protected IndexHeadSingleFile IndexHeadFile => _indexHeadFile ??= new IndexHeadSingleFile(this);

        protected IndexContentFile IndexContentFile =>
            _indexContentFile ??= new IndexContentFile(this, IndexTypeInfo.HashLength);

        public void StartBulkInsert()
        {
            IndexContentFile.StartBulkInsert();
        }

        public void EndBulkInsert()
        {
            IndexContentFile.EndBulkInsert();
        }

        public abstract void AddRecordIndex(ulong recordPoint, object record);

        protected void AddRecordIndexValue(ulong recordPoint, object value)
        {
            var hashBytes = IndexTypeInfo.GetHashBytes(value);
            var hashPrefix16Bit = BitConverter.ToUInt16(hashBytes, 0);
            var indexChainEntry = IndexAttribute.LowDistinctOptimization
                ? ulong.MaxValue
                : IndexHeadFile.GetIndexPoint(hashPrefix16Bit);
            if (indexChainEntry == 0)
            {
                indexChainEntry = IndexContentFile.CreateChain(hashBytes, recordPoint);
                IndexHeadFile.SetIndexPoint(hashPrefix16Bit, indexChainEntry);
            }
            else if (indexChainEntry == ulong.MaxValue)
            {
                var partFiles = GetContentPartFiles(hashPrefix16Bit);
                byte hashPart4Bit = hashBytes[3].Byte8BitTo4Bit();
                partFiles[hashPart4Bit].Append(hashBytes, recordPoint);
            }
            else
            {
                try
                {
                    IndexContentFile.AppendToChain(indexChainEntry, hashBytes, recordPoint);
                }
                catch (IndexContentFile.UpgradeNeededException)
                {
                    var partFiles = GetContentPartFiles(hashPrefix16Bit);
                    var upgradeIndexGroups = IndexContentFile.ReadIndexesChunkt(indexChainEntry)
                        .Select(ui => (ui.IndexHash, ui.RecordPoint))
                        .GroupBy(ui => ui.IndexHash[3].Byte8BitTo4Bit());
                    foreach (var upgradeIndexGroup in upgradeIndexGroups)
                    {
                        byte upgradeHashPart4Bit = upgradeIndexGroup.Key;
                        partFiles[upgradeHashPart4Bit].Append(upgradeIndexGroup.ToList());
                    }
                    IndexHeadFile.SetIndexPoint(hashPrefix16Bit, ulong.MaxValue);
                    byte hashPart4Bit = hashBytes[3].Byte8BitTo4Bit();
                    partFiles[hashPart4Bit].Append(hashBytes, recordPoint);
                    //IndexContentFile.RemoveChain(indexChainEntry, IndexHeadFile);
                }
            }

            _indexExists = true;
        }

        public IndexRecord? GetFirstIndex(object propertyValue)
        {
            var hashBytes = IndexTypeInfo.GetHashBytes(propertyValue);
            var hashPrefix16Bit = BitConverter.ToUInt16(hashBytes, 0);
            var indexChainEntry = IndexAttribute.LowDistinctOptimization
                ? ulong.MaxValue
                : IndexHeadFile.GetIndexPoint(hashPrefix16Bit);
            if (indexChainEntry == 0)
            {
                return null;
            }
            if (indexChainEntry == ulong.MaxValue)
            {
                var partFiles = GetContentPartFiles(hashPrefix16Bit);
                byte hashPart4Bit = hashBytes[3].Byte8BitTo4Bit();
                return partFiles[hashPart4Bit].GetFirstIndex(hashBytes);
            }
            return IndexContentFile.GetFirstIndex(indexChainEntry, hashBytes);
        }

        public IEnumerable<IndexRecord> SearchIndexes(object? propertyValue)
        {
            var hashBytes = IndexTypeInfo.GetHashBytes(propertyValue);
            var hashPrefix16Bit = BitConverter.ToUInt16(hashBytes, 0);
            var indexChainEntry = IndexAttribute.LowDistinctOptimization
                ? ulong.MaxValue
                : IndexHeadFile.GetIndexPoint(hashPrefix16Bit);
            if (indexChainEntry == 0)
            {
                return Enumerable.Empty<IndexRecord>();
            }
            if (indexChainEntry == ulong.MaxValue)
            {
                var partFiles = GetContentPartFiles(hashPrefix16Bit);
                byte hashPart4Bit = hashBytes[3].Byte8BitTo4Bit();
                return partFiles[hashPart4Bit].EnumerateIndexes(hashBytes);
            }
            return IndexContentFile.EnumerateIndexes(indexChainEntry, hashBytes);
        }

        private List<IndexContentPartFile> GetContentPartFiles(ushort hashPrefix16Bit)
        {
            // ReSharper disable once InconsistentlySynchronizedField
            if (_indexContentPartFiles.TryGetValue(hashPrefix16Bit, out var existing))
            {
                return existing;
            }

            lock (_indexContentPartFiles)
            {
                if (_indexContentPartFiles.TryGetValue(hashPrefix16Bit, out var allreadyCreated))
                {
                    return allreadyCreated;
                }

                var partFiles = new List<IndexContentPartFile>();
                for (byte i = 0; i < 16; i++)
                {
                    partFiles.Add(new IndexContentPartFile(this, IndexTypeInfo.HashLength, hashPrefix16Bit, i));
                }
                _indexContentPartFiles.Add(hashPrefix16Bit, partFiles);
                return partFiles;
            }
        }
    }
}
