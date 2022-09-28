using System.Collections;
using System.Diagnostics;
using System.Reflection;
using Zillifriends.Shared.Common;
using Zilligraph.Database.Contract;
using Zilligraph.Database.Storage.FilterQuery;
using Zilligraph.Database.Storage.Index;
using Zilligraph.Database.Storage.Result;
using Zilligraph.Database.Storage.Table;

// ReSharper disable InconsistentlySynchronizedField

namespace Zilligraph.Database.Storage
{
    public class ZilligraphTable<TRecordModel> : IZilligraphTable where TRecordModel : class, new()
    {
        private readonly string _tableName;
        private readonly string _storagePath;
        private List<DataFile>? _compressedDataFiles;
        private TableInfoFile? _tableInfo;
        private Type? _recordType;
        private Dictionary<string, ZilligraphTableIndexBase>? _indexes;
        private List<ZilligraphTableFieldReference>? _fieldReferences;
        private readonly List<ZilligraphTableEventNotificator<TRecordModel>> _eventNotificators = new();
        private readonly CancellationTokenSource _initialisationCancellationTokenSource = new();
        private bool _initialisationStarted;
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

        public long RecordCount => TableInfo.DataFileInfos.Count == 0
            ? 0
            : TableInfo.DataFileInfos.Sum(i => i.LastRecordNumber - i.FirstRecordNumber + 1);

        public DataPathBuilder PathBuilder { get; }

        public TableInfoFile TableInfo => _tableInfo ??= TableInfoFile.Load(this);

        public ZilligraphTransaction? CurrenTransaction { get; internal set; }

        public Dictionary<string, ZilligraphTableIndexBase> Indexes => _indexes ??=  GetIndexes();

        public List<ZilligraphTableFieldReference> FieldReferences => _fieldReferences ??= GetFieldReferences();

        public virtual List<DataFile> CompressedDataFiles => _compressedDataFiles ??= LoadDataFiles();

        public bool InitialisationCompleted => _initialisationCompleted;

        public decimal InitialisationCompletedPercent { get; private set; }

        public void StartBulkOperation()
        {
            CompressedDataFiles.ForEach(d => d.StartBulkOperation());
            Indexes.ForEach(i => i.Value.StartBulkInsert());
        }

        public void EndBulkOperation()
        {
            CompressedDataFiles.ForEach(d => d.EndBulkOperation());
            Indexes.ForEach(i => i.Value.EndBulkInsert());
        }

        public void EnsureInitialisationIsStarted()
        {
            if (_initialisationStarted) return;
            lock (_initialisationLock)
            {
                if (_initialisationStarted) return;
                _initialisationStarted = true;
                Task.Run(() => Initialise(_initialisationCancellationTokenSource.Token));
            }
        }

