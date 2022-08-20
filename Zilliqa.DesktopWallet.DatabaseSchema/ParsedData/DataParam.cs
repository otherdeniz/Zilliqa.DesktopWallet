using Newtonsoft.Json;

namespace Zilliqa.DesktopWallet.DatabaseSchema.ParsedData;

public class DataParam : IParam
{
    private ParamValue? _resolvedValue;

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("vname")]
    public string Vname { get; set; }

    [JsonProperty("value")]
    public object Value { get; set; }

    public ParamValue ResolvedValue => _resolvedValue ??= ParamValue.ResolveParam(this);
}