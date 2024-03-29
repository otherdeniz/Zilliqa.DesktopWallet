﻿using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Zilliqa.DesktopWallet.ApiClient.Test.IntegrationTests
{
    public class AcountTests : MusTest
    {

        [Test]
        public async Task GetBalanceWithAccount()
        {
            var res = await _zil.GetBalance(_account);
            var bal = res.GetBalance();
            Console.WriteLine($"Account balance is: {bal}");
            Assert.IsFalse(bal < 0);
        }
        [Test]
        public async Task GetBalanceWithAddress()
        {
            var res = await _zil.GetBalance(_address);
            Assert.IsFalse(res.GetBalance() < 0);
        }
        [Test]
        public async Task GetBalanceWithString()
        {
            var res = await _zil.GetBalance("4C352ba2Bd33245CDA180699e6B5c6334AB5dC26");
            Assert.IsFalse(res.GetBalance() < 0);
        }


    }
}
