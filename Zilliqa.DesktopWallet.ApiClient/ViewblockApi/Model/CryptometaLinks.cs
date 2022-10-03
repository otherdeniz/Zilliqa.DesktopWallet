#nullable enable
using Newtonsoft.Json;
using Zilliqa.DesktopWallet.ViewModelAttributes;

namespace Zilliqa.DesktopWallet.ApiClient.ViewblockApi.Model;

public class CryptometaLinks
{
    [DetailsProperty(DetailsPropertyType.Url)]
    [JsonProperty("github")]
    public string? Github { get; set; }

    [DetailsProperty(DetailsPropertyType.Url)]
    [JsonProperty("discord")]
    public string? Discord { get; set; }

    [DetailsProperty(DetailsPropertyType.Url)]
    [JsonProperty("twitter")]
    public string? Twitter { get; set; }

    [DetailsProperty(DetailsPropertyType.Url)]
    [JsonProperty("telegram")]
    public string? Telegram { get; set; }

    [DetailsProperty(DetailsPropertyType.Url)]
    [JsonProperty("facebook")]
    public string? Facebook { get; set; }

    [DetailsProperty(DetailsPropertyType.Url)]
    [JsonProperty("linkedin")]
    public string? Linkedin { get; set; }

    [DetailsProperty(DetailsPropertyType.Url)]
    [JsonProperty("medium")]
    public string? Medium { get; set; }

    [DetailsProperty(DetailsPropertyType.Url)]
    [JsonProperty("coinmarketcap")]
    public string? Coinmarketcap { get; set; }

    [DetailsProperty(DetailsPropertyType.Url)]
    [JsonProperty("coingecko")]
    public string? Coingecko { get; set; }

}