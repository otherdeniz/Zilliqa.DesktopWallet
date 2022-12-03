using Zilliqa.DesktopWallet.Device.Ledger.LedgerNet.Responses.Abstract;

namespace Zilliqa.DesktopWallet.Device.Ledger
{
    public class ZilliqaAppSignatureResponse : ResponseBase
    {
        public ZilliqaAppSignatureResponse(byte[] data) : base(data)
        {
        }
    }
}