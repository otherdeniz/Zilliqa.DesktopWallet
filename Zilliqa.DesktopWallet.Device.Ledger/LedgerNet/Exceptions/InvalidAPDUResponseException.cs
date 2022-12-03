namespace Zilliqa.DesktopWallet.Device.Ledger.LedgerNet.Exceptions
{
    public class InvalidAPDUResponseException : ResponseBaseException
    {
        public InvalidAPDUResponseException(string message, byte[] responseData) : base(message, responseData)
        {
        }
    }
}
