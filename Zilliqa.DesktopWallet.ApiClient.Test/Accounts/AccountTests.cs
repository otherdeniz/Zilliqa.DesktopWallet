using System;
using NUnit.Framework;
using Zilliqa.DesktopWallet.ApiClient.Accounts;
using Zilliqa.DesktopWallet.ApiClient.Crypto;

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
            var json = _account.ToJsonFile("a8f8f4c1e76e09c61dfeac0e1f73cf48c58bff0de81243a20a1ff087dc5fa08a","Tester42",KDFType.PBKDF2);
            Assert.IsTrue(json.Length > 0);
        }
    }
}