
// ReSharper disable InconsistentlySynchronizedField

namespace Zilligraph.Database.Storage
{
    public class ZilligraphDatabase : IDisposable
    {
        private readonly Dictionary<Type, IZilligraphTable> _tables = new();

        private long? _dbSize;

        public ZilligraphDatabase(string databasePath)
        {
            DatabasePath = databasePath;
            if (!Directory.Exists(databasePath))
            {
                Directory.CreateDirectory(databasePath);
            }
        }

        public string DatabasePath { get; }

        public long GetDbSize()
        {
            if (_dbSize == null)
            {
                _dbSize = 0;
                foreach (var file in Directory.GetFiles(DatabasePath))
                {
                    var fileInfo = new FileInfo(file);
                    _dbSize += fileInfo.Length;
                }
            }

            return _dbSize.GetValueOrDefault();
        }

        internal void DbSizeChanged()
        {
            _dbSize = null;
        }

        public ZilligraphTable<TRecordModel> GetTable<TRecordModel>() where TRecordModel : class, new()
        {
            var modelType = typeof(TRecordModel);
            if (_tables.ContainsKey(modelType))
            {
                return (ZilligraphTable<TRecordModel>)_tables[modelType];
            }

            lock (_tables)
            {
                if (_tables.ContainsKey(modelType))
                {
                    return (ZilligraphTable<TRecordModel>)_tables[modelType];
                }

                var table = new ZilligraphTable<TRecordModel>(this);
                _tables.Add(modelType, table);
                return table;
            }
        }

        public void Dispose()
        {
            lock (_tables)
            {
                foreach (var keyValuePair in _tables)
                {
                    keyValuePair.Value.Dispose();
                }

                _tables.Clear();
            }
        }
    }
}
