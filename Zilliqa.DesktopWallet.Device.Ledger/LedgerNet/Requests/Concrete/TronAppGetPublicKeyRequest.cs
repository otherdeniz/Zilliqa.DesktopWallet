using Zilliqa.DesktopWallet.Device.Ledger.LedgerNet.Requests.Abstract;

namespace Zilliqa.DesktopWallet.Device.Ledger.LedgerNet.Requests.Concrete
{
    public class TronAppGetPublicKeyRequest : RequestBase
    {
        //From test_getPublicKey.py
        public override byte Argument1 => (byte)(Display ? 1 : 0);
        public override byte Argument2 => 0x00;
        public override byte Cla => Constants.CLA;
        public override byte Ins => 0x02;

        public bool Display { get; }
        public BitcoinAddressType BitcoinAddressType { get; }

        public TronAppGetPublicKeyRequest(bool display, byte[] data) : base(data)
        {
            Display = display;
        }
    }
}
