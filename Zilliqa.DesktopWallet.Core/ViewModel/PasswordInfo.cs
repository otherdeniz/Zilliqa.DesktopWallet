using Zilliqa.DesktopWallet.Core.Cryptography;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class PasswordInfo
    {
        public PasswordInfo(string password)
        {
            Password = password;
            Hash = EncryptionUtils.CreatePasswordHash(password);
        }

        public string Password { get;}

        public string Hash { get; }

    }
}
