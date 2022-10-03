using Zilliqa.DesktopWallet.Core.Data.Model;

namespace Zilliqa.DesktopWallet.Core.ViewModel.ValueModel
{
    public class Zrc2TokenValue : IDetailsViewModel
    {
        private readonly string? _displayText;

        public Zrc2TokenValue(TokenModel tokenModel)
        {
            _displayText = $"{tokenModel.Name} ({tokenModel.Symbol})";
            Symbol = tokenModel.Symbol;
        }
        public Zrc2TokenValue(string symbol, string? displayText = null)
        {
            _displayText = displayText;
            Symbol = symbol;
        }

        public string Symbol { get; }

        public override string ToString()
        {
            return _displayText ?? Symbol;
        }

        public string GetUniqueId()
        {
            return $"Token-{Symbol}";
        }

        public string GetDisplayTitle()
        {
            return $"Token: {ToString()}";
        }
    }
}
