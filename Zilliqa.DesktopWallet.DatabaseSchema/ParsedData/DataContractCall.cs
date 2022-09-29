using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zilliqa.DesktopWallet.DatabaseSchema.ParsedData;

public class DataContractCall
{
    public static readonly DataContractCall Empty = new() { IsEmpty = true };

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
        result = Empty;
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
                    return result.Tag != null;
                }
            }
            catch (Exception)
            {
                // failed
            }
        }

        result = Empty;
        return false;
    }

    [JsonIgnore]
    public bool IsEmpty { get; private init; }

    [JsonProperty("_tag")]
    public string? Tag { get; set; }

    [JsonProperty("params")] 
    public List<DataParam> Params { get; set; } = null!;
}