using Zilliqa.DesktopWallet.ApiClient.Model;
using Zilliqa.DesktopWallet.Core.Data.Model;

namespace Zilliqa.DesktopWallet.Core.Services.Model
{
    public interface ISenderAccount
    {
        MyAccount Account { get; }

        void Sign(TransactionPayload transaction, string recipient, string details);
    }
}
