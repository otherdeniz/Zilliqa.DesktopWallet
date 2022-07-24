using Zilliqa.DesktopWallet.ApiClient.ZilstreamApi;
using Zilliqa.DesktopWallet.ApiClient.ZilstreamApi.Model;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Extensions;

namespace Zilliqa.DesktopWallet.Core.Repository
{
    public class TokenRepository
    {
        public static TokenRepository Instance { get; } = new TokenRepository();

        public IEnumerable<TokenModel> GetTokens()
        {
            var client = new ZilstreamApiClient();
            var tokensResult = Task.Run(async () => await client.GetTokensAsync()).GetAwaiter().GetResult();
            return tokensResult.Select(t => t.MapToModel<ZilstreamToken, TokenModel>());
        }
    }
}
