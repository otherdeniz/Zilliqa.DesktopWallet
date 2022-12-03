using Zilliqa.DesktopWallet.Device.Ledger.LedgerNet;
using Zilliqa.DesktopWallet.Device.Ledger.LedgerNet.Requests.Abstract;

namespace Zilliqa.DesktopWallet.Device.Ledger
{
    public class ZilliqaAppGetAddressRequest : RequestBase
    {
        private readonly bool _getPublicKey;

        //From test_getPublicKey.py
        public override byte Argument1 => (byte)(Display ? 1 : 0);

        public override byte Argument2 => _getPublicKey
            ? (byte)0x00 // display public key in Ledger
            : (byte)0x01; // display bech32 address in Ledger

        public override byte Cla => Constants.CLA;
        public override byte Ins => Constants.ETHEREUM_GET_WALLET_PUBLIC_KEY;

        public bool Display { get; }

        public ZilliqaAppGetAddressRequest(bool display, byte[] data, bool getPublicKey) : base(data)
        {
            _getPublicKey = getPublicKey;
            Display = display;
        }
    }
}