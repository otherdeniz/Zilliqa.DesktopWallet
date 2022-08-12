using Zillifriends.Shared.Common;
using Zilligraph.Database.Storage;

namespace Zilliqa.DesktopWallet.Core.ZilligraphDb
{
    public class ZilliqaBlockchainDbRepository
    {
        public ZilliqaBlockchainDbRepository()
        {
            Database = new ZilligraphDatabase(DataPathBuilder.Root.GetSubFolder("ZilliqaDB").FullPath);
        }

        public ZilligraphDatabase Database { get; }


    }
}
