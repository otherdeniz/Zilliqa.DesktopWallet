using Newtonsoft.Json;
using Zilligraph.Database.Storage.FilterQuery;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.ApiClient.Accounts;
using Zilliqa.DesktopWallet.ApiClient.Crypto;
using Zilliqa.DesktopWallet.ApiClient.Model;
using Zilliqa.DesktopWallet.Core.ContractCode;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.DatabaseSchema.ParsedData;

namespace Zilliqa.DesktopWallet.Core.Services
{
    public class SendTransactionService
    {
        public static readonly string ContractDeploymentAddress = "0000000000000000000000000000000000000000";
        public static readonly int GasLimitZilTransfer = 50;
        public static readonly int GasLimitDefaultContractCall = 30000;
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

        public SendTransactionResult CallContract(Account senderAccount,
            AddressValue contractAddress,
            string method,
            List<DataParam>? parameters = null,
            decimal zilAmount = 0,
            int? gasLimit = null)
        {
            var contractCall = new DataContractCall
            {
                Tag = method,
                Params = parameters ?? new List<DataParam>()
            };
            return CallContract(senderAccount, contractAddress, contractCall, zilAmount, gasLimit);
        }

        public SendTransactionResult CallContract(Account senderAccount, 
            AddressValue contractAddress, 
            DataContractCall contractCall, 
            decimal zilAmount = 0, 
            int? gasLimit = null)
        {
            var result = new SendTransactionResult(senderAccount.Address, contractAddress.Address,
                $"Call contract method '{contractCall.Tag}'");
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
                    var signed = await SignWithAsync(tx, senderAccount, true);
                    var info = await ZilliqaClient.DefaultInstance.CreateTransaction(signed);
                    result.Success = true;
                    result.Message = info.InfoMessage;
                    result.TransactionId = info.TransactionId;
                }
                catch (Exception e)
                {
                    result.Success = false;
                    result.Message = e.Message;
                }
            }).GetAwaiter().GetResult();
            return result;
        }

        public SendTransactionResult DeployContract(Account senderAccount,
            string scillaCode,
            List<DataParam>? constructorArguments = null,
            int? gasLimit = null)
        {
            var contractName = new ScillaParser(scillaCode).ContractName?.Name;
            var result = new SendTransactionResult(senderAccount.Address, new Address(ContractDeploymentAddress),
                $"Deploy Smart Contract '{contractName}'");
            gasLimit ??= GasLimitDefaultContractCall;
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
                    var signed = await SignWithAsync(tx, senderAccount, true);
                    var info = await ZilliqaClient.DefaultInstance.CreateTransaction(signed);
                    result.Success = true;
                    result.Message = info.InfoMessage;
                    result.TransactionId = info.TransactionId;
                }
                catch (Exception e)
                {
                    result.Success = false;
                    result.Message = e.Message;
                }
            }).GetAwaiter().GetResult();
            return result;
        }

        public SendTransactionResult SendTokenToAddress(Account senderAccount, AddressValue toAddress,
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

        public SendTransactionResult SendZilToAddress(string senderPrivateKey, AddressValue toAddress, decimal amount)
        {
            return SendZilToAddress(new Account(senderPrivateKey), toAddress, amount);
        }

        public SendTransactionResult SendZilToAddress(Account senderAccount, AddressValue toAddress, decimal amount)
        {
            return Task.Run(async () => await SendZilToAddressAsync(senderAccount, toAddress, amount))
                .GetAwaiter().GetResult();
        }

        public async Task<SendTransactionResult> SendZilToAddressAsync(Account senderAccount, AddressValue toAddress, decimal amount)
        {
            var result = new SendTransactionResult(senderAccount.Address, toAddress.Address,
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
                var signed = await SignWithAsync(tx, senderAccount, true);
                var info = await ZilliqaClient.DefaultInstance.CreateTransaction(signed);
                result.Success = true;
                result.Message = info.InfoMessage;
                result.TransactionId = info.TransactionId;
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Message = e.Message;
            }
            return result;
        }

        public async Task<TransactionPayload> SignWithAsync(TransactionPayload transaction, Account signer, bool getNonce = false)
        {
            if (transaction.ToAddr.ToUpper().StartsWith("0X"))
            {
                transaction.ToAddr = transaction.ToAddr.Substring(2);
            }

            if (signer == null)
            {
                throw new Exception("account not exists");
            }
            try
            {
                if (getNonce)
                {
                    if (_nonceCache == null
                        || _nonceCache.Value.Timestamp < DateTime.Now.AddSeconds(-30)
                        || _nonceCache.Value.Address != signer.Address.GetBase16(false))
                    {
                        var addressBalance = await ZilliqaClient.DefaultInstance.GetBalance(signer.Address);
                        _nonceCache = (DateTime.Now, signer.Address.GetBase16(false), (int)addressBalance.Nonce + 1);
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
                throw new Exception("cannot get nonce", e);
            }

            transaction.PubKey = signer.GetPublicKey();
            byte[] message = transaction.Encode();
            Signature signature = Schnorr.Sign(signer.KeyPair, message);
            transaction.Signature = (signature.ToString().ToLower());
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
        public bool Success { get; set; }
        public string? Message { get; set; }
        public string? TransactionId { get; set; }
    }
}
