#nullable enable
using Newtonsoft.Json;

namespace Zilliqa.DesktopWallet.ApiClient.ViewblockApi.Model
{
    public class CryptometaAssetResult
    {
        public bool Found { get; set; }

        public CryptometaAsset? Asset { get; set; }

        public byte[]? Image { get; set; }
    }

    public class CryptometaAsset
    {
        [JsonProperty("address")]
        public string Bech32Address { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("web")]
        public string Web { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("whitepaper")]
        public string Whitepaper { get; set; }

        [JsonProperty("publicTeam")]
        public bool PublicTeam { get; set; }

        [JsonProperty("trusted")]
        public bool Trusted { get; set; }

        [JsonProperty("links")] 
        public CryptometaAssetLinks Links { get; set; } = new();

        [JsonProperty("gen")] 
        public CryptometaAssetGen Gen { get; set; } = new();

    }

    public class CryptometaAssetLinks
    {
        [JsonProperty("twitter")]
        public string Twitter { get; set; }

        [JsonProperty("telegram")]
        public string Telegram { get; set; }

        [JsonProperty("github")]
        public string Github { get; set; }

        [JsonProperty("linkedin")]
        public string Linkedin { get; set; }

    }

    public class CryptometaAssetGen
    {
        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }
    }
}
