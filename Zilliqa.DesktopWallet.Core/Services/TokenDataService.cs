using Zilliqa.DesktopWallet.ApiClient.ZilstreamApi;
using Zilliqa.DesktopWallet.ApiClient.ZilstreamApi.Model;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Extensions;

namespace Zilliqa.DesktopWallet.Core.Services
{
    public class TokenDataService
    {
        public static TokenDataService Instance { get; } = new TokenDataService();

        public IEnumerable<TokenModel> GetTokens()
        {
            var client = new ZilstreamApiClient();
            var tokensResult = Task.Run(async () => await client.GetTokensAsync()).GetAwaiter().GetResult();
            return tokensResult.Select(t => t.MapToModel<ZilstreamToken, TokenModel>());
        }
    }
}
