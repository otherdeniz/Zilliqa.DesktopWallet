using System.Drawing;
using Svg;
using System.Drawing.Imaging;
using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.ViewModel;

namespace Zilliqa.DesktopWallet.Core.Data.Images
{
    public class LogoImages
    {
        private static readonly IconModel DefaultIcon = new()
        {
            Icon16 = IconResources.CircleDotGray16,
            Icon48 = IconResources.CircleDotGray48
        };
        private readonly Dictionary<string, IconModel> _imagesCache = new();

        public static LogoImages Instance { get; } = new();

        private LogoImages()
        {
            DataPathBuilder = DataPathBuilder.Root.GetSubFolder("Images");
        }

        protected DataPathBuilder DataPathBuilder { get; }

        public void LoadImages()
        {
            _imagesCache.Clear();
            foreach (var file16 in Directory.GetFiles(DataPathBuilder.FullPath, "*_16.png"))
            {
                var key = new FileInfo(file16).Name.Substring(0, file16.Length-7);
                try
                {
                    var pngFile16 = DataPathBuilder.GetFilePath($"{key}_16.png");
                    var pngFile48 = DataPathBuilder.GetFilePath($"{key}_48.png");
                    var model = new IconModel
                    {
                        Icon16 = Image.FromFile(pngFile16),
                        Icon48 = Image.FromFile(pngFile48)
                    };
                    _imagesCache.Add(key, model);

                }
                catch (Exception)
                {
                    // ignore any error
                }
            }
        }

        public IconModel GetImage(string key)
        {
            if (_imagesCache.TryGetValue(key, out var iconModel))
            {
                return iconModel;
            }
            return DefaultIcon;
        }

        public void SaveImage(string key, byte[] imageData)
        {
            using (var imageStream = new MemoryStream(imageData))
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

                if (image != null)
                {
                    using (var imageBitmap = new Bitmap(image))
                    {
                        if (imageBitmap.GetPixel(0, 0).Equals(Color.Black))
                        {
                            image.Dispose();
                            image = InvertBitmap(imageBitmap);
                        }
                    }
                    var icon16 = image.GetThumbnailImage(16, 16, null, IntPtr.Zero);
                    var icon48 = image.GetThumbnailImage(48, 48, null, IntPtr.Zero);
                    icon16.Save(DataPathBuilder.GetFilePath($"{key}_16.png"), ImageFormat.Png);
                    icon48.Save(DataPathBuilder.GetFilePath($"{key}_48.png"), ImageFormat.Png);
                    image.Dispose();
                }
            }
        }

        private static Image InvertBitmap(Bitmap sourceBitmap)
        {
            var invertedBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);
            for (int x = 0; x < sourceBitmap.Width; x++)
            {
                for (int y = 0; y < sourceBitmap.Height; y++)
                {
                    var clrPixel = sourceBitmap.GetPixel(x, y);
                    clrPixel = Color.FromArgb(clrPixel.A, 255 - clrPixel.R, 255 - clrPixel.G, 255 - clrPixel.B);
                    invertedBitmap.SetPixel(x, y, clrPixel);
                }
            }

            return invertedBitmap;
        }

    }
}
