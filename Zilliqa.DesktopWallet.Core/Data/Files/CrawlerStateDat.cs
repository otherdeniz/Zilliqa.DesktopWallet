using Zillifriends.Shared.Common;

namespace Zilliqa.DesktopWallet.Core.Data.Files
{
    [DatFileName("crawler-state.dat")]
    public class CrawlerStateDat : DatFileBase
    {
        private static CrawlerStateDat? _instance;

        public static CrawlerStateDat Instance => _instance ??= Load<CrawlerStateDat>();

        #region Fields

        public int HighestBlock { get; set; }

        public int LowestBlock { get; set; }

        #endregion
    }
}
