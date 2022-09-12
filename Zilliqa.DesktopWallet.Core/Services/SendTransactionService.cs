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

        public static SendTransactionService Instance { get; } = new();

        private SendTransactionService()
        {
        }

        public Transaction.Info SendZilToAddress(AddressValue toAddress, decimal amount, string senderPrivateKey)
        {
            return SendZilToAddress(toAddress, amount, new Account(senderPrivateKey));
        }

        public Transaction.Info SendZilToAddress(AddressValue toAddress, decimal amount, Account senderAccount)
        {
            return Task.Run(async () => await SendZilToAddressAsync(toAddress, amount, senderAccount))
                .GetAwaiter().GetResult();
        }

        public async Task<Transaction.Info> SendZilToAddressAsync(AddressValue toAddress, decimal amount, Account senderAccount)
        {
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
                tx.SetVersion(true);
                var signed = await SignWithAsync(tx, senderAccount, true);
                return await ZilliqaClient.DefaultInstance.CreateTransaction(signed);
            }
            catch (Exception e)
            {
                return new Transaction.Info
                {
                    InfoMessage = e.Message
                };
            }
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
}
