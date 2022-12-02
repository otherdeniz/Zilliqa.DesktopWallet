using Newtonsoft.Json;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.ApiClient.Accounts;
using Zilliqa.DesktopWallet.ApiClient.Crypto;
using Zilliqa.DesktopWallet.Core.Services.Model;

namespace Zilliqa.DesktopWallet.Core.Data.Model
{
    public class MyAccount : AccountBase
    {
        private Account? _accountDetails;
        private string? _addressBech32;
        private string? _addressHex;
        private Address? _address;

        public static MyAccount CreateLedger(string name, string bech32Address, string publicKey)
        {
            var result = new MyAccount
            {
                Id = Guid.NewGuid().ToString(),
                Type = MyAccountType.LedgerWallet,
                Name = name,
                AddressBech32 = bech32Address,
                PublicKey = publicKey
            };
            return result;
        }

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
            return result;
        }

        public MyAccountType Type { get; set; } = MyAccountType.EncryptedPrivateKey;

        public string KeyEncrypted { get; set; }

        public string PublicKey { get; set; }

        public string AddressBech32 {
            get => _addressBech32!;
            set
            {
                _addressBech32 = value;
                _address = new Address(value);
            }
        }

        [JsonIgnore]
        public Account AccountDetails
        {
            get => _accountDetails ?? throw new Exception("please call Load() first");
            set => _accountDetails = value;
        }

        [JsonIgnore]
        public override Address Address => _address ??= AccountDetails.Address;

        public ISenderAccount GetSenderAccount()
        {
            if (Type == MyAccountType.EncryptedPrivateKey)
            {
                return new PrivateKeySenderAccount(this);
            }
            if (Type == MyAccountType.LedgerWallet)
            {
                return new LedgerSenderAccount(this);
            }
            throw new NotSupportedException("MyAccount.Type not supported as 'SenderAccount'");
        }

        public override string GetAddressBech32()
        {
            return _addressBech32 ??= Address.GetBech32();
        }

        public override string GetAddressHex()
        {
            return _addressHex ??= Address.GetBase16(false);
        }

        public void Load(string password)
        {
            _accountDetails = new Account(KeyEncrypted, password);
        }
    }

    public enum MyAccountType
    {
        EncryptedPrivateKey = 1,
        LedgerWallet = 2
    }
}
