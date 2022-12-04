namespace Zilliqa.DesktopWallet.Device.Ledger.LedgerNet.Exceptions
{
    public abstract class ResponseBaseException : Exception
    {
        public byte[] ResponseData { get; }

        protected ResponseBaseException(string message, byte[] responseData) : base(message)
        {
            ResponseData = responseData;
        }
    }
}
