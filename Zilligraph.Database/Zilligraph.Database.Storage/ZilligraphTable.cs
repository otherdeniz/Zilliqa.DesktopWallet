using System.Collections;
using System.Reflection;
using Zillifriends.Shared.Common;
using Zilligraph.Database.Definition;
using Zilligraph.Database.Storage.FilterQuery;
using Zilligraph.Database.Storage.Index;
using Zilligraph.Database.Storage.Table;

// ReSharper disable InconsistentlySynchronizedField

namespace Zilligraph.Database.Storage
{
    public class ZilligraphTable<TRecordModel> : IZilligraphTable where TRecordModel : class, new()
    {
        private readonly string _tableName;
        private readonly string _storagePath;
        private readonly List<DataFile> _dataFiles = new();
        private TableInfo? _tableInfo;
        private Type? _recordType;
        private Dictionary<string, ZilligraphTableFieldIndex>? _fieldIndexes;
        private List<ZilligraphTableFieldReference>? _fieldReferences;

        public ZilligraphTable(ZilligraphDatabase database)
        {
            Database = database;
            _tableName = typeof(TRecordModel).Name;
            _storagePath = Path.Combine(database.DatabasePath, _tableName);
            if (!Directory.Exists(_storagePath))
            {
                Directory.CreateDirectory(_storagePath);
            }

            PathBuilder = new DataPathBuilder(_storagePath);
        }

        public ZilligraphDatabase Database { get; }

        public string TableName => _tableName;

        public string StoragePath => _storagePath;

        public Type RecordType => _recordType ??= typeof(TRecordModel);

        public DataPathBuilder PathBuilder { get; }

        public TableInfo TableInfo => _tableInfo ??= TableInfo.Load(this);

        public Dictionary<string, ZilligraphTableFieldIndex> FieldIndexes => _fieldIndexes ??=  GetFieldIndexes();

        public List<ZilligraphTableFieldReference> FieldReferences => _fieldReferences ??= GetFieldReferences();

        public void AddRecord(TRecordModel record)
        {
            AddRecordInternal(record);
        }

        void IZilligraphTable.AddRecord(object record)
        {
            AddRecordInternal(record);
        }

        private void AddRecordInternal(object record)
        {
            var dataFile = GetLastDataFile();

            var rowBinary = DataRowBinary.CreateNew(record);
            var recordPoint = dataFile.Append(rowBinary);
            foreach (var fieldIndex in FieldIndexes)
            {
                fieldIndex.Value.AddRecordIndex(recordPoint, record);
            }
            Database.DbSizeChanged();
        }

        public TRecordModel? FindRecord(string propertyName, object value, bool resolveReferences = true)
        {
            return FindRecordInternal(propertyName, value, resolveReferences);
        }

        object? IZilligraphTable.FindRecord(string propertyName, object value, bool resolveReferences)
        {
            return FindRecordInternal(propertyName, value, resolveReferences);
        }

        private TRecordModel? FindRecordInternal(string propertyName, object value, bool resolveReferences)
        {
            if (FieldIndexes.TryGetValue(propertyName, out var fieldIndex))
            {
                var recordIndex = fieldIndex.GetFirstIndex(value);
                if (recordIndex != null)
                {
                    return ReadRecord(recordIndex.RecordPoint);
                }
            }

            return null;
        }

        public IEnumerable<TRecordModel> FindRecords(IFilterQuery queryFilter, Func<TRecordModel, bool>? additionalFilter = null, bool resolveReferences = true)
        {
            return FindRecordsInternal(queryFilter, additionalFilter, resolveReferences);
        }

        IEnumerable IZilligraphTable.FindRecords(IFilterQuery queryFilter, bool resolveReferences)
        {
            return FindRecordsInternal(queryFilter, null, resolveReferences);
        }

        private IEnumerable<TRecordModel> FindRecordsInternal(IFilterQuery queryFilter, Func<TRecordModel, bool>? additionalFilter, bool resolveReferences)
        {
            return new RecordsResultEnumerable<TRecordModel>(this,
                FilterSearcherFactory.CreateFilterSearcher(this, queryFilter),
                additionalFilter,
                resolveReferences);
        }

        object IZilligraphTable.ReadRecord(ulong recordPoint, bool resolveReferences)
        {
            return ReadRecordInternal(recordPoint, resolveReferences);
        }

        public TRecordModel ReadRecord(ulong recordPoint, bool resolveReferences = true)
        {
            return ReadRecordInternal(recordPoint, resolveReferences);
        }

        private TRecordModel ReadRecordInternal(ulong recordPoint, bool resolveReferences)
        {
            var dataFile = GetLastDataFile();
            var rowBinary = dataFile.Read(recordPoint);
            var record = rowBinary.DecompressRowObject<TRecordModel>();
            if (resolveReferences)
            {
                AttachReferenceProxies(record);
            }
            return record;
        }

        public void Dispose()
        {
            if (_dataFiles.Any())
            {
                lock (_dataFiles)
                {
                    foreach (var dataFile in _dataFiles)
                    {
                        dataFile.Dispose();
                    }
                    _dataFiles.Clear();
                }
            }
        }

        private void AttachReferenceProxies(TRecordModel record)
        {
            foreach (var fieldReference in FieldReferences)
            {
                var resolverType = typeof(LazyReferenceResolver<>).MakeGenericType(fieldReference.ForeignType);
                // LazyReferenceResolver constructor arguments:
                // (object parent, PropertyInfo parentKeyProperty, IZilligraphTable foreignTable, string foreignKey)
                var resolverInstance = Activator.CreateInstance(resolverType,
                    new object?[] 
                    { 
                        record, 
                        fieldReference.KeyPropertyInfo,
                        Database.GetTable(fieldReference.ForeignType),
                        fieldReference.ForeignKey
                    });
                fieldReference.ReferencePropertyInfo.SetValue(record, resolverInstance);
            }
        }

        private DataFile GetLastDataFile()
        {
            if (_dataFiles.Any())
            {
                return _dataFiles.Last();
            }

            lock (_dataFiles)
            {
                if (_dataFiles.Any())
                {
                    return _dataFiles.Last();
                }

                var dataFile = new DataFile(this, 1);
                _dataFiles.Add(dataFile);

                TableInfo.DataFileCount = 1;
                TableInfo.Save();

                return dataFile;
            }
        }

        private Dictionary<string, ZilligraphTableFieldIndex> GetFieldIndexes()
        {
            //TODO: do recursive
            var indexes = new Dictionary<string, ZilligraphTableFieldIndex>();

            foreach (var propertyInfo in RecordType.GetProperties())
            {
                if (propertyInfo.GetCustomAttribute(typeof(SchemaIndexAttribute)) is SchemaIndexAttribute)
                {
                    indexes.Add(propertyInfo.Name, new ZilligraphTableFieldIndex(this, propertyInfo.Name));
                }
            }

            return indexes;
        }

        private List<ZilligraphTableFieldReference> GetFieldReferences()
        {
            //TODO: do recursive
            var list = new List<ZilligraphTableFieldReference>();

            foreach (var propertyInfo in RecordType.GetProperties())
            {
                if (propertyInfo.GetCustomAttribute(typeof(SchemaReferenceAttribute)) is SchemaReferenceAttribute attribute)
                {
                    list.Add(new ZilligraphTableFieldReference(this, propertyInfo.Name, attribute.KeyProperty,
                        attribute.ForeignType, attribute.ForeignKeyProperty));
                }
            }

            return list;
        }
    }
}
