using System.Drawing;
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

        public static Image GetIconImage(this TokenModel model)
        {
            return DiskCacheIcons.Instance.GetIcon(model.IconUrl);
        }
    }
}
