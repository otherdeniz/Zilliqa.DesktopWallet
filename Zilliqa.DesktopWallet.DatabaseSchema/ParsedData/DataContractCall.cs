using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zilliqa.DesktopWallet.DatabaseSchema.ParsedData;

public class DataContractCall
{
    public static bool TryParse(object data, out DataContractCall? result)
    {
        if (data is JToken jToken)
        {
            try
            {
                result = jToken.ToObject<DataContractCall>();
                return result?.Tag != null 
                       && result.Params.Any();
            }
            catch (Exception)
            {
                // failed
            }
        }

        result = null;
        return false;
    }

    [JsonProperty("_tag")]
    public string? Tag { get; set; }

    [JsonProperty("params")] 
    public List<Param> Params { get; set; } = null!;
}