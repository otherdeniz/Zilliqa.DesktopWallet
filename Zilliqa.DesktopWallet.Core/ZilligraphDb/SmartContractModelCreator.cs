using System.Text.RegularExpressions;
using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.Api;
using Zilliqa.DesktopWallet.Core.ContractCode;
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
                    .Select(p =>
                    {
                        var addr = p.Value.ToString()?.ToLower();
                        if (addr?.StartsWith("0x") == true)
                        {
                            addr = addr.Substring(2);
                        }
                        return addr;
                    })
                    .FirstOrDefault();
                smartContract.OwnerAddress = ownerAddress ?? deploymentTransaction.SenderAddress;

                var scillaParser = new ScillaParser(deploymentTransaction.GetPatchedCode() ?? string.Empty);
                var contratName = scillaParser.ParseContractName();
                if (contratName != null)
                {
                    smartContract.ContractName = contratName;
                }

                smartContract.StateFields = scillaParser.ParseFields();

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
                    || smartContract.ContractName == LibraryNames.FungibleToken)
                {
                    smartContract.SmartContractType = (int)SmartContractType.FungibleToken;
                }
                else if (smartContract.ContractName == LibraryNames.NonfungibleToken)
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
