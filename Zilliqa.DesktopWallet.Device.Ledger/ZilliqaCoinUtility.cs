using Zilliqa.DesktopWallet.Device.Ledger.LedgerNet;

namespace Zilliqa.DesktopWallet.Device.Ledger
{
    public class ZilliqaCoinUtility : ICoinUtility
    {
        public static readonly CoinInfo ZilliqaCoinInfo = new CoinInfo(App.Bitcoin, "ZIL", "Zilliqa", 313U, false);

        public CoinInfo GetCoinInfo(uint coinNumber)
        {
            if (coinNumber == 313U)
            {
                return ZilliqaCoinInfo;
            }

            throw new ArgumentOutOfRangeException(nameof(coinNumber));
        }

        public CoinInfo GetCoinInfo(string coinShortName)
        {
            if (coinShortName == "ZIL")
            {
                return ZilliqaCoinInfo;
            }
            throw new ArgumentOutOfRangeException(nameof(coinShortName));
        }
    }
}