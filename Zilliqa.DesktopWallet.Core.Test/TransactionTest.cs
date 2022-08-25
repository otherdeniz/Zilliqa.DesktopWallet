using System.Security.Cryptography;
using System.Text;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.ApiClient.Utils;
using Zilliqa.DesktopWallet.Core.Extensions;

namespace Zilliqa.DesktopWallet.Core.Test
{
    [TestClass]
    public class TransactionTest
    {
        [TestMethod]
        public async Task TransactionFromApi_HasCorrectSenderAddress()
        {
            var hash = "07fd4999a6189a08e0a36e803d7f230d82fb20464098849de59a8c77430ec419"; //"655107c300e86ee6e819af1cbfce097db1510e8cd971d99f32ce2772dcad42f2";
            var txn = await new ZilliqaClient(false).GetTransaction(hash);
            var txnModel = txn.MapToModel<ApiClient.Model.Transaction, DatabaseSchema.Transaction>();
            Assert.AreEqual(txnModel.SenderAddress, new Address("zil19e22jmsaeud6nx09q4fp8sadlfgzwucl98gn8a").GetBase16(false));
            // txnModel.SenderPublicKey = 0x032CE5279A0E9F4B383C98C9CBAAFE84F8B6FABBC3CF284D29447F1857D80F7497
            // txnModel.SenderAddress = 597a89e0f241ac54a086ef9dc88ff24356ac7a25
            // Address GetBase16 = "2e54a96e1dcf1ba999e5055213c3adfa5027731f"
        }

        [TestMethod]
        public void TestAddressFromPublicKey()
        {
            var expectedAddr = "2e54a96e1dcf1ba999e5055213c3adfa5027731f";
            var pubKey = "0x032CE5279A0E9F4B383C98C9CBAAFE84F8B6FABBC3CF284D29447F1857D80F7497";
            var addr0 = GetAddressFromPublicKey(pubKey);
            Assert.AreEqual(expectedAddr, addr0);
            var addr1 = CryptoUtil.GetAddressFromPublicKey(pubKey);
            Assert.AreEqual(expectedAddr, addr1);
        }

        [TestMethod]
        public void ByteUtil_HexStringToByteArray_Correct()
        {
            var hexSource = "0x032CE5279A0E9F4B383C98C9CBAAFE84F8B6FABBC3CF284D29447F1857D80F7497";

            var byteUtilBytes = ByteUtil.HexStringToByteArray(hexSource);
            var correctBytes = HexStringToByteArray(hexSource);
            Assert.IsTrue(byteUtilBytes.SequenceEqual(correctBytes));

            var byteUtilHex = ByteUtil.ByteArrayToHexString(byteUtilBytes);
            var correctHex = ByteArrayToHexString(correctBytes);
            Assert.AreEqual(correctHex, byteUtilHex);
        }

        public static string GetAddressFromPublicKey(string publicKey)
        {
            var hexString = publicKey.Replace(" ", "").ToLower().Replace("0x", "");
            byte[] byteArrayFromHex = new byte[hexString.Length / 2];
            for (int i = 0; i < hexString.Length; i += 2)
            {
                byteArrayFromHex[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
            }

            string addressHex;
            using (SHA256 sha = SHA256.Create())
            {
                var addressByteArray = sha.ComputeHash(byteArrayFromHex);
                StringBuilder sb = new StringBuilder(addressByteArray.Length * 3);
                foreach (byte b in addressByteArray)
                {
                    sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
                }
                addressHex = sb.ToString().ToUpper().Replace(" ", "");

            }
            return addressHex.Substring(24).ToLower();
        }

        public static string ByteArrayToHexString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder(bytes.Length * 3);
            foreach (byte b in bytes)
            {
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            }
            return sb.ToString().ToUpper().Replace(" ", "");
        }

        public static byte[] HexStringToByteArray(string hexString)
        {
            hexString = hexString.Replace(" ", "").ToLower().Replace("0x", "");
            byte[] byteArrayFromHex = new byte[hexString.Length / 2];
            for (int i = 0; i < hexString.Length; i += 2)
            {
                byteArrayFromHex[i / 2] = (byte)Convert.ToByte(hexString.Substring(i, 2), 16);
            }
            return byteArrayFromHex;

        }

        public static byte[] Sha256(byte[] bytes)
        {
            using (SHA256 sha = new SHA256Managed())
            {
                return sha.ComputeHash(bytes);
            }
        }

    }
}
