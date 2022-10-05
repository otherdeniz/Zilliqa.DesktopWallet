using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.DatabaseSchema;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values
{
    public static class ValueSelectionHelper
    {
        public static bool IsSelectableGridCell(Type valueType)
        {
            return valueType == typeof(AddressValue)
                   || valueType == typeof(Zrc2TokenValue)
                   || valueType == typeof(BlockNumberValue);
        }

        public static Control CreateDisplayControl(object value, bool displayTabs = true)
        {
            var viewModel = value;
            if (value is AddressValue addressValue)
            {
                if (addressValue.SmartContract != null)
                {
                    viewModel = new SmartContractViewModel(addressValue.SmartContract);
                }
                else
                {
                    var control = new AddressDetailsControl();
                    var vm = new AccountViewModel(WatchedAccount.Create(addressValue.Address),
                        _ => control.RefreshAccountSummaries(),
                        false);
                    control.BindAccountViewModel(vm, true);
                    return control;
                }
            }
            else if (value is ScillaCodeValue scillaCode)
            {
                return new ScillaCodeTextBox
                {
                    Text = scillaCode.Code
                };
            }
            else if (value is TransactionReceipt transactionReceipt)
            {
                return new PropertyGrid
                {
                    HelpVisible = false,
                    PropertySort = PropertySort.NoSort,
                    ToolbarVisible = false,
                    SelectedObject = transactionReceipt
                };
            }
            else if (value is BlockNumberValue blockNumberValue)
            {
                try
                {
                    viewModel = new BlockViewModel(blockNumberValue.BlockNumber);
                }
                catch (Exception e)
                {
                    viewModel = new ErrorDetailsViewModel(e.Message);
                }
            }
            else if (value is TransactionRowViewModelBase transactionRowViewModel)
            {
                viewModel = new TransactionDetailsViewModel(transactionRowViewModel.Transaction);
            }
            else if (value is TransactionIdValue transactionId)
            {
                try
                {
                    viewModel = new TransactionDetailsViewModel(transactionId.GetTransaction());
                }
                catch (Exception e)
                {
                    viewModel = new ErrorDetailsViewModel(e.Message);
                }
            }
            else if (value is Transaction transactionModel)
            {
                viewModel = new TransactionDetailsViewModel(transactionModel);
            }
            else if (value is Zrc2TokenValue tokenValue)
            {
                var tokenModel = tokenValue.TokenModel;
                viewModel = tokenModel == null
                    ? new ErrorDetailsViewModel($"Token '{tokenValue.Symbol}' not found")
                    : new TokenDetailsViewModel(tokenModel);
            }
            else if (value is TokenBalanceRowViewModel tokenBalanceRow)
            {
                viewModel = new TokenDetailsViewModel(tokenBalanceRow.Model);
            }
            else if (value is TokenRowViewModel tokenRow)
            {
                viewModel = new TokenDetailsViewModel(tokenRow.Model);
            }
            var genericControl = new GenericDetailsControl(displayTabs);
            genericControl.LoadViewModel(viewModel);
            return genericControl;
        }

        public static string GetValueTitle(object value)
        {
            if (value is AddressValue addressValue)
            {
                if (addressValue.SmartContract != null)
                {
                    return $"Contract: {addressValue.SmartContract.DisplayName()}";
                }
                return $"Address: {addressValue}";
            }
            if (value is Transaction transaction)
            {
                return $"Transaction: {transaction.Id}";
            }
            if (value is IDetailsLabel detailsLabel)
            {
                return detailsLabel.GetDisplayTitle();
            }
            return $"{value}";
        }

        public static string GetValueUniqueId(object value)
        {
            if (value is AddressValue addressValue)
            {
                if (addressValue.SmartContract != null)
                {
                    return $"Contract-{addressValue.Address.GetBech32().FromBech32ToShortReadable()}";
                }
                return $"Addr-{addressValue.Address.GetBech32()}";
            }
            if (value is Address address)
            {
                return $"Addr-{address.GetBech32()}";
            }
            if (value is Transaction transaction)
            {
                return $"Trx-{transaction.Id}";
            }
            if (value is IDetailsLabel detailsLabel)
            {
                return detailsLabel.GetUniqueId();
            }
            return $"{value}";
        }
    }
}
