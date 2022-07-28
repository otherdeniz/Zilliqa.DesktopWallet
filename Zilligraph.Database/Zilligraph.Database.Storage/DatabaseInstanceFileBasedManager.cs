using System.Runtime.CompilerServices;

namespace Zilligraph.Database.Storage
{
    public class DatabaseInstanceFileBasedManager
    {
        private readonly string _databasePath;

        /// <summary>
        /// creates the root object to access a DB.
        /// </summary>
        /// <param name="storageFolder">a local path where the files are stored</param>
        /// <param name="key">the unique key of this DB, could be a publickey or a guid or any unique string</param>
        public DatabaseInstanceFileBasedManager(string storageFolder, string key)
        {
            if (!Directory.Exists(storageFolder))
            {
                Directory.CreateDirectory(storageFolder);
            }

            _databasePath = Path.Combine(storageFolder, key);
            if (!Directory.Exists(_databasePath))
            {
                Directory.CreateDirectory(_databasePath);
            }

        }

        public DatabaseInstanceRepository<TRecordModel> LoadRepository<TRecordModel>() where TRecordModel : class, new()
        {
            var dataStream = GetFileStream("data");
            var indexStream = GetFileStream("index");
            var metaStream = GetFileStream("info");
            return new DatabaseInstanceRepository<TRecordModel>(dataStream, indexStream, metaStream);
        }

        private Stream GetFileStream(string fileType)
        {
            var filePath = Path.Combine(_databasePath, $"{fileType}.db");
            return File.Open(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
        }
    }
}
