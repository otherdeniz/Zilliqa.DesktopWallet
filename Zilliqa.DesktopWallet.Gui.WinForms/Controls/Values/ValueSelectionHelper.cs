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

        public static Control CreateDisplayControl(object value)
        {
            if (value is AddressValue addressValue)
            {
                if (addressValue.SmartContract != null)
                {
                    var scViewModel = new SmartContractRowViewModel(addressValue.SmartContract);
                    var scControl = new SmartContractDetailsControl();
                    scControl.LoadSmartContract(scViewModel);
                    return scControl;
                }
                var control = new AddressDetailsControl();
                var vm = new AccountViewModel(WatchedAccount.Create(addressValue.Address),
                    _ => control.RefreshAccountSummaries(),
                    false);
                control.BindAccountViewModel(vm, true);
                return control;
            }
            if (value is BlockNumberValue blockNumberValue)
            {
                var control = new BlockDetailsControl();
                control.LoadBlock(blockNumberValue.BlockNumber);
                return control;
            }
            if (value is TransactionRowViewModelBase transactionRowViewModel)
            {
                var control = new TransactionDetailsControl();
                control.LoadTransaction(transactionRowViewModel);
                return control;
            }
            if (value is TransactionIdValue transactionId)
            {
                var control = new TransactionDetailsControl();
                control.LoadTransaction(transactionId);
                return control;
            }
            if (value is Zrc2TokenValue tokenValue)
            {
                var control = new TokenDetailsControl();
                control.LoadToken(tokenValue.Symbol);
                return control;
            }
            if (value is TokenBalanceRowViewModel tokenBalanceRow)
            {
                var control = new TokenDetailsControl();
                control.LoadToken(tokenBalanceRow.Model.Symbol);
                return control;
            }
            if (value is SmartContractRowViewModel smartContractRow)
            {
                var control = new SmartContractDetailsControl();
                control.LoadSmartContract(smartContractRow);
                return control;
            }
            var genericControl = new GenericDetailsControl();
            genericControl.LoadGenericViewModel(value);
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
            if (value is IDetailsViewModel detailsViewModel)
            {
                return detailsViewModel.GetDisplayTitle();
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
            if (value is IDetailsViewModel detailsViewModel)
            {
                return detailsViewModel.GetUniqueId();
            }
            // generate unique id
            return Guid.NewGuid().ToString("N");
        }
    }
}
