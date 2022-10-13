using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.ApiClient.Accounts;
using Zilliqa.DesktopWallet.ApiClient.Crypto;
using Zilliqa.DesktopWallet.ApiClient.Model;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;

namespace Zilliqa.DesktopWallet.Core.Services
{
    public class SendTransactionService
    {
        public static int GasLimitZilTransfer = 50;
        public static int GasLimitDefaultContractCall = 30000;

        public static SendTransactionService Instance { get; } = new();

        private SendTransactionService()
        {
        }

        public SendTransactionResult CallContract(Account senderAccount, 
            AddressValue contractAddress, 
            string method, 
            decimal zilAmount = 0, 
            object[]? arguments = null, 
            int? gasLimit = null)
        {
            var result = new SendTransactionResult(senderAccount.Address, contractAddress.Address,
                $"Call Contract method {method}");
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
                        Data = "",
                        Priority = false
                    };
                    tx.SetVersion(ZilliqaClient.UseTestnet);
                    var signed = await SignWithAsync(tx, senderAccount, true);
                    var info = await ZilliqaClient.DefaultInstance.CreateTransaction(signed);
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
                    var result = await ZilliqaClient.DefaultInstance.GetBalance(signer.Address);
                    transaction.Nonce = (int)result.Nonce + 1;
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
