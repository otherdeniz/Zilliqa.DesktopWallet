using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core.Api.Coingecko.Model;

namespace Zilliqa.DesktopWallet.Core.Data.Files
{
    [DatFileName("token-prices.json")]
    public class TokenPriceFile : DatFileBase
    {
        private static TokenPriceFile? _instance;

        public static TokenPriceFile Instance => _instance ??= Load<TokenPriceFile>(DataPathBuilder.AppDataRoot);

        #region Fields

        public DateTime? ExistingAssetsRefresh { get; set; }

        public DateTime? NewAssetsAdded { get; set; }

        public List<CoinPrice> CoinPrices { get; set; } = new();

        #endregion

    }
}
