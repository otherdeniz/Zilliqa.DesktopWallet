using Device.Net;
using Zilliqa.DesktopWallet.Device.Ledger.LedgerNet;

namespace Zilliqa.DesktopWallet.Device.Ledger
{
    public class ZilliqaLedgerManagerFactory : ILedgerManagerFactory
    {
        public IManagesLedger GetNewLedgerManager(IDevice ledgerHidDevice, ICoinUtility coinUtility, ErrorPromptDelegate errorPrompt)
        {
            return new ZilLedgerManager(new LedgerManagerTransport(ledgerHidDevice), coinUtility, errorPrompt);
        }
    }
}