using Device.Net;

namespace Ledger.Net
{
    public class ZilliqaLedgerManagerFactory : ILedgerManagerFactory
    {
        public IManagesLedger GetNewLedgerManager(IDevice ledgerHidDevice, ICoinUtility coinUtility, ErrorPromptDelegate errorPrompt)
        {
            return new ZilLedgerManager(new LedgerManagerTransport(ledgerHidDevice), coinUtility, errorPrompt);
        }
    }
}