using System.ComponentModel;
using Zilliqa.DesktopWallet.Core.Api.Coingecko.Model;
using Zilliqa.DesktopWallet.ViewModelAttributes;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class TokenMarketDataViewModel
    {
        private readonly CoinPriceMarketData _coinPriceMarketData;

        public TokenMarketDataViewModel(CoinPriceMarketData coinPriceMarketData)
        {
            _coinPriceMarketData = coinPriceMarketData;
        }

        [DetailsProperty]
        [DisplayName("Current price USD")]
        [GridViewFormat("0.0000 $")]
        public decimal? CurrentPriceUsd => _coinPriceMarketData.CurrentPrice.Usd;

        [DetailsProperty]
        [DisplayName("Current price BTC")]
        [GridViewFormat("0.00000000 BTC")]
        public decimal? CurrentPriceBtc => _coinPriceMarketData.CurrentPrice.Btc;

        [DetailsProperty]
        [DisplayName("ATH price USD")]
        [GridViewFormat("0.0000 $")]
        public decimal? AthPriceUsd => _coinPriceMarketData.Ath.Usd;

        [DetailsProperty]
        [DisplayName("ATH price BTC")]
        [GridViewFormat("0.00000000 BTC")]
        public decimal? AthPriceBtc => _coinPriceMarketData.Ath.Btc;

        [DetailsProperty]
        [DisplayName("ATL price USD")]
        [GridViewFormat("0.0000 $")]
        public decimal? AtlPriceUsd => _coinPriceMarketData.Atl.Usd;

        [DetailsProperty]
        [DisplayName("ATL price BTC")]
        [GridViewFormat("0.00000000 BTC")]
        public decimal? AtlPriceBtc => _coinPriceMarketData.Atl.Btc;

        [DetailsProperty]
        [DisplayName("Market Cap USD")]
        [GridViewFormat("#,##0 $")]
        public decimal? MarketCapPriceUsd => _coinPriceMarketData.MarketCap.Usd;

        [DetailsProperty]
        [DisplayName("Market Cap BTC")]
        [GridViewFormat("#,##0.00 BTC")]
        public decimal? MarketCapPriceBtc => _coinPriceMarketData.MarketCap.Btc;

    }
}
