using Newtonsoft.Json;

namespace Zilliqa.DesktopWallet.Core.Api.Coingecko.Model
{
    public class CoinPrice
    {
        public static CoinPrice CreateEmpty(string symbol)
        {
            return new CoinPrice
            {
                Symbol = symbol
            };
        }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("platforms")] 
        public CoinPlatforms Platforms { get; set; } = new();

        [JsonProperty("description")]
        public CoinDescription Description { get; set; } = new();

        [JsonProperty("coingecko_score")]
        public decimal? CoingeckoScore { get; set; }

        [JsonProperty("market_data")] 
        public CoinPriceMarketData MarketData { get; set; } = new();

    }

    public class CoinPlatforms
    {
        [JsonProperty("binance-smart-chain")]
        public string? BinanceSmartChain { get; set; }

        [JsonProperty("ethereum")]
        public string? Ethereum { get; set; }

        [JsonProperty("zilliqa")]
        public string? Zilliqa { get; set; }
    }

    public class CoinDescription
    {
        [JsonProperty("en")]
        public string? En { get; set; }
    }

    public class CoinPriceMarketData
    {
        [JsonProperty("current_price")] 
        public CoinMarketCurrencyValues CurrentPrice { get; set; } = new();

        [JsonProperty("ath")]
        public CoinMarketCurrencyValues Ath { get; set; } = new();

        [JsonProperty("ath_change_percentage")]
        public CoinMarketCurrencyValues AthChangePercentage { get; set; } = new();

        [JsonProperty("atl")]
        public CoinMarketCurrencyValues Atl { get; set; } = new();

        [JsonProperty("market_cap")]
        public CoinMarketCurrencyValues MarketCap { get; set; } = new();

        [JsonProperty("market_cap_rank")]
        public int MarketCapRank { get; set; }

        [JsonProperty("fully_diluted_valuation")]
        public CoinMarketCurrencyValues FullyDilutedValuation { get; set; } = new();

        [JsonProperty("total_volume")]
        public CoinMarketCurrencyValues TotalVolume { get; set; } = new();

        [JsonProperty("price_change_percentage_24h")]
        public decimal? PriceChangePercentage24H { get; set; }

        [JsonProperty("price_change_percentage_7d")]
        public decimal? PriceChangePercentage7D { get; set; }

        [JsonProperty("price_change_percentage_14d")]
        public decimal? PriceChangePercentage14D { get; set; }

        [JsonProperty("price_change_percentage_30d")]
        public decimal? PriceChangePercentage30D { get; set; }

        [JsonProperty("price_change_percentage_60d")]
        public decimal? PriceChangePercentage60D { get; set; }

        [JsonProperty("price_change_percentage_1y")]
        public decimal? PriceChangePercentage1Y { get; set; }

        [JsonProperty("total_supply")]
        public decimal? TotalSupply { get; set; }

        [JsonProperty("max_supply")]
        public decimal? MaxSupply { get; set; }

        [JsonProperty("circulating_supply")]
        public decimal? CirculatingSupply { get; set; }
    }

    public class CoinMarketCurrencyValues
    {
        [JsonProperty("btc")]
        public decimal? Btc { get; set; }

        [JsonProperty("eth")]
        public decimal? Eth { get; set; }

        [JsonProperty("ltc")]
        public decimal? Ltc { get; set; }

        [JsonProperty("chf")]
        public decimal? Chf { get; set; }

        [JsonProperty("eur")]
        public decimal? Eur { get; set; }

        [JsonProperty("gbp")]
        public decimal? Gbp { get; set; }

        [JsonProperty("usd")]
        public decimal? Usd { get; set; }

    }
}
