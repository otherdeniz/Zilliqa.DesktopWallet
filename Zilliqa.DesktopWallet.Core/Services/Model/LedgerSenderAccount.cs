using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.ApiClient.Model;
using Zilliqa.DesktopWallet.Core.Data.Model;

namespace Zilliqa.DesktopWallet.Core.Services.Model
{
    public class LedgerSenderAccount : ISenderAccount
    {
        /// <summary>
        /// void SignTransactionDelegate(MyAccount account, TransactionPayload transaction, string recipient, string transactionPayload)
        /// </summary>
        public static Action<MyAccount, TransactionPayload, string, string>? SignTransactionDelegate { get; set; }

        public LedgerSenderAccount(MyAccount account)
        {
            if (account.Type != MyAccountType.LedgerWallet)
            {
                throw new RuntimeException($"Account '{account.Name}' must be of type 'LedgerWallet'");
            }
            Account = account;
        }

        public MyAccount Account { get; }

        public void Sign(TransactionPayload transaction, string recipient, string transactionPayload)
        {
            transaction.PubKey = Account.PublicKey;
            SignTransactionDelegate?.Invoke(Account, transaction, recipient, transactionPayload);
        }
    }
}
