
// ReSharper disable InconsistentlySynchronizedField

using System.Reflection;
using System.Runtime.Caching;
using Zillifriends.Shared.Common;
using Zilligraph.Database.Contract;

namespace Zilligraph.Database.Storage
{
    public class ZilligraphDatabase : IDisposable
    {
        private readonly MemoryCache _directorySizeCache = new MemoryCache("Database");
        private readonly Dictionary<Type, IZilligraphTable> _tables = new();
        //private readonly Dictionary<Type, IZilligraphTable> _mutableTables = new();

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

                    foreach (var subDirectory in Directory.GetDirectories(directory))
                    {
                        var subDirectorySize = _directorySizeCache.GetOrAdd(subDirectory, TimeSpan.FromMinutes(15), () =>
                        {
                            long subDirSize = 0;
                            foreach (var file in Directory.GetFiles(subDirectory))
                            {
                                var fileInfo = new FileInfo(file);
                                subDirSize += fileInfo.Length;
                            }
                            return subDirSize;
                        });
                        dbSize += subDirectorySize;
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

        //public ZilligraphMutableTable<TRecordModel> GetMutableTable<TRecordModel>() where TRecordModel : class, new()
        //{
        //    var modelType = typeof(TRecordModel);
        //    if (_mutableTables.ContainsKey(modelType))
        //    {
        //        return (ZilligraphMutableTable<TRecordModel>)_mutableTables[modelType];
        //    }

        //    lock (_mutableTables)
        //    {
        //        if (_mutableTables.ContainsKey(modelType))
        //        {
        //            return (ZilligraphMutableTable<TRecordModel>)_mutableTables[modelType];
        //        }

        //        if (GetTableModelKind(modelType) != TableKind.Mutable)
        //        {
        //            throw new RuntimeException($"ZilligraphTable '{modelType}' must have TableModelAttribute with TableKind 'Mutable'");
        //        }
        //        var table = new ZilligraphMutableTable<TRecordModel>(this);
        //        _mutableTables.Add(modelType, table);
        //        return table;
        //    }
        //}

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

                var tableKind = GetTableModelKind(modelType);
                if (tableKind == TableKind.NotMutable)
                {
                    var table = new ZilligraphTable<TRecordModel>(this);
                    //TODO: move starts of table.EnsureInitialised to Database...
                    //table.EnsureInitialised(false);
                    _tables.Add(modelType, table);
                    return table;
                }
                if (tableKind == TableKind.Mutable)
                {
                    var table = new ZilligraphMutableTable<TRecordModel>(this);
                    _tables.Add(modelType, table);
                    return table;
                }

                throw new RuntimeException($"ZilligraphTable '{modelType}' must have TableModelAttribute");
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

                var tableKind = GetTableModelKind(recordType);
                if (tableKind == TableKind.NotMutable)
                {
                    var tableType = typeof(ZilligraphTable<>).MakeGenericType(new Type[] { recordType });
                    var table = (IZilligraphTable)Activator.CreateInstance(tableType, new object?[] { this })!;
                    _tables.Add(recordType, table);
                    return table;
                }
                if (tableKind == TableKind.Mutable)
                {
                    var tableType = typeof(ZilligraphMutableTable<>).MakeGenericType(new Type[] { recordType });
                    var table = (IZilligraphTable)Activator.CreateInstance(tableType, new object?[] { this })!;
                    _tables.Add(recordType, table);
                    return table;
                }
                throw new RuntimeException($"ZilligraphTable '{recordType}' must have TableModelAttribute");
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

        private static TableKind? GetTableModelKind(Type tableType)
        {
            var attribute = tableType.GetCustomAttribute<TableModelAttribute>(false);
            return attribute?.TableKind;
        }
    }
}
