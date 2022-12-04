using Zilliqa.DesktopWallet.Device.Ledger.LedgerNet.Requests.Abstract;

namespace Zilliqa.DesktopWallet.Device.Ledger.LedgerNet.Requests.Concrete
{
    public class EthereumAppSignatureRequest : RequestBase
    {
        public override byte Argument1 => 0;
        public override byte Argument2 => 0;
        public override byte Cla => Constants.CLA;
        public override byte Ins => SignTransaction ? Constants.COMMAND_SIGN_TX : Constants.COMMAND_SIGN_MESSAGE;

        public bool SignTransaction { get; }

        public EthereumAppSignatureRequest(bool signTransaction, byte[] data) : base(data)
        {
            SignTransaction = signTransaction;
        }
    }
}
