using Zilliqa.DesktopWallet.Core.Cryptography;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class PasswordGuiViewModel
    {
        public PasswordGuiViewModel(string password)
        {
            Password = password;
            Hash = EncryptionUtils.CreatePasswordHash(password);
        }

        public string Password { get;}

        public string Hash { get; }

    }
}
