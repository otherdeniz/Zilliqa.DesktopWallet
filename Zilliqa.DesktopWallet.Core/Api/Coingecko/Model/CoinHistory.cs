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
                    CurrentPrice = new CoinHistoryMarketCurrencyData(),
                    MarketCap = new CoinHistoryMarketCurrencyData(),
                    TotalVolume = new CoinHistoryMarketCurrencyData()
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
        public CoinHistoryMarketData MarketData { get; set; }
    }

    public class CoinHistoryMarketData
    {
        [JsonProperty("current_price")]
        public CoinHistoryMarketCurrencyData CurrentPrice { get; set; }

        [JsonProperty("market_cap")]
        public CoinHistoryMarketCurrencyData MarketCap { get; set; }

        [JsonProperty("total_volume")]
        public CoinHistoryMarketCurrencyData TotalVolume { get; set; }
    }

    public class CoinHistoryMarketCurrencyData
    {
        [JsonProperty("btc")]
        public decimal Btc { get; set; }

        [JsonProperty("eth")]
        public decimal Eth { get; set; }

        //[JsonProperty("ltc")]
        //public decimal Ltc { get; set; }

        //[JsonProperty("chf")]
        //public decimal Chf { get; set; }

        //[JsonProperty("eur")]
        //public decimal Eur { get; set; }

        //[JsonProperty("gbp")]
        //public decimal Gbp { get; set; }

        [JsonProperty("usd")]
        public decimal Usd { get; set; }

    }
}
