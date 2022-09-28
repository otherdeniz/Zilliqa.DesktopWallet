using System.Text.RegularExpressions;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.Api;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Core.ZilligraphDb
{
    public static class SmartContractModelCreator
    {
        public static class LibraryNames
        {
            public const string FungibleToken = "FungibleToken";
            public const string NonfungibleToken = "NonfungibleToken";
        }

        private static readonly Regex ContractNameRegEx =
            new Regex(@"^\s*contract\s+(\w+)", RegexOptions.Multiline | RegexOptions.Compiled);
        private static readonly Regex ContractNameSingleLineRegEx =
            new Regex(@"\s+contract\s+(\w+)\s*\(", RegexOptions.Compiled);
        private static readonly Regex FieldRegEx =
            new Regex(@"^\s*field\s+(\w+)\s*:", RegexOptions.Multiline | RegexOptions.Compiled);

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

                var patchedCode = deploymentTransaction.GetPatchedCode() ?? string.Empty;
                var contractNameMatch = ContractNameRegEx.Match(patchedCode);
                if (contractNameMatch.Success)
                {
                    smartContract.ContractLibrary = contractNameMatch.Groups[1].Value;
                }
                else
                {
                    var contractNameSingleLineMatch = ContractNameSingleLineRegEx.Match(patchedCode);
                    if (contractNameSingleLineMatch.Success)
                    {
                        smartContract.ContractLibrary = contractNameSingleLineMatch.Groups[1].Value;
                    }
                    else
                    {
                        return null;
                    }
                }

                smartContract.StateFields = FieldRegEx.Matches(patchedCode)
                    .Select(f => f.Groups[1].Value)
                    .ToArray();

                var contractAddress = ApiRetryCalls.RetryTaskTillCompleted<Address>(() =>
                        ZilliqaClient.DefaultInstance
                            .GetContractAddressFromTransactionID(deploymentTransaction.Id)
                    )?.GetBase16(false);
                if (contractAddress == null)
                {
                    return null;
                }
                smartContract.ContractAddress = contractAddress;

                if (smartContract.TokenDecimals() > 0 
                    || smartContract.ContractLibrary == LibraryNames.FungibleToken)
                {
                    smartContract.SmartContractType = (int)SmartContractType.FungibleToken;
                }
                else if (smartContract.ContractLibrary == LibraryNames.NonfungibleToken)
                {
                    smartContract.SmartContractType = (int)SmartContractType.NonfungibleToken;
                }
                else if (smartContract.StateFields.Any(f => f == "pools"))
                {
                    smartContract.SmartContractType = (int)SmartContractType.DecentralisedExchange;
                }
                else
                {
                    smartContract.SmartContractType = (int)SmartContractType.GenericDapp;
                }

                return smartContract;
            }

            return null;
        }
    }
}
