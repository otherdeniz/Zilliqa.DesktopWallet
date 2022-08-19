using Newtonsoft.Json;

namespace Zilliqa.DesktopWallet.DatabaseSchema.ParsedData;

public class DataParam : IParam
{
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("vname")]
    public string Vname { get; set; }

    [JsonProperty("value")]
    public object Value { get; set; }

}