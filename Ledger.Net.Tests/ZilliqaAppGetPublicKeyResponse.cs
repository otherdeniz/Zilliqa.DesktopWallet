using System;
using System.Security.Cryptography;
using System.Text;
using Zilliqa.DesktopWallet.ApiClient.Utils;

namespace Ledger.Net.Responses
{
    public class ZilliqaAppGetPublicKeyResponse : GetPublicKeyResponseBase
    {
        private string _addressHex;
        private string _publicKeyHex;

        public ZilliqaAppGetPublicKeyResponse(byte[] data) : base(data)
        {
            string addressHex;
            using (SHA256 sha = SHA256.Create())
            {
                var addressByteArray = sha.ComputeHash(data);
                addressHex = ByteUtil.ByteArrayToHexString(addressByteArray);
            }
            _addressHex = addressHex.Substring(24).ToLower();
            _publicKeyHex = ByteUtil.ByteArrayToHexString(data);
        }

        protected override string GetAddressString(byte[] addressData)
        {
            return _addressHex;
        }

        protected override string GetPublicKeyString(byte[] publicKeyData)
        {
            return $"0x{_publicKeyHex}";
        }
    }
}