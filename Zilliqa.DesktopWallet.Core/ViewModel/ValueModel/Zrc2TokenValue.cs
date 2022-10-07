using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Services;

namespace Zilliqa.DesktopWallet.Core.ViewModel.ValueModel
{
    public class Zrc2TokenValue : IDetailsLabel, IDetailsViewModel
    {
        private TokenModel? _tokenModel;
        private readonly string? _displayText;

        public Zrc2TokenValue(TokenModel tokenModel)
        {
            _tokenModel = tokenModel;
            _displayText = $"{tokenModel.Name} ({tokenModel.Symbol})";
            Symbol = tokenModel.Symbol;
        }
        public Zrc2TokenValue(string symbol, string? displayText = null)
        {
            _displayText = displayText;
            Symbol = symbol;
        }

        public string Symbol { get; }

        public TokenModel? TokenModel => _tokenModel ??= TokenDataService.Instance.GetToken(Symbol);

        public override string ToString()
        {
            return _displayText ?? Symbol;
        }

        public object GetViewModel()
        {
            return TokenModel == null
                ? new ErrorDetailsViewModel($"Token '{Symbol}' not found")
                : new TokenDetailsViewModel(TokenModel);

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
