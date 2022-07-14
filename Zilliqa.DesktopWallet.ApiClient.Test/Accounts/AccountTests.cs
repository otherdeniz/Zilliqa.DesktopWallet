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
            var json = _account.ToJson("Tester123", KDFType.PBKDF2);
            Assert.IsTrue(json.Length > 0);
        }
    }
}