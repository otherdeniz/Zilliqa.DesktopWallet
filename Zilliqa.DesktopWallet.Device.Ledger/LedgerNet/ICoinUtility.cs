namespace Zilliqa.DesktopWallet.Device.Ledger.LedgerNet
{
    public interface ICoinUtility
    {
        CoinInfo GetCoinInfo(uint coinNumber);
        CoinInfo GetCoinInfo(string coinShortName);
    }
}
