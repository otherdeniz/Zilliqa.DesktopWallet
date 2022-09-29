using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.ApiClient.Utils;
using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.Data.Images;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Core.ViewModel.DataSource;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Core.Services
{
    public class TokenDataService
    {
        public static TokenDataService Instance { get; } = new();

        private List<TokenModel>? _tokenModels;
        private Dictionary<string, TokenModel>? _tokenAddressDictionary;
        private bool _loading;
        private bool _tokenModelsLoaded;

        public List<TokenModel> TokenModels => _tokenModels ?? new List<TokenModel>();

        public bool TokenModelsLoaded => _tokenModelsLoaded;

        public void StartLoadTokens(bool forceReLoad = false)
        {
            if (_tokenModels != null && !forceReLoad) return;
            if (_loading) return;
            _loading = true;
            Task.Run(() =>
            {
                var tokenModels = new List<TokenModel>();
                try
                {
                    Logging.LogInfo("TokenDataService.StartLoadTokens: loading all Tokens from Cryptometa Assets");
                    foreach (var cryptometaAsset in CryptometaFile.Instance.Assets)
                    {
                        var tokenModel = tokenModels.FirstOrDefault(t => t.Symbol == cryptometaAsset.Symbol);
                        if (tokenModel == null)
                        {
                            tokenModel = new TokenModel
                            {
                                Symbol = cryptometaAsset.Symbol,
                                Name = cryptometaAsset.Name,
                                Icon = LogoImages.Instance.GetImage(cryptometaAsset.Bech32Address),
                                CryptometaAsset = cryptometaAsset
                            };
                            tokenModels.Add(tokenModel);
                        }
                    }
                    Logging.LogInfo("TokenDataService.StartLoadTokens: loading all Tokens from Smart Contracts");
                    foreach (var smartContract in RepositoryManager.Instance.DatabaseRepository.Database
                                 .GetTable<SmartContract>().EnumerateAllRecords()
                                 .Where(sc => sc.TokenSymbol() != null))
                    {
                        var contractSymbol = smartContract.TokenSymbol()!;
                        var contractAddressBech32 = smartContract.ContractAddress.FromBase16ToBech32Address();
                        var tokenModel = tokenModels.FirstOrDefault(t => t.Symbol == contractSymbol);
                        if (tokenModel == null)
                        {
                            tokenModel = new TokenModel
                            {
                                Symbol = contractSymbol,
                                Name = smartContract.TokenName() ?? string.Empty,
                                Icon = LogoImages.Instance.GetImage(contractAddressBech32)
                            };
                            tokenModels.Add(tokenModel);
                            KnownAddressService.Instance.AddUnique(contractAddressBech32, $"{tokenModel.Name.TokenNameShort()} ({tokenModel.Symbol.TokenSymbolShort()})");
                        }
                        tokenModel.ContractAddressesBech32.Add(contractAddressBech32);
                        tokenModel.SmartContractModels.Add(smartContract);
                    }
                }
                catch (Exception e)
                {
                    Logging.LogError("TokenDataService.StartLoadTokens failed", e);
                }

                _tokenModels = tokenModels
                    .OrderByDescending(t => t.CryptometaAsset?.Gen.Score ?? -1)
                    .ThenByDescending(t => t.CreatedDate ?? DateTime.MinValue)
                    .ToList();
                _tokenAddressDictionary = null;
                _tokenModelsLoaded = true;

                Logging.LogInfo("TokenDataService.StartLoadTokens: loading price-infos");
                _tokenModels.ForEach(t => t.LoadPriceProperties());
                Logging.LogInfo("TokenDataService.StartLoadTokens completed");

                _loading = false;
            });
        }

        public IPageableDataSource GetTokensDataSource()
        {
            //TODO: caching? (lets have a look, how long it takes to load)
            var dataSource = new PageableDataSource<TokenRowViewModel>();
            dataSource.Load(TokenModels.Select(t => new TokenRowViewModel(t)).ToList());
            return dataSource;
        }

        public TokenModel? GetToken(string symbol)
        {
            var symbolLowered = symbol.ToLower();
            return _tokenModels?.FirstOrDefault(t => t.Symbol.ToLower() == symbolLowered);
        }

        public TokenModelByAddress? FindTokenByAddress(string tokenAddress)
        {
            return FindTokenByAddress(new Address(tokenAddress));
        }

        public TokenModelByAddress? FindTokenByAddress(Address tokenAddress)
        {
            if (_tokenAddressDictionary == null && _tokenModels != null)
            {
                _tokenAddressDictionary = _tokenModels.SelectMany(t =>
                    t.ContractAddressesBech32.Select(a => (a, t))
                ).ToDictionary(k => k.a, e => e.t);
            }

            if (_tokenAddressDictionary?.TryGetValue(tokenAddress.GetBech32(), out var token) == true 
                && TokenModelByAddress.TryParse(token, tokenAddress.GetBech32(), out var tokenModelByAddress))
            {
                return tokenModelByAddress;
            }

            return null;
        }
    }
}
