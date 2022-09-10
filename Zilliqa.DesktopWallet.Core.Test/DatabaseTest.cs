using Zillifriends.Shared.Common;
using Zilligraph.Database.Storage.FilterQuery;
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
            var indexes = transactionTable.Indexes["TransactionType"].SearchIndexes(filter).ToList();
            //var transactions = transactionTable.FindRecords(filter).ToList();
            //Assert.IsTrue(transactions.Count > 0);
        }
    }
}
