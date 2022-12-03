using Zilliqa.DesktopWallet.Device.Ledger.LedgerNet;
using Zilliqa.DesktopWallet.Device.Ledger.LedgerNet.Requests.Abstract;

namespace Zilliqa.DesktopWallet.Device.Ledger
{
    public class ZilliqaAppSignatureRequest : RequestBase
    {
        public override byte Argument1 => Constants.P1_SIGN;
        public override byte Argument2 => 0;
        public override byte Cla => Constants.CLA;
        public override byte Ins =>  Constants.TRON_SIGN_TX;

        public ZilliqaAppSignatureRequest(byte[] data) : base(data)
        {
        }
    }
}