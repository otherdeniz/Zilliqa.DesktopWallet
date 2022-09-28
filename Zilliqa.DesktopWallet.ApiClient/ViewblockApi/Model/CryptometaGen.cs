#nullable enable
using Newtonsoft.Json;

namespace Zilliqa.DesktopWallet.ApiClient.ViewblockApi.Model;

public class CryptometaGen
{
    [JsonProperty("logo")]
    public string Logo { get; set; }

    [JsonProperty("score")]
    public int Score { get; set; }
}