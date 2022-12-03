namespace Zilliqa.DesktopWallet.Device.Ledger.LedgerNet
{
    public class LedgerManagerConnectionEventArgs : EventArgs
    {
        public IManagesLedger LedgerManager { get; }

        public LedgerManagerConnectionEventArgs(IManagesLedger ledgerManager)
        {
            LedgerManager = ledgerManager;
        }

    }
}