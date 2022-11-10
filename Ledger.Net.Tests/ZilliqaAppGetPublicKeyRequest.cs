namespace Ledger.Net.Requests
{
    public class ZilliqaAppGetPublicKeyRequest : RequestBase
    {
        //From test_getPublicKey.py
        public override byte Argument1 => (byte)(Display ? 1 : 0);
        public override byte Argument2 => 0x00;
        public override byte Cla => Constants.CLA;
        public override byte Ins => Constants.ETHEREUM_GET_WALLET_PUBLIC_KEY;

        public bool Display { get; }

        public BitcoinAddressType BitcoinAddressType { get; }

        public ZilliqaAppGetPublicKeyRequest(bool display, byte[] data) : base(data)
        {
            Display = display;
        }
    }
}