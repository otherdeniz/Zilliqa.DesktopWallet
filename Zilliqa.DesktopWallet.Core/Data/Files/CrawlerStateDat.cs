using Zillifriends.Shared.Common;

namespace Zilliqa.DesktopWallet.Core.Data.Files
{
    [DatFileName("crawler-state.dat")]
    public class CrawlerStateDat : DatFileBase
    {
        private static CrawlerStateDat? _instance;

        public static CrawlerStateDat Instance => _instance ??= Load<CrawlerStateDat>();

        #region Fields

        public CrawlerByBlockState TransactionCrawler { get; set; } = new();

        public CrawlerByBlockState BlockCrawler { get; set; } = new();

        #endregion

        public class CrawlerByBlockState
        {
            public int HighestBlock { get; set; }

            public int LowestBlock { get; set; }
        }
    }
}
