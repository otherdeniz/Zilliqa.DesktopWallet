using Zillifriends.Shared.Common;
using Zilligraph.Database.Storage.FilterQuery;
using Zilliqa.DesktopWallet.ApiClient.Utils;
using Zilliqa.DesktopWallet.Core.Repository;
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
            var transactions = transactionTable.FindRecords(filter).Take(10).ToList();
            Assert.AreEqual(10, transactions.Count);
            var trx = transactions[8];
            var fromBech32 = trx.SenderAddress.FromBase16ToBech32Address();
            var ownerAddress = trx.DataContractDeploymentParams.First(p => p.Vname == "owner").ResolvedValue
                .ToString();
            var ownerBech32 = ownerAddress.FromBase16ToBech32Address();
        }
    }
}
