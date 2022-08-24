using Zillifriends.Shared.Common;
using Zilligraph.Database.Storage;

namespace Zilliqa.DesktopWallet.Core.CacheDatabase
{
    public static class CacheDatabaseFactory
    {
        public static ZilligraphDatabase CreateDatabaseInstance()
        {
            return new ZilligraphDatabase(DataPathBuilder.Root.GetSubFolder("ApiCacheDB").FullPath);
        }
    }
}
