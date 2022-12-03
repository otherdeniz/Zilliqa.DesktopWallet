using Zilliqa.DesktopWallet.Device.Ledger.LedgerNet.Responses.Abstract;

namespace Zilliqa.DesktopWallet.Device.Ledger.LedgerNet.Responses.Concrete
{
    public class TronAppSignatureResponse : ResponseBase
    {
        public TronAppSignatureResponse(byte[] data) : base(data)
        {
            if (!IsSuccess)
            {
                return;
            }
        }
    }
}
