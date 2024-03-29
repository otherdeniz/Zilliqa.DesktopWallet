﻿using Zillifriends.Shared.Common;
using Zilligraph.Database.Storage.FilterQuery;
using Zilliqa.DesktopWallet.ApiClient.Utils;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ZilligraphDb;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Core.Test
{
    [TestClass]
    public class DatabaseTest
    {
        [TestMethod]
        public void QueryTransactions_ContractDeployment()
        {
            DataPathBuilder.Setup(Path.Combine("ZilliqaDesktopWallet", "Debug"));

            var db = RepositoryManager.Instance.DatabaseRepository.Database;
            var transactionTable = db.GetTable<Transaction>();

            var filter = new FilterQueryField(nameof(Transaction.TransactionType),
                (int)TransactionType.ContractDeployment);
            var indexes = transactionTable.Indexes["TransactionType"].SearchIndexes(filter).Take(10).ToList();
            Assert.AreEqual(10, indexes.Count);
            var transactions = transactionTable.EnumerateRecords(filter).Take(10).ToList();
            Assert.AreEqual(10, transactions.Count);
            var trx = transactions[8];
            var fromBech32 = trx.SenderAddress.FromBase16ToBech32Address();
            var ownerAddress = trx.DataContractDeploymentParams.First(p => p.Vname == "owner").ResolvedValue
                .ToString();
            var ownerBech32 = ownerAddress.FromBase16ToBech32Address();
        }

        [TestMethod]
        public void ContractDeployment_ZilSwapDex_IsInDb()
        {
            var trxId = "716f3edd55d23e70134f2687cf6fc3e70c4371a32aa871c4dbfbd74548c6a6f6";

            DataPathBuilder.Setup(Path.Combine("ZilliqaDesktopWallet", "Debug"));

            var db = RepositoryManager.Instance.DatabaseRepository.Database;
            var transactionTable = db.GetTable<Transaction>();
            var smartContractTable = db.GetTable<SmartContract>();

            var deploymentTransaction = transactionTable.FindRecord("Id", trxId);
            var smartContract = smartContractTable.FindRecord("DeploymentTransactionId", trxId);
            Assert.IsNotNull(deploymentTransaction);
            Assert.IsNotNull(smartContract);
        }

        [TestMethod]
        public void ContractDeployment_DeploySmartContract_UnregularCode_IsParseable()
        {
            // this Contract-Code has many "end" statements and no new line before the "contract XXX" statement
            // its strange why these "end" statements even exist and are valid as used in this Contract-Code, but here we go
            var trxId = "638a6c4c7eb936e4dfc988c499dea1d0c19eca7aee04e672b0ef0df75b7a4117";
            DataPathBuilder.Setup(Path.Combine("ZilliqaDesktopWallet", "Debug"));

            var db = RepositoryManager.Instance.DatabaseRepository.Database;
            var transactionTable = db.GetTable<Transaction>();
            var deploymentTransaction = transactionTable.FindRecord("Id", trxId);

            var smartContract = SmartContractModelCreator.CreateModel(deploymentTransaction);
            Assert.IsNotNull(smartContract);
        }

        [TestMethod]
        public void ContractDeployment_DeploySmartContract_UnregularCode2_IsParseable()
        {
            // this Contract-Code is also edge-case
            var trxId = "3f02fbf8b068bf2ce3c728fd0ea28991b3b26f489805ec0a3bf3f3a043512746";
            DataPathBuilder.Setup(Path.Combine("ZilliqaDesktopWallet", "Debug"));

            var db = RepositoryManager.Instance.DatabaseRepository.Database;
            var transactionTable = db.GetTable<Transaction>();
            var deploymentTransaction = transactionTable.FindRecord("Id", trxId);

            var smartContract = SmartContractModelCreator.CreateModel(deploymentTransaction);
            Assert.IsNotNull(smartContract);
        }
    }
}
