using System;
using NUnit.Framework;

namespace Zilliqa.DesktopWallet.ApiClient.Test.Accounts
{
    public class WalletTests : MusTest
    {

        [Test]
        public void CreateWalletHasAccount()
        {
            Assert.AreNotEqual(null, _wallet);
        }
        [Test]
        public void GetBalanceFromWalletNotNegative()
        {
            var balance = _wallet.GetBalance(_account);
            var amount = balance.GetBalance();
            Console.WriteLine($"Balance is {amount}");
            Assert.AreNotEqual(-1, amount);
        }
    }
}
