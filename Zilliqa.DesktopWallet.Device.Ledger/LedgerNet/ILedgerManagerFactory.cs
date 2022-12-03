using Device.Net;

namespace Zilliqa.DesktopWallet.Device.Ledger.LedgerNet
{
    public interface ILedgerManagerFactory
    {
        IManagesLedger GetNewLedgerManager(IDevice ledgerHidDevice, ICoinUtility coinUtility, ErrorPromptDelegate errorPrompt);
    }
}
