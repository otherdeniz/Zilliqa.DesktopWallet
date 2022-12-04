namespace Zilliqa.DesktopWallet.Device.Ledger.LedgerNet
{
    public delegate Task ErrorPromptDelegate(int? returnCode, Exception exception, string member);
}
