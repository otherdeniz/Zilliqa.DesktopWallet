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
        private Dictionary<string, ZilligraphFieldIndex>? _fieldIndexes;

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

        public Dictionary<string, ZilligraphFieldIndex> FieldIndexes => _fieldIndexes ??=  GetFieldIndexes();

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

        public IEnumerable<TRecordModel> FindRecords(IFilterQuery queryFilter)
        {
            return FindRecordsInternal(queryFilter);
        }

        IEnumerable IZilligraphTable.FindRecords(IFilterQuery queryFilter)
        {
            return FindRecordsInternal(queryFilter);
        }

        private IEnumerable<TRecordModel> FindRecordsInternal(IFilterQuery queryFilter)
        {
            return new RecordsResultEnumerable<TRecordModel>(this,
                FilterSearcherFactory.CreateFilterSearcher(this, queryFilter));
        }

        public TRecordModel ReadRecord(ulong recordPoint)
        {
            var dataFile = GetLastDataFile();
            var rowBinary = dataFile.Read(recordPoint);
            return rowBinary.DecompressRowObject<TRecordModel>();
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

        private Dictionary<string, ZilligraphFieldIndex> GetFieldIndexes()
        {
            var indexes = new Dictionary<string, ZilligraphFieldIndex>();

            foreach (var propertyInfo in RecordType.GetProperties())
            {
                if (propertyInfo.GetCustomAttribute(typeof(SchemaIndexAttribute)) is SchemaIndexAttribute)
                {
                    indexes.Add(propertyInfo.Name, new ZilligraphFieldIndex(this, propertyInfo.Name));
                }
            }

            return indexes;
        }

    }
}
