namespace Zilliqa.DesktopWallet.ApiClient.API
{
    public class MusResult
    {
        public MusResult(object result, string msg, bool error = false)
        {
            Result = result;
            Message = msg;
            Error = error;
        }
        public object Result { get; set; }
        public string Message { get; set; }
        public bool Error { get; set; }

    }
}
