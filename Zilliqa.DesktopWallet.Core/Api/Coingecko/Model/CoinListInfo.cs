using Newtonsoft.Json;

namespace Zilliqa.DesktopWallet.Core.Api.Coingecko.Model
{
    public class CoinListInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
