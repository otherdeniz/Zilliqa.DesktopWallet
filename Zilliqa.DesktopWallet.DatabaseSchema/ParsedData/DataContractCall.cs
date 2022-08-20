using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zilliqa.DesktopWallet.DatabaseSchema.ParsedData;

public class DataContractCall
{
    public static bool TryParse(string data, out DataContractCall result)
    {
        if (!string.IsNullOrEmpty(data))
        {
            try
            {
                return TryParse(JToken.Parse(data), out result);
            }
            catch (Exception)
            {
                // failed
            }
        }
        result = null!;
        return false;
    }

    public static bool TryParse(object data, out DataContractCall result)
    {
        if (data is JToken jToken)
        {
            try
            {
                var contractCall = jToken.ToObject<DataContractCall>();
                if (contractCall != null)
                {
                    result = contractCall;
                    return result.Tag != null
                           && result.Params.Any();
                }
            }
            catch (Exception)
            {
                // failed
            }
        }

        result = null!;
        return false;
    }

    [JsonProperty("_tag")]
    public string? Tag { get; set; }

    [JsonProperty("params")] 
    public List<DataParam> Params { get; set; } = null!;
}