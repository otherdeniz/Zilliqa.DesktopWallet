using Zillifriends.Shared.Common;
using Zilligraph.Database.Storage.FilterQuery;
using Zilligraph.Database.Storage.StorageModel;
using Zilligraph.Database.Storage.StorageModel.DataStructure;

// ReSharper disable InconsistentlySynchronizedField

namespace Zilligraph.Database.Storage
{
    public class ZilligraphTable<TRecordModel> : IZilligraphTable, IDisposable where TRecordModel : class, new()
    {
        private readonly string _tableName;
        private readonly string _storagePath;
        private readonly List<DataFile> _dataFiles = new();
        private TableInfo? _tableInfo;

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

        public DataPathBuilder PathBuilder { get; }

        public TableInfo TableInfo => _tableInfo ??= TableInfo.Load(this);

        public void AddRecord(TRecordModel record)
        {
            var dataFile = GetLastDataFile();

            var rowBinary = StorageTableRowBinary.CreateNew(record);
            dataFile.Append(rowBinary);
        }

        public TRecordModel GetRecord(long recordIndex)
        {
            throw new NotImplementedException("nid fertig :P");
        }

        public List<TRecordModel> FindRecords(IFilterQuery queryFilter)
        {
            throw new NotImplementedException("nid fertig :P");
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
    }
}
