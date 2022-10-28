using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core.ZilligraphDb;

namespace Zilliqa.DesktopWallet.Core.Data.Files
{
    [DatFileName($"{ZilliqaBlockchainDbRepository.ZilliqaDbFolder}\\crawler-state.dat")]
    public class CrawlerStateDat : DatFileBase
    {
        private static CrawlerStateDat? _instance;

        public static CrawlerStateDat Instance => _instance ??= Load<CrawlerStateDat>(DataPathBuilder.AppDataRoot);

        public static void ReloadInstance()
        {
            _instance = Load<CrawlerStateDat>(DataPathBuilder.AppDataRoot);
        }

        #region Fields

        public CrawlerByBlockState TransactionCrawler { get; set; } = new();

        public CrawlerByBlockState BlockCrawler { get; set; } = new();

        public DateTime? NewestBlockDate { get; set; }

        #endregion

        public class CrawlerByBlockState
        {
            public int HighestBlock { get; set; }

            public int LowestBlock { get; set; }
        }
    }
}
