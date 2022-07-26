using Zilliqa.DesktopWallet.Core.Data.DiskCache;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Services;

namespace Zilliqa.DesktopWallet.Core.Extensions
{
    public static class ModelExtensions
    {
        public static TTarget MapToModel<TSource, TTarget>(this TSource source)
        {
            return MappingService.Instance.Mapper.Map<TSource, TTarget>(source);
        }

        public static IconModel GetTokenIcon(this TokenModel model)
        {
            return DiskCacheIcons.Instance.GetIcon(model.IconUrl, false, model.Symbol);
        }

        public static string FromBech32ToShortReadable(this string bech32)
        {
            if (bech32.Length > 10)
            {
                return $"{bech32.Substring(0, 4)} {bech32.Substring(4, 3)}...{bech32.Substring(bech32.Length - 4, 3)}";
            }

            return bech32;
        }
    }
}
