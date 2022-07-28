using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zilligraph.Database.Storage.Service
{
    public class StorageDatabaseService
    {
        public string DataRootFolder { get; }
        public int FilesPerFolder { get; }

        public StorageDatabaseService(string dataRootFolder, int filesPerFolder)
        {
            DataRootFolder = dataRootFolder;
            FilesPerFolder = filesPerFolder;
        }

        //public StorageDatabaseInstance LoadInstance(string instanceKey)
        //{
        //    return new StorageDatabaseInstance();
        //}
    }
}
