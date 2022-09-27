using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;

namespace Zilliqa.DesktopWallet.DatabaseSchema.ParsedData;

public class DataParam : IParam
{
    public static bool TryParseList(string data, out List<DataParam>? result)
    {
        if (!string.IsNullOrEmpty(data))
        {
            try
            {
                result = JToken.Parse(data).ToObject<List<DataParam>>();
                return true;
            }
            catch (Exception)
            {
                // failed
            }
        }
        result = null;
        return false;
    }

    private ParamValue? _resolvedValue;

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("vname")]
    public string Vname { get; set; }

    [JsonProperty("value")]
    public object Value { get; set; }

    [TypeConverter(typeof(ExpandableObjectConverter))] //Attribute only for GUI PropertyGrid
    public ParamValue ResolvedValue => _resolvedValue ??= ParamValue.ResolveParam(this);
}