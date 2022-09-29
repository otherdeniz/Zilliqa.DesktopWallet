#nullable enable
using Newtonsoft.Json;
using Zillifriends.Shared.Common;

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

        [JsonProperty("product")]
        public bool Product { get; set; }

        [JsonProperty("links")] 
        public CryptometaLinks Links { get; set; } = new();

        [JsonProperty("gen")] 
        public CryptometaGen Gen { get; set; } = new();

        public string NameShort()
        {
            return Name.TokenNameShort();
        }

        public string SymbolShort()
        {
            return Symbol.TokenSymbolShort();
        }
    }
}
