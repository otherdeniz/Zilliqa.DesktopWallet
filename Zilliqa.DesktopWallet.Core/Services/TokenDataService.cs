﻿using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.ApiClient.Utils;
using Zilliqa.DesktopWallet.Core.Api.Coingecko.Model;
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

        public bool LoadCompleted => _tokenModelsLoaded;

        public string LoadingStatus { get; private set; } = "";

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
                    LoadingStatus = "Loading Tokens from Cryptometa data";
                    Logging.LogInfo("TokenDataService.StartLoadTokens: loading all Tokens from Cryptometa Assets");
                    foreach (var cryptometaAsset in CryptometaFile.Instance.Assets
                                 .Where(a => !string.IsNullOrEmpty(a.Symbol)
                                             && !string.IsNullOrEmpty(a.Name)
                                             && a.Symbol.ToLower() != "zil"))
                    {
                        var tokenModel = tokenModels.FirstOrDefault(t => t.Symbol.ToLower() == cryptometaAsset.Symbol.ToLower());
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
                    LoadingStatus = "Loading Tokens from Smart Contracts";
                    Logging.LogInfo("TokenDataService.StartLoadTokens: loading all Tokens from Smart Contracts");
                    foreach (var smartContract in RepositoryManager.Instance.DatabaseRepository.Database
                                 .GetTable<SmartContract>().EnumerateAllRecords()
                                 .Where(sc => !string.IsNullOrEmpty(sc.TokenSymbol()) 
                                              && sc.TokenSymbol()?.ToLower() != "zil"))
                    {
                        var contractSymbol = smartContract.TokenSymbol()!;
                        var tokenModel = tokenModels.FirstOrDefault(t => t.Symbol.ToLower() == contractSymbol.ToLower());
                        if (tokenModel == null)
                        {
                            tokenModel = new TokenModel
                            {
                                Symbol = contractSymbol!,
                                Name = smartContract.TokenName() ?? string.Empty,
                                Icon = LogoImages.Instance.GetImage(smartContract.ContractAddress.FromBase16ToBech32Address())
                            };
                            tokenModels.Add(tokenModel);
                            tokenModel.SmartContractModels.Add(smartContract);
                        }
                        else
                        {
                            tokenModel.SmartContractModels.Add(smartContract);
                        }
                    }
                    foreach (var coinPrice in TokenPriceFile.Instance.CoinPrices)
                    {
                        var symbolLowered = coinPrice.Symbol.ToLower();
                        tokenModels.FirstOrDefault(t => t.Symbol.ToLower() == symbolLowered)
                            ?.LoadPriceProperties(coinPrice);
                    }

                    _tokenModels = tokenModels
                        .OrderByDescending(t => t.MarketCapUsd ?? -1)
                        .ThenByDescending(t => t.CryptometaAsset?.Gen.Score ?? -1)
                        .ThenByDescending(t => t.CreatedDate ?? DateTime.MinValue)
                        .ToList();
                    _tokenAddressDictionary = null;
                    _tokenModelsLoaded = true;
                    Logging.LogInfo("TokenDataService.StartLoadTokens: loading completed");

                    bool refreshExisting = false;
                    bool refreshNew = false;
                    List<TokenModel> refreshAssets = new List<TokenModel>();
                    if (TokenPriceFile.Instance.CoinPrices.Count == 0
                        || forceReLoad
                        || (TokenPriceFile.Instance.NewAssetsAdded ?? DateTime.MinValue) < DateTime.Today.AddDays(-30))
                    {
                        refreshNew = true;
                        refreshExisting = true;
                        refreshAssets = _tokenModels.Where(t =>
                            !string.IsNullOrEmpty(t.Symbol) && t.CryptometaAsset?.Gen.Score > 10)
                            .ToList();
                    }
                    else if ((TokenPriceFile.Instance.ExistingAssetsRefresh ?? DateTime.MinValue) < DateTime.Today.AddDays(-1))
                    {
                        refreshExisting = true;
                        refreshAssets = _tokenModels.Where(t => 
                            TokenPriceFile.Instance.CoinPrices.Any(cp => cp.Symbol.ToLower() == t.Symbol.ToLower()))
                            .ToList();
                    }
                    if (refreshNew || refreshExisting)
                    {
                        LoadingStatus = "Refreshing Token prices from Coingecko";
                        Logging.LogInfo("TokenDataService.StartLoadTokens: Refresh price-infos begin");
                        var coinPrices = new List<CoinPrice>();
                        var refreshedCount = 0m;
                        foreach (var tokenModel in refreshAssets)
                        {
                            try
                            {
                                var resolveSymbol = tokenModel.Symbol;
                                if (tokenModel.CryptometaAsset?.Gen.Score == 100 
                                    && (resolveSymbol.StartsWith("z") || resolveSymbol.StartsWith("w")))
                                {
                                    resolveSymbol = resolveSymbol.Substring(1);
                                }
                                RepositoryManager.Instance.CoingeckoRepository.GetCoinPrice(resolveSymbol, cp =>
                                {
                                    tokenModel.LoadPriceProperties(cp);
                                    coinPrices.Add(cp);
                                }, false);
                            }
                            catch (Exception e)
                            {
                                Logging.LogError($"CoingeckoRepository.GetCoinPrice({tokenModel.Symbol}) failed", e);
                            }

                            refreshedCount++;
                            if (refreshedCount % 10 == 0)
                            {
                                LoadingStatus = $"Refreshing Token prices from Coingecko [{100m / refreshAssets.Count * refreshedCount:0}%]";
                            }
                        }
                        if (refreshNew)
                        {
                            TokenPriceFile.Instance.NewAssetsAdded = DateTime.Now;
                        }
                        if (refreshExisting)
                        {
                            TokenPriceFile.Instance.ExistingAssetsRefresh = DateTime.Now;
                        }
                        if (coinPrices.Count > 0)
                        {
                            TokenPriceFile.Instance.CoinPrices = coinPrices;
                            TokenPriceFile.Instance.Save();
                        }
                        Logging.LogInfo("TokenDataService.StartLoadTokens: Refresh price-infos completed");
                    }
                }
                catch (Exception e)
                {
                    Logging.LogError("TokenDataService.StartLoadTokens: loading failed", e);
                }

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
