using System;
using NUnit.Framework;
using Zilliqa.DesktopWallet.ApiClient.Utils;
using Zilliqa.DesktopWallet.ApiClient.ViewblockApi;

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

        //[Test]
        //public void GetAddressTransactions()
        //{
        //    var client = new ViewBlockApiClient(true);
        //    var transactions =
        //        client.GetTransactionsForAddress("zil1xxxxxx".FromBech32ToBase16Address());
        //    Assert.IsTrue(transactions.Count > 0);
        //}
    }
}
