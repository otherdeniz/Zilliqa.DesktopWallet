using Zillifriends.Shared.Common;
using Zilligraph.Database.Storage;

namespace Zilliqa.DesktopWallet.Core.ZilligraphDb
{
    public class ZilliqaBlockchainDbRepository
    {
        public const string ZilliqaDbFolder = "ZilliqaDB";

        public ZilliqaBlockchainDbRepository()
        {
            Database = new ZilligraphDatabase(DataPathBuilder.Root.GetSubFolder(ZilliqaDbFolder).FullPath);
        }

        public ZilligraphDatabase Database { get; }


    }
}
