using Zilliqa.DesktopWallet.Core.Cryptography;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class DataViewModel
    {
        public static DataViewModel Instance { get; } = new DataViewModel();

        public string? PassphraseHash { get; private set; }

        public bool CheckPassphrase(string passphrase)
        {
            if (PassphraseHash == null)
            {
                return false;
            }
            return EncryptionUtils.ValidatePasswordHash(passphrase, PassphraseHash);
        }

        public void SetPassphrase(string passphrase)
        {
            PassphraseHash = EncryptionUtils.CreatePasswordHash(passphrase);
        }

    }
}
