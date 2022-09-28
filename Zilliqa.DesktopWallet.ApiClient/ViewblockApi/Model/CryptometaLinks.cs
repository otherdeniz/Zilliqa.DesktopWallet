#nullable enable
using Newtonsoft.Json;

namespace Zilliqa.DesktopWallet.ApiClient.ViewblockApi.Model;

public class CryptometaLinks
{
    [JsonProperty("github")]
    public string? Github { get; set; }

    [JsonProperty("discord")]
    public string? Discord { get; set; }

    [JsonProperty("twitter")]
    public string? Twitter { get; set; }

    [JsonProperty("telegram")]
    public string? Telegram { get; set; }

    [JsonProperty("facebook")]
    public string? Facebook { get; set; }

    [JsonProperty("linkedin")]
    public string? Linkedin { get; set; }

    [JsonProperty("medium")]
    public string? Medium { get; set; }

    [JsonProperty("coinmarketcap")]
    public string? Coinmarketcap { get; set; }

    [JsonProperty("coingecko")]
    public string? Coingecko { get; set; }

}