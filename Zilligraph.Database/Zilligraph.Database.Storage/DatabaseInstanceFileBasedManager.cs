using System.Runtime.CompilerServices;

namespace Zilligraph.Database.Storage
{
    public class DatabaseInstanceFileBasedManager
    {
        private readonly string _storageFolder;
        private readonly string _key;

        /// <summary>
        /// creates the root object to access a DB.
        /// </summary>
        /// <param name="storageFolder">a local path where the files are stored</param>
        /// <param name="key">the unique key of this DB, could be a publickey or a guid or any unique string</param>
        public DatabaseInstanceFileBasedManager(string storageFolder, string key)
        {
            _storageFolder = storageFolder;
            _key = key;
            if (!Directory.Exists(storageFolder))
            {
                Directory.CreateDirectory(storageFolder);
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
            var filePath = Path.Combine(_storageFolder, $"{_key}_{fileType}.db");
            return File.Open(filePath, FileMode.OpenOrCreate);
        }
    }
}
