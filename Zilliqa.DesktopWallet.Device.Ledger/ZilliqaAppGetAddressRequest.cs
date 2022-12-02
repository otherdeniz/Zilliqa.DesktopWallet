namespace Ledger.Net.Requests
{
    public class ZilliqaAppGetAddressRequest : RequestBase
    {
        private readonly bool _getPublicKey;

        //From test_getPublicKey.py
        public override byte Argument1 => (byte)(Display ? 1 : 0);
        public override byte Argument2 => _getPublicKey ? (byte)0x00 : (byte)0x01;
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