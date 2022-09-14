using System.Text.RegularExpressions;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.Api;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Core.ZilligraphDb
{
    public static class SmartContractModelCreator
    {
        private static readonly Regex ContractNameRegEx =
            new Regex(@"^contract (\w+)", RegexOptions.Multiline | RegexOptions.Compiled);

        public static SmartContract? CreateModel(Transaction deploymentTransaction)
        {
            if (deploymentTransaction.TransactionTypeEnum == TransactionType.ContractDeployment
                && !deploymentTransaction.TransactionFailed)
            {
                var smartContract = new SmartContract
                {
                    Timestamp = deploymentTransaction.Timestamp,
                    DeploymentTransactionId = deploymentTransaction.Id,
                    ConstructorValues = deploymentTransaction.DataContractDeploymentParams
                };

                var ownerAddress = deploymentTransaction.DataContractDeploymentParams
                    .Where(p => p.Vname == "owner")
                    .Select(p => p.Value.ToString()?.ToLower())
                    .FirstOrDefault();
                if (ownerAddress == null)
                {
                    return null;
                }
                smartContract.OwnerAddress = ownerAddress;

                var contractNameMatch = ContractNameRegEx.Match(deploymentTransaction.Code);
                if (!contractNameMatch.Success)
                {
                    return null;
                }
                smartContract.ContractName = contractNameMatch.Groups[1].Value;

                smartContract.ContractAddress = ApiRetryCalls.RetryTaskTillCompleted<Address>(() =>
                        ZilliqaClient.DefaultInstance.GetContractAddressFromTransactionID(deploymentTransaction.Id))
                    ?.GetBase16(false);

                return smartContract;
            }

            return null;
        }

    }
}
