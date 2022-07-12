using System.Security;

namespace Zilliqa.DesktopWallet.Core.Data.Files
{
    public class WalletDat
    {
        private static Lazy<string> localDataFile = new Lazy<string>(() => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "wallet.dat"));

        public static bool Exists => File.Exists(localDataFile.Value);

        public static WalletDat Load()
        {
            if (Exists)
            {

            }

            return null;
        }

        public WalletDat()
        {
        }

        public void Save()
        {

        }
    }
}