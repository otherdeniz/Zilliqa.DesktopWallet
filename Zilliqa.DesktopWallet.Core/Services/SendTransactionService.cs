﻿using Newtonsoft.Json;
using Zillifriends.Shared.Common;
using Zilligraph.Database.Storage.FilterQuery;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.ApiClient.Model;
using Zilliqa.DesktopWallet.Core.ContractCode;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.Services.Model;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.DatabaseSchema.ParsedData;

namespace Zilliqa.DesktopWallet.Core.Services
{
    public class SendTransactionService
    {
        public static readonly string ContractDeploymentAddress = "0000000000000000000000000000000000000000";
        public static readonly int GasLimitZilTransfer = 50;
        public static readonly int GasLimitDefaultContractCall = 30000;
        public static readonly int GasLimitDefaultContractDeploy = 75000;
        private static int? _gasLimitDefaultTokenTransfer;
        private static int? _gasLimitDefaultDeployContract;
        public static int GasLimitDefaultTokenTransfer
        {
            get
            {
                if (_gasLimitDefaultTokenTransfer == null)
                {
                    var lastTransferTransaction = RepositoryManager.Instance.DatabaseRepository.Database
                        .GetTable<DatabaseSchema.Transaction>().FindLastRecord(
                            new FilterQueryField(nameof(DatabaseSchema.Transaction.ContractMethod), "Transfer"));
                    _gasLimitDefaultTokenTransfer =
                        Convert.ToInt32(lastTransferTransaction?.Receipt.CumulativeGas ?? GasLimitDefaultContractCall);
                }
                return _gasLimitDefaultTokenTransfer.Value;
            }
        }
        public static int GasLimitDefaultDeployContract
        {
            get
            {
                if (_gasLimitDefaultDeployContract == null)
                {
                    var lastDeployTransaction = RepositoryManager.Instance.DatabaseRepository.Database
                        .GetTable<DatabaseSchema.Transaction>().FindLastRecord(
                            new FilterQueryField(nameof(DatabaseSchema.Transaction.ToAddress), ContractDeploymentAddress));
                    _gasLimitDefaultDeployContract =
                        Convert.ToInt32(lastDeployTransaction?.Receipt.CumulativeGas ?? GasLimitDefaultContractCall);
                }
                return _gasLimitDefaultDeployContract.Value;
            }
        }

        public static SendTransactionService Instance { get; } = new();


        private static readonly JsonSerializerSettings DataSerializerSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.None,
            TypeNameHandling = TypeNameHandling.None
        };

        private (DateTime Timestamp, string Address, int Nonce)? _nonceCache;

        private SendTransactionService()
        {
        }

        public SendTransactionResult CallContract(ISenderAccount senderAccount,
            AddressValue contractAddress,
            string method,
            List<DataParam>? parameters = null,
            decimal zilAmount = 0,
            int? gasLimit = null,
            string? payloadInfo = null)
        {
            var contractCall = new DataContractCall
            {
                Tag = method,
                Params = parameters ?? new List<DataParam>()
            };
            return CallContract(senderAccount, contractAddress, contractCall, zilAmount, gasLimit, payloadInfo);
        }

        public SendTransactionResult CallContract(ISenderAccount senderAccount, 
            AddressValue contractAddress, 
            DataContractCall contractCall, 
            decimal zilAmount = 0, 
            int? gasLimit = null,
            string? payloadInfo = null)
        {
            var result = new SendTransactionResult(senderAccount.Account.Address, contractAddress.Address,
                payloadInfo ?? $"Call contract method '{contractCall.Tag}'");
            gasLimit ??= GasLimitDefaultContractCall;
            Task.Run(async () =>
            {
                try
                {
                    var tx = new TransactionPayload
                    {
                        ToAddr = contractAddress.GetAddressHexWithCheckSum(),
                        Amount = zilAmount.ZilToZilSatoshis().ToString("0"),
                        GasPrice = RepositoryManager.Instance.BlockchainBrowserRepository.MinimumGasPrice.ToString("0"),
                        GasLimit = gasLimit.ToString(),
                        Code = "",
                        Data = JsonConvert.SerializeObject(contractCall, DataSerializerSettings),
                        Priority = false
                    };
                    tx.SetVersion(ZilliqaClient.UseTestnet);
                    var signed = await SignWithAsync(tx, senderAccount, true, contractAddress, result.PayloadInfo);
                    var info = await ZilliqaClient.DefaultInstance.CreateTransaction(signed);
                    result.Success = true;
                    result.Message = info.InfoMessage;
                    result.TransactionId = info.TransactionId;
                }
                catch (TransactionCanceledException)
                {
                    result.Canceled = true;
                }
                catch (Exception e)
                {
                    result.Success = false;
                    result.Message = e.Message;
                }
            }).GetAwaiter().GetResult();
            return result;
        }

