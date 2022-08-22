using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.ViewModel.Attributes;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class AccountTokenBalanceRowViewModel : INotifyPropertyChanged
    {
        private Image? _icon;
        private decimal _balance;
        private int _transactions;

        public AccountTokenBalanceRowViewModel(TokenModel tokenModel)
        {
            Model = tokenModel;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        [Browsable(false)]
        public TokenModel Model { get; }

        public Image? Icon => _icon ??= Model.GetTokenIcon().Icon16;

        public string Symbol => Model.Symbol;

        public string Name => Model.Name;

        [GridViewFormat("0.0000")]
        public decimal Balance
        {
            get => _balance;
            set
            {
                _balance = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValueZil));
                OnPropertyChanged(nameof(ValueUsd));
            }
        }

        [DisplayName("Value ZIL")]
        [GridViewFormat("0.00")]
        public decimal ValueZil => Model.MarketData.RateZil * Balance;

        [DisplayName("Value USD")]
        [GridViewFormat("0.00")]
        public decimal ValueUsd => Model.MarketData.RateUsd * Balance;

        public int Transactions
        {
            get => _transactions;
            set
            {
                _transactions = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
