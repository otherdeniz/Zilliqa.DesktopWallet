using System.Drawing;
using System.Runtime.Caching;

namespace Zilliqa.DesktopWallet.Core.Data.DiskCache
{
    public class DiskCacheIcons : DiskCacheBase
    {
        private readonly MemoryCache _iconsCache = new MemoryCache("DiskCacheIcons");

        public static DiskCacheIcons Instance { get; } = new DiskCacheIcons();

        private DiskCacheIcons() : base("Icons")
        {
        }

        public Image GetIcon(string downloadUrl, bool cacheInMemory = true)
        {
            if (cacheInMemory && _iconsCache.Contains(downloadUrl))
            {
                return (Image)_iconsCache.Get(downloadUrl);
            }
            var iconBytes = GetItemData(downloadUrl, () => DownloadFile(downloadUrl));
            using (var imageStream = new MemoryStream(iconBytes))
            {
                // you can enable support for non-Windows platforms by setting the System.Drawing.EnableUnixSupport runtime configuration switch to true in the runtimeconfig.json file
                var result = Image.FromStream(imageStream);
                try
                {
                    _iconsCache.Add(downloadUrl, result, DateTimeOffset.Now.AddHours(1));
                }
                catch (Exception)
                {
                    // failed to add, ignore
                }

                return result;
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
