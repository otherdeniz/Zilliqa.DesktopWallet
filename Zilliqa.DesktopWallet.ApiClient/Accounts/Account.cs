using System;
using System.Text;
using Org.BouncyCastle.Math;
using Zilliqa.DesktopWallet.ApiClient.Crypto;
using Zilliqa.DesktopWallet.ApiClient.Utils;

namespace Zilliqa.DesktopWallet.ApiClient.Accounts
{
    public class Account
    {
        public Address Address { get; set; }

        public ECKeyPair KeyPair { get; set; }

        public Account(ECKeyPair keyPair)
        {
            if (string.IsNullOrWhiteSpace(keyPair?.PrivateKeyHex))
                throw new ArgumentException("Private key is empty");

            InitializeAccount(keyPair.PrivateKeyHex);
        }

        public Account(string privateKey)
        {
            if (string.IsNullOrWhiteSpace(privateKey))
                throw new ArgumentException("Private key is empty");

            InitializeAccount(privateKey);
        }
        public Account(string keyStoreJson, string passphrase)
        {
            string privateKey = CryptoUtil.DecryptPrivateKey(keyStoreJson, passphrase);
            InitializeAccount(privateKey);
        }
        
        public string ToJson(string passphrase, KDFType type)
        {
            return CryptoUtil.EncryptPrivateKey(GetPrivateKey(), passphrase, type);
        }

        public string GetPublicKey()
        {
            return ByteUtil.ByteArrayToHexString(KeyPair.PublicKey.ToByteArray());
        }

        public string GetPrivateKey()
        {
            return ByteUtil.ByteArrayToHexString(KeyPair.PrivateKey.ToByteArray());
        }

        public static string ToCheckSumAddress(string addressHex)
        {
            addressHex = addressHex.ToLower();
            if (addressHex.StartsWith("0x"))
            {
                addressHex = addressHex.Substring(2);
            }

            string hash = ByteUtil.ByteArrayToHexString(HashUtil.CalculateSha256Hash(ByteUtil.HexStringToByteArray(addressHex)));
            StringBuilder ret = new StringBuilder("0x");
            BigInteger v = new BigInteger(ByteUtil.HexStringToByteArray(hash));
            for (int i = 0; i < addressHex.Length; i++)
            {
                if ("1234567890".IndexOf(addressHex[i]) != -1)
                {
                    ret.Append(addressHex[i]);
                }
                else
                {
                    BigInteger checker = v.And(BigInteger.ValueOf(2).Pow(255 - 6 * i));
                    ret.Append(checker.CompareTo(BigInteger.ValueOf(1)) < 0 ? addressHex[i].ToString().ToLower() : addressHex[i].ToString().ToUpper());
                }
            }
            return ret.ToString();
        }

        private void InitializeAccount(string pk)
        {
            var pub = CryptoUtil.GetPublicKeyFromPrivateKey(pk, true);
            Address = new Address(CryptoUtil.GetAddressFromPublicKey(pub));
            //Address.Raw = "0x" + CryptoUtil.GetAddressFromPublicKey(pub);
            KeyPair = new ECKeyPair(new BigInteger(pk, 16), new BigInteger(pub, 16));
        }
    }
}
