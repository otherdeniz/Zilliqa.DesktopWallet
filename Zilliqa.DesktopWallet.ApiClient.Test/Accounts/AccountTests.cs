using System;
using NUnit.Framework;
using Zilliqa.DesktopWallet.ApiClient.Accounts;
using Zilliqa.DesktopWallet.ApiClient.Crypto;
using Zilliqa.DesktopWallet.ApiClient.Utils;

namespace Zilliqa.DesktopWallet.ApiClient.Test.Accounts
{
    public class AccountTests : MusTest
    {
        [Test]
        public void TestAccountNoAddressThrowsException()
        {
            Assert.Throws<ArgumentException>(() => {
                var acc  = new Account("");
            });
        }
        [Test]
        public void AccountExportToJson()
        {
            var json = _account.ToJson("Tester123", KDFType.PBKDF2);
            Assert.IsTrue(json.Length > 0);
        }

        [Test]
        public void GetBech32FromHex()
        {
            var bech32 = "0xbea37a0fe8f759d5cfe2ba66913a676260175ba1".FromBase16ToBech32Address();
            Assert.AreEqual("zil1h63h5rlg7avatnlzhfnfzwn8vfspwkapzdy2aw", bech32);
        }
    }
}