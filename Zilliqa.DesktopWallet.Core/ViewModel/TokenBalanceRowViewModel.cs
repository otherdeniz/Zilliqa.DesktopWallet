using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.ViewModel.Attributes;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class TokenBalanceRowViewModel : INotifyPropertyChanged
    {
        private Image? _icon;
        private decimal _balance;
        private int _transactions;

        public TokenBalanceRowViewModel(TokenModel tokenModel)
        {
            Model = tokenModel;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        [Browsable(false)]
        public TokenModel Model { get; }

        [DisplayName(" ")]
        public Image? Icon => _icon ??= Model.GetTokenIcon().Icon16;

        public string Symbol => Model.Symbol;

        public string Name => Model.Name;

        [DisplayName("Balance")]
        [GridViewFormat("#,##0.0000")] 
        public decimal BalanceDisplay => Balance < 0 ? 0 : Balance;

        [Browsable(false)]
        public decimal Balance
        {
            get => _balance;
            set
            {
                _balance = value;
                OnPropertyChanged(nameof(BalanceDisplay));
                OnPropertyChanged(nameof(ValueZil));
                OnPropertyChanged(nameof(ValueUsd));
            }
        }

        [DisplayName("Value ZIL")]
        [GridViewFormat("#,##0.00")]
        public decimal ValueZil => Model.MarketData.RateZil * BalanceDisplay;

        [DisplayName("Value USD")]
        [GridViewFormat("#,##0.00")]
        public decimal ValueUsd => Model.MarketData.RateUsd * BalanceDisplay;

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
