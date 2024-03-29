﻿using Zilliqa.DesktopWallet.Core.Services;

namespace Zilliqa.DesktopWallet.Core.Extensions
{
    public static class ModelExtensions
    {
        public static TTarget MapToModel<TSource, TTarget>(this TSource source)
        {
            return MappingService.Instance.Mapper.Map<TSource, TTarget>(source);
        }
    }
}
