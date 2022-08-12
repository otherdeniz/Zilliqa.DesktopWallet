using Newtonsoft.Json;
using Zilliqa.DesktopWallet.ApiClient.Accounts;
using Zilliqa.DesktopWallet.ApiClient.Crypto;
using Zilliqa.DesktopWallet.ApiClient.Utils;

namespace Zilliqa.DesktopWallet.Core.Data.Model
{
    public class MyAccount : AccountBase
    {
        private Account? _accountDetails;
        private string? _addressBech32;

        public static MyAccount Create(string name, string pasword)
        {
            var result = new MyAccount
            {
                Id = Guid.NewGuid().ToString()
            };
            var keyPair = Schnorr.GenerateKeyPair();
            result.AccountDetails = new Account(keyPair);
            result.KeyEncrypted = result.AccountDetails.ToJson(pasword, KDFType.PBKDF2);
            result.PublicKey = result.AccountDetails.GetPublicKey();
            result.Name = name;
            result.AddressHex = result.AccountDetails.Address.Raw;
            return result;
        }

        public static MyAccount Import(string name, string privateKey, string pasword)
        {
            var result = new MyAccount
            {
                Id = Guid.NewGuid().ToString()
            };
            var keyPair = ECKeyPair.Create(privateKey);
            result.AccountDetails = new Account(keyPair);
            result.KeyEncrypted = result.AccountDetails.ToJson(pasword, KDFType.PBKDF2);
            result.PublicKey = result.AccountDetails.GetPublicKey();
            result.Name = name;
            result.AddressHex = result.AccountDetails.Address.Raw;
            return result;
        }

        public string AddressHex { get; set; }

        public string KeyEncrypted { get; set; }

        public string PublicKey { get; set; }

        [JsonIgnore]
        public Account AccountDetails
        {
            get => _accountDetails ?? throw new Exception("please call Load() first");
            set => _accountDetails = value;
        }

        public override string GetAddressBech32()
        {
            return _addressBech32 ??= AddressHex.FromBase16ToBech32Address();
        }

        public void Load(string password)
        {
            _accountDetails = new Account(KeyEncrypted, password);
        }
    }
}
