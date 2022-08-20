using System.Collections;
using System.Reflection;
using Zillifriends.Shared.Common;
using Zilligraph.Database.Contract;
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
        private Dictionary<string, ZilligraphTableIndexBase>? _indexes;
        private List<ZilligraphTableFieldReference>? _fieldReferences;
        private bool _initialisationCompleted;
        private readonly object _initialisationLock = new();
        private readonly object _transactionLock = new();

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

        public ZilligraphTransaction? CurrenTransaction { get; internal set; }

        public Dictionary<string, ZilligraphTableIndexBase> Indexes => _indexes ??=  GetIndexes();

        public List<ZilligraphTableFieldReference> FieldReferences => _fieldReferences ??= GetFieldReferences();

        public void EnsureInitialised(bool wait)
        {
            if (_initialisationCompleted)
            {
                return;
            }

            if (wait)
            {
                Initialise();
            }
            else
            {
                Task.Run(Initialise);
            }
        }

        private void Initialise()
        {
            lock (_initialisationLock)
            {
                if (_initialisationCompleted)
                {
                    return;
                }

                if (_dataFiles.Any(d => d.HasRows))
                {
                    // upgrade TableInfo
                    if (TableInfo.DataFileInfos.Count == 0)
                    {
                        var recordCount = _dataFiles[0].AllRows().Count();

                        TableInfo.DataFileInfos.Add(new TableInfo.DataFileInfo
                        {
                            FirstRecordNumber = 1,
                            LastRecordNumber = recordCount
                        });
                    }

                    // add new Indexes
                    var newIndexes = Indexes.Select(i => i.Value).Where(i => !i.IndexExists).ToList();
                    if (newIndexes.Any())
                    {
                        foreach (var row in _dataFiles[0].AllRows())
                        {
                            var record = row.DecompressRowObject<TRecordModel>();
                            foreach (var index in newIndexes)
                            {
                                index.AddRecordIndex(Convert.ToUInt64(row.RowPosition + 1), record);
                            }
                        }
                    }
                }

                _initialisationCompleted = true;
            }
        }

        public bool CreateTransaction(bool waitForFree)
        {
            EnsureInitialised(true);
            if (CurrenTransaction != null)
            {
                if (!waitForFree)
                {
                    return false;
                }

                do
                {
                    Task.Run(async () => await Task.Delay(25)).GetAwaiter().GetResult();
                } while (CurrenTransaction != null);
            }

            //lock (_transactionLock)
            //{

            //}
            CurrenTransaction = new ZilligraphTransaction(this);
            return true;
        }


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
            EnsureInitialised(true);
            var dataFile = GetLastDataFile();

            var rowBinary = DataRowBinary.CreateNew(record);
            var recordPoint = dataFile.Append(rowBinary);
            foreach (var fieldIndex in Indexes)
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
            if (Indexes.TryGetValue(propertyName, out var fieldIndex))
            {
                var recordIndex = fieldIndex.GetFirstIndex(value);
                if (recordIndex != null)
                {
                    return ReadRecord(recordIndex.RecordPoint, resolveReferences);
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
                ResolveReferences(record);
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

        private void ResolveReferences(TRecordModel record)
        {
            foreach (var fieldReference in FieldReferences)
            {
                var foreignTable = Database.GetTable(fieldReference.ForeignType);
                if (fieldReference.IsLazy)
                {
                    var resolverType = typeof(LazyReferenceResolver<>).MakeGenericType(fieldReference.ForeignType);
                    // LazyReferenceResolver constructor arguments:
                    // (object parent, PropertyInfo parentKeyProperty, IZilligraphTable foreignTable, string foreignKey)
                    var resolverInstance = Activator.CreateInstance(resolverType,
                        new object?[]
                        {
                            record,
                            fieldReference.KeyPropertyInfo,
                            foreignTable,
                            fieldReference.ForeignKey
                        });
                    fieldReference.ReferencePropertyInfo.SetValue(record, resolverInstance);
                }
                else
                {
                    var keyValue = fieldReference.KeyPropertyInfo.GetValue(record);
                    if (keyValue != null)
                    {
                        var foreignRecord = foreignTable.FindRecord(fieldReference.ForeignKey, keyValue);
                        fieldReference.ReferencePropertyInfo.SetValue(record, foreignRecord);
                    }
                }
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

        private Dictionary<string, ZilligraphTableIndexBase> GetIndexes()
        {
            var indexes = new Dictionary<string, ZilligraphTableIndexBase>();

            foreach (var propertyInfo in RecordType.GetProperties())
            {
                if (propertyInfo.GetCustomAttribute(typeof(SchemaIndexAttribute)) is SchemaIndexAttribute)
                {
                    indexes.Add(propertyInfo.Name, new ZilligraphTableFieldIndex(this, propertyInfo.Name));
                }
            }
            foreach (var customAttribute in RecordType.GetCustomAttributes(typeof(CalculatedIndexAttribute)))
            {
                if (customAttribute is CalculatedIndexAttribute calculatedIndexAttribute)
                {
                    indexes.Add(calculatedIndexAttribute.IndexName, new ZilligraphTableCalculatedIndex(this, calculatedIndexAttribute.IndexName, calculatedIndexAttribute.IndexCalculator));
                }
            }
            return indexes;
        }

        private List<ZilligraphTableFieldReference> GetFieldReferences()
        {
            var list = new List<ZilligraphTableFieldReference>();

            foreach (var propertyInfo in RecordType.GetProperties())
            {
                if (propertyInfo.GetCustomAttribute(typeof(SchemaReferenceAttribute)) is SchemaReferenceAttribute attribute)
                {
                    var foreignType = propertyInfo.PropertyType;
                    var isLazy = false;
                    if (propertyInfo.PropertyType.IsGenericType
                        && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(LazyReference<>))
                    {
                        foreignType = propertyInfo.PropertyType.GetGenericArguments().First();
                        isLazy = true;
                    }
                    list.Add(new ZilligraphTableFieldReference(this, propertyInfo, attribute.KeyProperty,
                        foreignType, attribute.ForeignKeyProperty, isLazy));
                }
            }

            return list;
        }
    }
}
