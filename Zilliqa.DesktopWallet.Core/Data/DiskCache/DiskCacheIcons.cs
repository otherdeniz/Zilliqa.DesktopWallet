using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.Caching;
using Svg;
using Zilliqa.DesktopWallet.Core.Data.Model;

namespace Zilliqa.DesktopWallet.Core.Data.DiskCache
{
    public class DiskCacheIcons : DiskCacheBase
    {
        private readonly MemoryCache _iconsCache = new MemoryCache("DiskCacheIcons");

        public static DiskCacheIcons Instance { get; } = new DiskCacheIcons();

        private DiskCacheIcons() : base("Icons")
        {
        }

        public IconModel GetIcon(string downloadUrl, bool cacheInMemory = true, string? iconLabel = null)
        {
            if (cacheInMemory && _iconsCache.Contains(downloadUrl))
            {
                return (IconModel)_iconsCache.Get(downloadUrl);
            }
            var iconBytes = GetItemData(downloadUrl, () => DownloadFile(downloadUrl));
            using (var imageStream = new MemoryStream(iconBytes))
            {
                // you can enable support for non-Windows platforms by setting the System.Drawing.EnableUnixSupport runtime configuration switch to true in the runtimeconfig.json file
                Image? image = null;
                try
                {
                    image = Image.FromStream(imageStream);
                }
                catch (Exception)
                {
                    // skip
                }
                try
                {
                    var svgDocument = SvgDocument.Open<SvgDocument>(imageStream);
                    image = svgDocument.Draw();
                }
                catch (Exception)
                {
                    // skip
                }

                var iconModel = new IconModel();
                if (image != null)
                {
                    iconModel.Icon16 = image.GetThumbnailImage(16, 16, null, IntPtr.Zero);
                    iconModel.Icon48 = image.GetThumbnailImage(48, 48, null, IntPtr.Zero);
                }
                try
                {
                    _iconsCache.Add(downloadUrl, iconModel, DateTimeOffset.Now.AddHours(1));
                    if (!string.IsNullOrEmpty(iconLabel))
                    {
                        iconModel.Icon16?.Save(DataPathBuilder.GetFilePath($"{iconLabel}_16.png"), ImageFormat.Png);
                        iconModel.Icon48?.Save(DataPathBuilder.GetFilePath($"{iconLabel}_48.png"), ImageFormat.Png);
                    }
                }
                catch (Exception)
                {
                    // failed to add, ignore
                }

                return iconModel;
            }
        }

        private byte[] DownloadFile(string downloadUrl)
        {
            return Task.Run(async () =>
            {
                using var httpClient = new HttpClient();
                return await httpClient.GetByteArrayAsync(downloadUrl);
            }).GetAwaiter().GetResult();
        }
    }
}
