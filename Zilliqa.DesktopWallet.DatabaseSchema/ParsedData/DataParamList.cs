using Newtonsoft.Json.Linq;

namespace Zilliqa.DesktopWallet.DatabaseSchema.ParsedData;

public class DataParamList : List<Param>
{
    public static bool TryParse(object data, out DataParamList? result)
    {
        if (data is JToken jToken)
        {
            try
            {
                result = jToken.ToObject<DataParamList>();
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
}