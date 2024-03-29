﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Zilliqa.DesktopWallet.ApiClient.API;
using Zilliqa.DesktopWallet.ApiClient.Model;
using Zilliqa.DesktopWallet.ApiClient.Utils;
using Zilliqa.DesktopWallet.DatabaseSchema.ParsedData;

namespace Zilliqa.DesktopWallet.ApiClient.Test.IntegrationTests
{
    public class TransactionTests : MusTest
    {
        [SetUp]
        public void Initialize()
        {
            
        }

        [Test]
        public async Task MinGasPriceNotZero()
        {
            var gas = await _zil.GetMinimumGasPrice();
            Console.WriteLine($"Minimum gas price: {gas}");
            Assert.AreNotEqual(0,gas);
        }
        [Test]
        public async Task GetNumTxnsDSEpochNotNegative()
        {
            var num = await _zil.GetNumTxnsDSEpoch();
            Console.WriteLine($"Number of transactions in DS Epoch: {num}");
            Assert.AreNotEqual(-1, num);
        }
        [Test]
        public async Task GetNumTxnsTxEpochNotNegative()
        {
            var num = await _zil.GetNumTxnsTxEpoch();
            Console.WriteLine($"Number of transactions in Tx Epoch: {num}");
            Assert.IsTrue(num >= 0);
        }
        [Test]
        public async Task GetTxnBodiesForTxBlockNotEmpty()
        {
            var txns = await _zil.GetTxnBodiesForTxBlock(175334);
            Assert.IsTrue(txns.Any());
        }

        [Test]
        public async Task GetTransactionsForTxBlockNotEmpty()
        {
            var txns = await _zil.GetTransactionsForTxBlock(175334);
            Assert.IsTrue(txns.Any());
        }

        [Test]
        public async Task GetRecentTransactionsNotEmpty()
        {
            var txns = await _zil.GetRecentTransactions();
            Assert.IsTrue(txns.Any());
        }

        [Test]
        public async Task GetPendingTxnsNotEmpty()
        {
            var txns = await _zil.GetPendingTxns();
            Assert.IsTrue(txns.Any());
        }

        [Test]
        public async Task GetPendingTxnHashNotEmpty()
        {
            var txns = await _zil.GetPendingTxns();
            var txn = txns[0];
            var ftxns = await _zil.GetPendingTxn(txn.Hash);
            Assert.IsTrue(txns.Any());
        }

        [Test]
        public async Task GetTransactionNotNull()
        {
            var hash = "31e7e37c4761e647cb2fedd50105c482bb33a45635d83a8fb603a836faaa9ce8"; //"655107c300e86ee6e819af1cbfce097db1510e8cd971d99f32ce2772dcad42f2";
            var zilClient = new ZilliqaClient(false); // mainnet
            var txn = await zilClient.GetTransaction(hash);
            //var txn = await _zil.GetTransaction(hash);
            Assert.IsTrue(txn != null);
        }

        [Test]
        public async Task GetTransactionTokenTransfer()
        {
            var hash = "eef046b8d1ac7948caf6ee84409e36c1a919f314cebd40540e7ffe2b94314e32";
            var txn = await _zil.GetTransaction(hash);
            var bech32 = txn.Receipt.EventLogs[0].Address.FromBase16ToBech32Address();
            var gZiltokenAddress = "zil14pzuzq6v6pmmmrfjhczywguu0e97djepxt8g3e";
            Assert.AreEqual(gZiltokenAddress, bech32);
            var dataJToken = JToken.Parse(txn.Data);
            Assert.IsTrue(DataContractCall.TryParse(dataJToken, out var parsedData));
            Assert.AreEqual("Transfer", parsedData.Tag);
            Assert.AreEqual("TransferSuccess", txn.Receipt.EventLogs[0].Eventname);
        }

        [Test]
        public async Task GetTransactionContractDeployment()
        {
            var hash = "716f3edd55d23e70134f2687cf6fc3e70c4371a32aa871c4dbfbd74548c6a6f6";
            var txn = await _zil.GetTransaction(hash);
            var contractAddress = await _zil.GetContractAddressFromTransactionID(txn.Id);
            Assert.IsTrue(contractAddress.GetBech32().StartsWith("zil1"));
        }

        [Test]
        public async Task GetTransactionContractDeployment_MamboRewardToken()
        {
            var hash = "c4024c469d4f7131e93e4a902c08fcd6c505add5517beedafa78871ded3eccbd";
            var txn = await _zil.GetTransaction(hash);
            var contractAddress = await _zil.GetContractAddressFromTransactionID(txn.Id);
            Assert.IsTrue(contractAddress.GetBech32().StartsWith("zil1"));
        }

        //[Test]
        //public async Task CreateTransactionHasId()
        //{
        //    //TODO figure out how to create transaction tests with signatures

        //    var tx = new TransactionPayload() {
        //        ToAddr = "4C352ba2Bd33245CDA180699e6B5c6334AB5dC26",
        //        Amount = "1000000000000",
        //        GasPrice = "1000000000",
        //        GasLimit = "1",
        //        Code = "",
        //        Data = "",
        //        Priority = false
        //    };
        //    tx.SetVersion(true);
        //    var signed = _wallet.SignWith(tx,_account,true);
        //    var info = await _zil.CreateTransaction(signed);
        //    Assert.IsNotNull(info);
        //}

        [Test]
        public async Task SpecificBlockNumberReturnsAllTransactions()
        {
            var txns = await _zil.GetTxnBodiesForTxBlock(1664279);
            Assert.AreEqual(6, txns.Count);
        }
    }
}
