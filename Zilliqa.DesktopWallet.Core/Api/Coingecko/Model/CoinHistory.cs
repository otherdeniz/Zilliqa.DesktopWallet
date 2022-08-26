using Newtonsoft.Json;

namespace Zilliqa.DesktopWallet.Core.Api.Coingecko.Model
{
    public class CoinHistory
    {
        public static CoinHistory CreateEmpty(string symbol)
        {
            return new CoinHistory
            {
                Symbol = symbol,
                MarketData = new CoinHistoryMarketData
                {
                    CurrentPrice = new CoinMarketCurrencyValues(),
                    MarketCap = new CoinMarketCurrencyValues(),
                    TotalVolume = new CoinMarketCurrencyValues()
                }
            };
        }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("market_data")]
        public virtual CoinHistoryMarketData MarketData { get; set; }
    }

    public class CoinHistoryMarketData
    {
        [JsonProperty("current_price")]
        public CoinMarketCurrencyValues CurrentPrice { get; set; }

        [JsonProperty("market_cap")]
        public CoinMarketCurrencyValues MarketCap { get; set; }

        [JsonProperty("total_volume")]
        public CoinMarketCurrencyValues TotalVolume { get; set; }
    }

}
