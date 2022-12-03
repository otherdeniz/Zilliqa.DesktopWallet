using Device.Net;

namespace Zilliqa.DesktopWallet.Device.Ledger.LedgerNet
{
    public class LedgerManagerFactory : ILedgerManagerFactory
    {
        public IManagesLedger GetNewLedgerManager(IDevice ledgerHidDevice, ICoinUtility coinUtility, ErrorPromptDelegate errorPrompt)
        {
            return new LedgerManager(new LedgerManagerTransport(ledgerHidDevice), coinUtility, errorPrompt);
        }
    }
}
