using System.Text.RegularExpressions;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.Api;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Core.ZilligraphDb
{
    public static class SmartContractModelCreator
    {
        private static readonly Regex ContractNameRegEx =
            new Regex(@"^\s*contract\s+(\w+)", RegexOptions.Multiline | RegexOptions.Compiled);
        private static readonly Regex ContractNameSingleLineRegEx =
            new Regex(@"\s+contract\s+(\w+)\s+\(", RegexOptions.Compiled);

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
                if (ownerAddress != null)
                {
                    smartContract.OwnerAddress = ownerAddress;
                }
                else
                {
                    smartContract.OwnerAddress = deploymentTransaction.SenderAddress;
                }

                var contractNameMatch = ContractNameRegEx.Match(deploymentTransaction.GetPatchedCode() ?? string.Empty);
                if (contractNameMatch.Success)
                {
                    smartContract.ContractName = contractNameMatch.Groups[1].Value;
                }
                else
                {
                    var contractNameSingleLineMatch = ContractNameSingleLineRegEx.Match(deploymentTransaction.GetPatchedCode() ?? string.Empty);
                    if (contractNameSingleLineMatch.Success)
                    {
                        smartContract.ContractName = contractNameSingleLineMatch.Groups[1].Value;
                    }
                    else
                    {
                        return null;
                    }
                }

                smartContract.ContractAddress = ApiRetryCalls.RetryTaskTillCompleted<Address>(() =>
                        ZilliqaClient.DefaultInstance.GetContractAddressFromTransactionID(deploymentTransaction.Id))
                    ?.GetBase16(false);

                return smartContract;
            }

            return null;
        }

    }
}
