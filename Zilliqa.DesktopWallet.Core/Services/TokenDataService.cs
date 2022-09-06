using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.ApiClient.ZilstreamApi;
using Zilliqa.DesktopWallet.ApiClient.ZilstreamApi.Model;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Extensions;

namespace Zilliqa.DesktopWallet.Core.Services
{
    public class TokenDataService
    {
        public static TokenDataService Instance { get; } = new();

        private List<TokenModel>? _tokenModels;
        private Dictionary<string, TokenModel>? _tokenAddressDictionary;

        public IEnumerable<TokenModel> GetTokens(bool forceLoad)
        {
            if (_tokenModels == null || forceLoad)
            {
                var client = new ZilstreamApiClient();
                var tokensResult = Task.Run(async () => await client.GetTokensAsync()).GetAwaiter().GetResult();
                _tokenModels = tokensResult.Select(t => t.MapToModel<ZilstreamToken, TokenModel>()).ToList();
            }

            return _tokenModels;
        }

        public TokenModel? GetToken(string symbol)
        {
            var symbolLowered = symbol.ToLower();
            return GetTokens(false).AsList().FirstOrDefault(t => t.Symbol.ToLower() == symbolLowered);
        }

        public TokenModel? FindTokenByAddress(string tokenAddress)
        {
            return FindTokenByAddress(new Address(tokenAddress));
        }

        public TokenModel? FindTokenByAddress(Address tokenAddress)
        {
            if (_tokenAddressDictionary == null)
            {
                _tokenAddressDictionary = GetTokens(false).ToDictionary(k => k.AddressBech32, e => e);
            }

            if (_tokenAddressDictionary.TryGetValue(tokenAddress.GetBech32(), out var token))
            {
                return token;
            }

            return null;
        }
    }
}
