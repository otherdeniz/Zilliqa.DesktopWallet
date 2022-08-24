﻿using System.ComponentModel;
using System.Drawing;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.ViewModel.Attributes;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class TokenRowViewModel
    {
        private readonly TokenModel _model;
        private Image? _icon;

        public TokenRowViewModel(TokenModel model)
        {
            _model = model;
        }

        [Browsable(false)]
        public TokenModel Model => _model;

        public Image? Icon => _icon ??= _model.GetTokenIcon().Icon16;

        public string Symbol => _model.Symbol;

        public string Name => _model.Name;

        [DisplayName("Price USD")]
        [GridViewFormat("0.0000")]
        public decimal PriceUsd => _model.MarketData.RateUsd;

        [DisplayName("Price ZIL")]
        [GridViewFormat("0.00")]
        public decimal PriceZil => _model.MarketData.RateZil;

        [DisplayName("Market Cap USD")]
        [GridViewFormat("#,##0")]
        public decimal MarketCapUsd => _model.MarketData.FullyDilutedValuationUsd;

        [DisplayName("Max Supply")]
        [GridViewFormat("#,##0")]
        public decimal MaxSupply => _model.MarketData.MaxSupply;

        //[DisplayName("Change 24h")]
        //[GridViewFormat("0.0 '%'")]
        //public decimal ChangePercent24H => _model.MarketData.ChangePercentage24H;
    }
}