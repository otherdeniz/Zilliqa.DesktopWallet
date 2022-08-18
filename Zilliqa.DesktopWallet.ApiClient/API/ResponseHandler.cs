using Newtonsoft.Json.Linq;
using Zilliqa.DesktopWallet.ApiClient.Enums;

namespace Zilliqa.DesktopWallet.ApiClient.API
{
    public class ResponseHandler 
    {
        public static MusResult GetResult(ref APIResponse response)
        {
            var error = CheckError(ref response, out var msg);
            return new MusResult(response.Result, msg) { Error = error };
        }

        public static MusResult GetSubFromResult(ref APIResponse resp, string sub = "")
        {
            var o = ((JObject)resp.Result)[sub];
            var error = CheckError(ref resp, out var msg);
            return new MusResult(o, msg) { Error = error};
        }

        #region Accounts

        /// <summary>
        /// Gets Balance from result object 
        /// </summary>
        /// <param name="resp"></param>
        /// <param name="unit">Default: Unit.ZIL. See Unit enum</param>
        /// <returns></returns>
        public static MusResult GetBalanceFromResult(ref APIResponse resp, Unit unit = Unit.QA)
        {
            decimal balance = resp.Error != null ? -1 : (decimal)((JObject)resp.Result)["balance"];
            var bal = new Balance(balance);
            CheckError(ref resp, out var msg);
            return new MusResult(bal.GetBalance(unit),msg);
        }

        #endregion

        #region Contracts 

        public static MusResult GetContractCode(ref APIResponse resp)
        {
            var code = "";
            if (!CheckError(ref resp, out var msg))
            {
                code = (string)((JObject)resp.Result)["code"];
            }
            var result = new MusResult(code, "GetContractCode Success");
            return result;
        }

        public static MusResult GetContractBalance(ref APIResponse resp)
        {
            decimal balance = -1;
            if (!CheckError(ref resp, out var msg))
            {
                balance = (decimal)((JObject)resp.Result)["_balance"];
            }
            var result = new MusResult(balance, "GetContractCode Success");
            return result;
        }
        #endregion

        #region Helpers

        private static bool CheckError(ref APIResponse resp,out string message)
        {
            var isError = resp.Error != null;
            message =  isError 
                ? ((JObject)resp.Error)["message"]?.ToString() ?? "API Call Unknown Error"
                : "API Call Success";
            return isError;
        }

        #endregion

    }
}
