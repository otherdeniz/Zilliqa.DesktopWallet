﻿using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.DatabaseSchema;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView
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
            var genericControl = new GenericObjectControl();
            genericControl.LoadGenericViewModel(value);
            return genericControl;
        }

        public static string GetValueTitle(object value)
        {
            if (value is AddressValue addressValue)
            {
                return $"Address: {addressValue}";
            }
            if (value is Zrc2TokenValue zrc2TokenValue)
            {
                return $"Token: {zrc2TokenValue}";
            }
            if (value is BlockNumberValue blockNumber)
            {
                return $"Block: {blockNumber}";
            }
            if (value is TransactionRowViewModelBase transactionRowViewModelBase)
            {
                return $"Transaction: {transactionRowViewModelBase.Transaction.Id}";
            }
            return $"{value}";
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
