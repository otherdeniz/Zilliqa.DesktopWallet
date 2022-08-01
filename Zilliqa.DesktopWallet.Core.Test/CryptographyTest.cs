using Zilliqa.DesktopWallet.Core.Cryptography;

namespace Zilliqa.DesktopWallet.Core.Test
{
    [TestClass]
    public class CryptographyTest
    {
        [TestMethod]
        public void Md5IsCorrect()
        {
            var value = "This a text that we use to make a hash :)";
            var md5Hex = value.GetMD5Hex();
            Assert.AreEqual("012DC8E502642927C2661699C118BCB4", md5Hex);
            var md5Bytes = value.GetMD5();
            Assert.AreEqual(md5Hex, Convert.ToHexString(md5Bytes));
        }
    }
}