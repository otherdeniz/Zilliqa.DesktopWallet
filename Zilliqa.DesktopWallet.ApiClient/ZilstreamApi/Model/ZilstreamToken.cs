using System;
using Newtonsoft.Json;

namespace Zilliqa.DesktopWallet.ApiClient.ZilstreamApi.Model
{
    public class ZilstreamToken
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("added_at")]
        public DateTime AddedAt { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("address_bech32")]
        public string AddressBech32 { get; set; }

        [JsonProperty("icon")]
        public string IconUrl { get; set; }

        [JsonProperty("decimals")]
        public int Decimals { get; set; }

        [JsonProperty("website")]
        public string WebsiteUrl { get; set; }

        [JsonProperty("telegram")]
        public string TelegramUrl { get; set; }

        [JsonProperty("whitepaper")]
        public string WhitepaperUrl { get; set; }

        [JsonProperty("viewblock_score")]
        public int ViewblockScore { get; set; }

        [JsonProperty("bridged")]
        public bool Bridged { get; set; }

        [JsonProperty("supply_skip_addresses")]
        public string SupplySkipAddresses { get; set; }

        [JsonProperty("market_data")]
        public ZilstreamTokenMarketData MarketData { get; set; }
    }
}
