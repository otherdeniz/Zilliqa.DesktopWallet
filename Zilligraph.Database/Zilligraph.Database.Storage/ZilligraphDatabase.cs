
// ReSharper disable InconsistentlySynchronizedField

namespace Zilligraph.Database.Storage
{
    public class ZilligraphDatabase
    {
        private readonly Dictionary<Type, object> _tables = new();

        public string DatabasePath { get; }

        public ZilligraphDatabase(string databasePath)
        {
            DatabasePath = databasePath;
            if (!Directory.Exists(databasePath))
            {
                Directory.CreateDirectory(databasePath);
            }
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
    }
}
