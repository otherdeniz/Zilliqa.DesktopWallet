using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.ApiClient.Crypto;
using Zilliqa.DesktopWallet.ApiClient.Model;
using Zilliqa.DesktopWallet.Core.Data.Model;

namespace Zilliqa.DesktopWallet.Core.Services.Model
{
    public class PrivateKeySenderAccount : ISenderAccount
    {
        public PrivateKeySenderAccount(MyAccount account)
        {
            if (account.Type != MyAccountType.EncryptedPrivateKey)
            {
                throw new RuntimeException($"Account '{account.Name}' must be of type 'EncryptedPrivateKey'");
            }
            Account = account;
        }

        public MyAccount Account { get; }

        public void Sign(TransactionPayload transaction, string recipient, string details)
        {
            transaction.PubKey = Account.AccountDetails.GetPublicKey();
            byte[] message = transaction.Encode();
            Signature signature = Schnorr.Sign(Account.AccountDetails.KeyPair, message);
            transaction.Signature = (signature.ToString().ToLower());
        }

    }
}
