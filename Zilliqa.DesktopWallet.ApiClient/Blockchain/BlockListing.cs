using Newtonsoft.Json;

namespace Zilliqa.DesktopWallet.ApiClient.Blockchain
{
    public class BlockListing
    { 
        [JsonProperty("data")]
        public BlockInfo[] Data { get; set; }
        [JsonProperty("maxPages")]
        public int MaxPages { get; set; }
    }
}