        public SendTransactionResult DeployContract(ISenderAccount senderAccount,
            string scillaCode,
            List<DataParam>? constructorArguments = null,
            int? gasLimit = null)
        {
            var contractName = new ScillaParser(scillaCode).ContractName?.Name;
            var result = new SendTransactionResult(senderAccount.Account.Address, new Address(ContractDeploymentAddress),
                $"Deploy Smart Contract '{contractName}'");
            gasLimit ??= GasLimitDefaultContractDeploy;
            Task.Run(async () =>
            {
                try
                {
                    var tx = new TransactionPayload
                    {
                        ToAddr = ContractDeploymentAddress,
                        Amount = "0",
                        GasPrice = RepositoryManager.Instance.BlockchainBrowserRepository.MinimumGasPrice.ToString("0"),
                        GasLimit = gasLimit.ToString(),
                        Code = scillaCode,
                        Data = JsonConvert.SerializeObject(constructorArguments, DataSerializerSettings),
                        Priority = false
                    };
                    tx.SetVersion(ZilliqaClient.UseTestnet);
                    var signed = await SignWithAsync(tx, senderAccount, true, new AddressValue(result.Recipient), result.PayloadInfo);
                    var info = await ZilliqaClient.DefaultInstance.CreateTransaction(signed);
                    result.Success = true;
                    result.Message = info.InfoMessage;
                    result.TransactionId = info.TransactionId;
                }
                catch (TransactionCanceledException)
                {
                    result.Canceled = true;
                }
                catch (Exception e)
                {
                    result.Success = false;
                    result.Message = e.Message;
                }
            }).GetAwaiter().GetResult();
            return result;
        }

        public SendTransactionResult SendTokenToAddress(ISenderAccount senderAccount, AddressValue toAddress,
            TokenModelByAddress tokenModelByAddress, decimal amount)
        {
            return CallContract(senderAccount, new AddressValue(tokenModelByAddress.ContractAddressBech32), "Transfer",
                new List<DataParam>
                {
                    new DataParam
                    {
                        Type = ParamTypes.Uint128,
                        Vname = "amount",
                        Value = tokenModelByAddress.SmartContract.AmountToTokenSatoshis(amount).ToString("0")
                    },
                    new DataParam
                    {
                        Type = ParamTypes.ByStr20,
                        Vname = "to",
                        Value = toAddress.Address.GetBase16(true)
                    }
                });
        }

        public SendTransactionResult SendZilToAddress(ISenderAccount senderAccount, AddressValue toAddress, decimal amount)
        {
            return Task.Run(async () => await SendZilToAddressAsync(senderAccount, toAddress, amount))
                .GetAwaiter().GetResult();
        }

        public async Task<SendTransactionResult> SendZilToAddressAsync(ISenderAccount senderAccount, AddressValue toAddress, decimal amount)
        {
            var result = new SendTransactionResult(senderAccount.Account.Address, toAddress.Address,
                $"Send {amount:#,##0.0000} ZIL");
            try
            {
                var tx = new TransactionPayload
                {
                    ToAddr = toAddress.GetAddressHexWithCheckSum(),
                    Amount = amount.ZilToZilSatoshis().ToString("0"),
                    GasPrice = RepositoryManager.Instance.BlockchainBrowserRepository.MinimumGasPrice.ToString("0"),
                    GasLimit = GasLimitZilTransfer.ToString(),
                    Code = "",
                    Data = "",
                    Priority = false
                };
                tx.SetVersion(ZilliqaClient.UseTestnet);
                var signed = await SignWithAsync(tx, senderAccount, true, toAddress, result.PayloadInfo);
                var info = await ZilliqaClient.DefaultInstance.CreateTransaction(signed);
                result.Success = true;
                result.Message = info.InfoMessage;
                result.TransactionId = info.TransactionId;
            }
            catch (TransactionCanceledException)
            {
                result.Canceled = true;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Message = e.Message;
            }
            return result;
        }

        public async Task<TransactionPayload> SignWithAsync(TransactionPayload transaction, 
            ISenderAccount senderAccount, 
            bool getNonce,
            AddressValue toAddress, 
            string details)
        {
            if (transaction.ToAddr.ToUpper().StartsWith("0X"))
            {
                transaction.ToAddr = transaction.ToAddr.Substring(2);
            }

            if (senderAccount == null)
            {
                throw new RuntimeException("account not exists");
            }
            try
            {
                if (getNonce)
                {
                    if (_nonceCache == null
                        || _nonceCache.Value.Timestamp < DateTime.Now.AddSeconds(-30)
                        || _nonceCache.Value.Address != senderAccount.Account.Address.GetBase16(false))
                    {
                        var addressBalance = await ZilliqaClient.DefaultInstance.GetBalance(senderAccount.Account.Address);
                        _nonceCache = (DateTime.Now, senderAccount.Account.Address.GetBase16(false), (int)addressBalance.Nonce + 1);
                    }
                    else
                    {
                        _nonceCache = (DateTime.Now, _nonceCache.Value.Address, _nonceCache.Value.Nonce + 1);
                    }
                    transaction.Nonce = _nonceCache.Value.Nonce;
                }
            }
            catch (Exception e)
            {
                throw new RuntimeException("cannot get nonce", e);
            }

            senderAccount.Sign(transaction, toAddress.ToString(), details);

            return transaction;
        }

    }

    
    public class SendTransactionResult
    {
        public SendTransactionResult(Address sender, Address recipient, string payloadInfo)
        {
            Sender = sender;
            Recipient = recipient;
            PayloadInfo = payloadInfo;
        }

        public Address Sender { get; }
        public Address Recipient { get; }
        public string PayloadInfo { get; }
        public bool Canceled { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
        public string? TransactionId { get; set; }
    }
}
