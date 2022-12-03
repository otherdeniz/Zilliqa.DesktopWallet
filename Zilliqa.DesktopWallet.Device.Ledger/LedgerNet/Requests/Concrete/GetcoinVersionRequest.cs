using Zilliqa.DesktopWallet.Device.Ledger.LedgerNet.Requests.Abstract;

namespace Zilliqa.DesktopWallet.Device.Ledger.LedgerNet.Requests.Concrete
{
    public class GetCoinVersionRequest : RequestBase
    {
        public override byte Argument1 => 0;
        public override byte Argument2 => 0;
        public override byte Cla => Constants.CLA;
        public override byte Ins => Constants.BTCHIP_INS_GET_COIN_VER;

        public GetCoinVersionRequest() : base(new byte[0])
        {
        }
    }
}
