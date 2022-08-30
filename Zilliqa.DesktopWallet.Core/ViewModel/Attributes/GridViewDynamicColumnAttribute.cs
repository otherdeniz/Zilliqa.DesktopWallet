﻿namespace Zilliqa.DesktopWallet.Core.ViewModel.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class GridViewDynamicColumnAttribute : Attribute
    {
        public GridViewDynamicColumnAttribute(DynamicColumnCategory category)
        {
            Category = category;
        }

        public DynamicColumnCategory Category { get; }
    }

    public enum DynamicColumnCategory
    {
        CurrencyUsd,
        CurrencyEur,
        CurrencyChf,
        CurrencyGbp,
        CurrencyBtc,
        CurrencyEth,
        CurrencyLtc
    }
}
