
// ReSharper disable InconsistentlySynchronizedField

using Zillifriends.Shared.Common;

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
            var dbSize = _dbSize;
            if (dbSize == null)
            {
                dbSize = 0;
                foreach (var directory in Directory.GetDirectories(DatabasePath))
                {
                    foreach (var file in Directory.GetFiles(directory))
                    {
                        var fileInfo = new FileInfo(file);
                        dbSize += fileInfo.Length;
                    }
                }
            }

            _dbSize = dbSize;
            return dbSize.GetValueOrDefault();
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
                table.EnsureInitialised(false);
                _tables.Add(modelType, table);
                return table;
            }
        }

        public IZilligraphTable GetTable(Type recordType)
        {
            if (_tables.ContainsKey(recordType))
            {
                return _tables[recordType];
            }

            lock (_tables)
            {
                if (_tables.ContainsKey(recordType))
                {
                    return _tables[recordType];
                }

                var tableType = typeof(ZilligraphTable<>).MakeGenericType(new Type[] { recordType });
                if (Activator.CreateInstance(tableType, new object?[] { this }) is IZilligraphTable table)
                {
                    _tables.Add(recordType, table);
                    return table;
                }

                throw new RuntimeException($"ZilligraphTable instance of Type '{tableType}' generation failed");
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
