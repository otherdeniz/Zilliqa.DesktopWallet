using Zilliqa.DesktopWallet.Device.Ledger.LedgerNet.Requests.Abstract;

namespace Zilliqa.DesktopWallet.Device.Ledger.LedgerNet.Requests.Concrete
{
    public class EthereumAppGetPublicKeyRequest : RequestBase
    {
        private const byte P2_NO_CHAINCODE = 0x00;
        private const byte P2_CHAINCODE = 0x01;
        private const byte P1_CONFIRM = 0x01;
        private const byte P1_NON_CONFIRM = 0x00;

        public override byte Argument1 => Display ? P1_CONFIRM : P1_NON_CONFIRM;
        public override byte Argument2 => UseChainCode ? P2_CHAINCODE : P2_NO_CHAINCODE;
        public override byte Cla => Constants.CLA;
        public override byte Ins => Constants.ETHEREUM_GET_WALLET_PUBLIC_KEY;

        public bool Display { get; }
        public bool UseChainCode { get; }

        public EthereumAppGetPublicKeyRequest(bool display, bool useChainCode, byte[] data) : base(data)
        {
            Display = display;
            UseChainCode = useChainCode;
        }
    }
}
