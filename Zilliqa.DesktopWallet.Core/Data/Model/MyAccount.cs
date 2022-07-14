using Newtonsoft.Json;
using Zilliqa.DesktopWallet.ApiClient.Accounts;
using Zilliqa.DesktopWallet.ApiClient.Crypto;

namespace Zilliqa.DesktopWallet.Core.Data.Model
{
    public class MyAccount : AccountBase
    {
        private Account? _accountDetails;

        public static MyAccount Create(string name, string pasword)
        {
            var result = new MyAccount();
            var keyPair = Schnorr.GenerateKeyPair();
            result.AccountDetails = new Account(keyPair);
            result.KeyEncrypted = result.AccountDetails.ToJson(pasword, KDFType.PBKDF2);
            result.PublicKey = result.AccountDetails.GetPublicKey();
            result.Name = name;
            result.Address = result.AccountDetails.Address.Raw;
            return result;
        }

        public string KeyEncrypted { get; set; }

        public string PublicKey { get; set; }

        [JsonIgnore]
        public Account AccountDetails
        {
            get => _accountDetails ?? throw new Exception("please call Load() first");
            set => _accountDetails = value;
        }

        public void Load(string password)
        {
            _accountDetails = new Account(KeyEncrypted, password);
        }
    }
}
