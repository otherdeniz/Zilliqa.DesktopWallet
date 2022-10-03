﻿using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.ApiClient.Utils;
using Zilliqa.DesktopWallet.ApiClient.ViewblockApi.Model;
using Zilliqa.DesktopWallet.Core.Api.Coingecko.Model;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Core.Data.Model
{
    public class TokenModel : IDetailsViewModel
    {
        public string Symbol { get; set; }

        public string Name { get; set; }

        public IconModel Icon { get; set; }

        public List<string> ContractAddressesBech32 { get; set; } = new();

        public List<SmartContract> SmartContractModels { get; set; } = new();

        public CryptometaAsset? CryptometaAsset { get; set; }

        public DateTime? CreatedDate => SmartContractModels.Any() 
            ? SmartContractModels.Min(s => s.Timestamp) : null;

        public decimal? MaxSupply { get; private set; }

        public CoinPrice? CoinPrice { get; private set; }

        public decimal? PriceZil { get; private set; }

        public decimal? PriceUsd { get; private set; }

        public decimal? MarketCapUsd { get; private set; }

        public virtual void LoadPriceProperties(CoinPrice coinPrice)
        {
            CoinPrice = coinPrice;
            PriceUsd = coinPrice.MarketData.CurrentPrice.Usd;
            var zilPrice = RepositoryManager.Instance.CoingeckoRepository.ZilCoinPrice?.MarketData
                .CurrentPrice.Usd;
            if (PriceUsd > 0 && zilPrice > 0)
            {
                PriceZil = PriceUsd / zilPrice;
            }
            MarketCapUsd = coinPrice.MarketData.MarketCap.Usd;
            if (MaxSupply == null)
            {
                MaxSupply = coinPrice.MarketData.MaxSupply ?? coinPrice.MarketData.TotalSupply;
            }
        }

        public string GetUniqueId()
        {
            return $"Token-{Symbol}";
        }

        public string GetDisplayTitle()
        {
            return $"Token: {Name.TokenNameShort()} ({Symbol.TokenSymbolShort()})";
        }
    }

    public class TokenModelByAddress
    {
        public static bool TryParse(TokenModel tokenModel, string contractAddressBech32,
            out TokenModelByAddress? result)
        {
            var smartContract = tokenModel.SmartContractModels.FirstOrDefault(s =>
                s.ContractAddress.FromBase16ToBech32Address() == contractAddressBech32);
            if (smartContract != null)
            {
                result = new TokenModelByAddress
                {
                    TokenModel = tokenModel,
                    ContractAddressBech32 = contractAddressBech32,
                    SmartContract = smartContract
                };
                return true;
            }

            result = null;
            return false;
        }

        public TokenModel TokenModel { get; private set; } = null!;

        public string ContractAddressBech32 { get; private set; } = null!;

        public SmartContract SmartContract { get; private set; } = null!;

    }
}
