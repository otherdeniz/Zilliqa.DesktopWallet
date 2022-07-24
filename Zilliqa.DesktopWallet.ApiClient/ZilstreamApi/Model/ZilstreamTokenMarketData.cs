using Newtonsoft.Json;

namespace Zilliqa.DesktopWallet.ApiClient.ZilstreamApi.Model
{
    public class ZilstreamTokenMarketData
    {
        [JsonProperty("rate")]
        public decimal RateZil { get; set; }

        [JsonProperty("rate_usd")]
        public decimal RateUsd { get; set; }

        [JsonProperty("init_supply")]
        public decimal InitSupply { get; set; }

        [JsonProperty("max_supply")]
        public decimal MaxSupply { get; set; }

        [JsonProperty("daily_volume_zil")]
        public decimal DailyVolumeZil { get; set; }

        [JsonProperty("daily_volume")]
        public decimal DailyVolumeUsd { get; set; }

        [JsonProperty("fully_diluted_valuation_zil")]
        public decimal FullyDilutedValuationZil { get; set; }

        [JsonProperty("fully_diluted_valuation")]
        public decimal FullyDilutedValuationUsd { get; set; }

        [JsonProperty("current_liquidity_zil")]
        public decimal CurrentLiquidityZil { get; set; }

        [JsonProperty("current_liquidity")]
        public decimal CurrentLiquidityUsd { get; set; }

        [JsonProperty("change_percentage_24h")]
        public decimal ChangePercentage24H { get; set; }

        [JsonProperty("change_percentage_7d")]
        public decimal ChangePercentage7D { get; set; }

    }
}
