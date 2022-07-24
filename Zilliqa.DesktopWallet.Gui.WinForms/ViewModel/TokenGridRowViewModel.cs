using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Extensions;

namespace Zilliqa.DesktopWallet.Gui.WinForms.ViewModel
{
    public class TokenGridRowViewModel
    {
        private readonly TokenModel _model;

        public TokenGridRowViewModel(TokenModel model)
        {
            _model = model;
        }

        public Image? Icon => _model.GetTokenIcon().Icon16;

        public string Symbol => _model.Symbol;

        public string Name => _model.Name;

        public decimal PriceUsd => _model.MarketData.RateUsd;
    }
}
