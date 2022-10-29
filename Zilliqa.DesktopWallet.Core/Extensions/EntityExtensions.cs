using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Core.Extensions
{
    public static class EntityExtensions
    {
        public static SmartContract? DeployedSmartContract(this Transaction transaction)
        {
            if (transaction.TransactionTypeEnum != TransactionType.ContractDeployment) return null;
            return RepositoryManager.Instance.DatabaseRepository.Database
                .GetTable<SmartContract>()
                .FindRecord(nameof(SmartContract.DeploymentTransactionId), transaction.Id);
        }
    }
}
