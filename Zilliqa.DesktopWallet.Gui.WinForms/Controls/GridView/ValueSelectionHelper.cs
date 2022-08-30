using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView
{
    public static class ValueSelectionHelper
    {
        public static bool IsSelectableCell(Type valueType)
        {
            return valueType == typeof(AddressValue)
                   || valueType == typeof(Zrc2TokenValue)
                   || valueType == typeof(BlockNumberValue);
        }

        public static string GetValueUniqueId(object value)
        {
            if (value is AddressValue addressValue)
            {
                return $"Addr-{addressValue.Address.GetBech32()}";
            }
            if (value is Address address)
            {
                return $"Addr-{address.GetBech32()}";
            }
            if (value is Zrc2TokenValue zrc2TokenValue)
            {
                return $"Token-{zrc2TokenValue.Symbol}";
            }
            if (value is TokenModel tokenModel)
            {
                return $"Token-{tokenModel.Symbol}";
            }
            if (value is BlockNumberValue blockNumber)
            {
                return $"Block-{blockNumber.BlockNumber}";
            }
            if (value is TransactionRowViewModelBase transactionRowViewModelBase)
            {
                return $"Trx-{transactionRowViewModelBase.Transaction.Id}";
            }
            if (value is Transaction transaction)
            {
                return $"Trx-{transaction.Id}";
            }
            // generate unique id
            return Guid.NewGuid().ToString("N");
        }
    }
}