        private void Initialise(CancellationToken cancellationToken)
        {
            if (CompressedDataFiles[0].HasRows)
            {
                try
                {
                    // delete outdated indexes to upgrade
                    Indexes.Select(i => i.Value).Where(i => !i.IndexStateIsValid()).ForEach(i => i.DeleteIndex());

                    // add new Indexes / recreate indexes to upgrade
                    var newIndexes = Indexes.Select(i => i.Value).Where(i => !i.IndexExists).ToList();
                    if (newIndexes.Any())
                    {
                        foreach (var index in newIndexes)
                        {
                            index.StartBulkInsert();
                        }

                        try
                        {
                            decimal recordCount = RecordCount;
                            decimal recordNumber = 0;
                            foreach (var row in CompressedDataFiles[0].AllRows())
                            {
                                cancellationToken.ThrowIfCancellationRequested();
                                var record = row.DecompressRowObject<TRecordModel>();
                                foreach (var index in newIndexes)
                                {
                                    index.AddRecordIndex(Convert.ToUInt64(row.RowPosition + 1), record);
                                }
                                recordNumber++;
                                if (recordCount > 0)
                                {
                                    InitialisationCompletedPercent = 100m / recordCount * recordNumber;
                                }
                            }

                            foreach (var index in newIndexes)
                            {
                                index.EndBulkInsert();
                                index.SaveIndexState();
                            }

                            Database.DbSizeChanged();
                        }
                        catch (TaskCanceledException)
                        {
                            foreach (var index in newIndexes)
                            {
                                index.EndBulkInsert();
                                index.DeleteIndex();
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"DB Init failed! {e.Message}");
                }
            }

            InitialisationCompletedPercent = 100;
            _initialisationCompleted = true;
        }

        public ZilligraphTableEventNotificator<TRecordModel> AddEventNotificator(Func<TRecordModel, bool> recordMatch,
            Action<TRecordModel> onRecordAdded)
        {
            var eventNotificator = new ZilligraphTableEventNotificator<TRecordModel>(recordMatch, onRecordAdded);
            _eventNotificators.Add(eventNotificator);
            return eventNotificator;
        }

        public void RemoveEventNotificator(ZilligraphTableEventNotificator<TRecordModel> eventNotificator)
        {
            _eventNotificators.Remove(eventNotificator);
        }

        public bool CreateTransaction(bool waitForFree)
        {
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
            AddRecordInternal((TRecordModel)record);
        }

        public virtual void UpdateRecord(object record)
        {
            throw new NotSupportedException($"The Table {TableName} is not mutable");
        }

        protected virtual void AddRecordInternal(TRecordModel record)
        {
            // save Data
            var dataFile = CompressedDataFiles.Last();
            var rowBinary = CompressedDataRowBinary.CreateNew(record);
            var recordPoint = dataFile.Append(rowBinary);

            // update indexes
            Parallel.ForEach(Indexes.Select(i => i.Value), 
                fi => fi.AddRecordIndex(recordPoint, record));

            // update meta data
            var dataFileInfo = TableInfo.DataFileInfos.Last();
            dataFileInfo.LastRecordNumber += 1;
            TableInfo.Save();

            // trigger EventNotificators
            _eventNotificators.ForEach(e =>
            {
                if (e.RecordMatch(record))
                {
                    e.OnRecordAdded.Invoke(record);
                }
            });

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

        public PagedRecordResult<TRecordModel> FindRecordsPaged(IFilterQuery? queryFilter = null,
            bool resolveReferences = true, 
            bool inverseOrder = false,
            int pageSize = 1000)
        {
            var indexSearcher = queryFilter != null
                ? FilterSearcherFactory.CreateFilterSearcher(this, queryFilter)
                : FilterSearcherFactory.CreateAllRecordsSearcher(this);
            return new PagedRecordResult<TRecordModel>(this, indexSearcher, resolveReferences, inverseOrder, pageSize);
        }

        public IEnumerable<TRecordModel> EnumerateAllRecords(bool resolveReferences = true)
        {
            foreach (var dataFile in CompressedDataFiles)
            {
                foreach (var dataRowBinary in dataFile.AllRows())
                {
                    var record = dataRowBinary.DecompressRowObject<TRecordModel>();
                    if (resolveReferences)
                    {
                        ResolveReferences(record);
                    }

                    yield return record;
                }
            }
        }

        public IList<long> GetAllRecordPositions()
        {
            //TODO support multiple dataFiles, once implemented multiple DataFiles
            return CompressedDataFiles.Last().AllRowPositions();
        }

        public IEnumerable<TRecordModel> EnumerateRecords(IFilterQuery queryFilter, Func<TRecordModel, bool>? additionalFilter = null, bool resolveReferences = true)
        {
            return EnumerateRecordsInternal(queryFilter, additionalFilter, resolveReferences);
        }

        IEnumerable IZilligraphTable.EnumerateRecords(IFilterQuery queryFilter, bool resolveReferences)
        {
            return EnumerateRecordsInternal(queryFilter, null, resolveReferences);
        }

        private IEnumerable<TRecordModel> EnumerateRecordsInternal(IFilterQuery queryFilter, Func<TRecordModel, bool>? additionalFilter, bool resolveReferences)
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
            var dataFile = CompressedDataFiles.Last();
            var rowBinary = dataFile.Read(recordPoint);
            if (rowBinary == null)
            {
                throw new RuntimeException(
                    $"Error: Table {TableName} RecordPoint {recordPoint} does not have a record");
            }
            var record = rowBinary.DecompressRowObject<TRecordModel>();
            if (resolveReferences)
            {
                ResolveReferences(record);
            }
            return record;
        }

        public virtual void Dispose()
        {
            _initialisationCancellationTokenSource.Cancel();
            _eventNotificators.Clear();
            if (_compressedDataFiles?.Any() == true)
            {
                foreach (var dataFile in _compressedDataFiles)
                {
                    dataFile.Dispose();
                }
                _compressedDataFiles = null;
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

        private List<DataFile> LoadDataFiles()
        {
            var list = new List<DataFile>
            {
                new DataFile(this, 1)
            };
            if (TableInfo.DataFileInfos.Count == 0)
            {
                TableInfo.DataFileInfos.Add(new TableInfoFile.DataFileInfo { FirstRecordNumber = 1 });
                TableInfo.Save();
            }
            return list;
        }

        private Dictionary<string, ZilligraphTableIndexBase> GetIndexes()
        {
            var indexes = new Dictionary<string, ZilligraphTableIndexBase>();

            foreach (var propertyInfo in RecordType.GetProperties())
            {
                if (propertyInfo.GetCustomAttribute(typeof(PropertyIndexAttribute)) is PropertyIndexAttribute propertyIndexAttribute)
                {
                    indexes.Add(propertyInfo.Name, new ZilligraphTableFieldIndex(this, propertyInfo, propertyIndexAttribute));
                }
            }
            foreach (var methodInfo in RecordType.GetMethods())
            {
                if (methodInfo.GetCustomAttribute(typeof(CalculatedIndexAttribute)) is CalculatedIndexAttribute calculatedIndexAttribute)
                {
                    indexes.Add(methodInfo.Name, new ZilligraphTableCalculatedIndex(this, methodInfo, calculatedIndexAttribute));
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
