using Zilliqa.DesktopWallet.ApiClient.ViewblockApi;
using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.Data.Images;

namespace Zilliqa.DesktopWallet.Core.Services
{
    public class CryptometaDownloadService
    {
        private readonly int _refreshAfterDays = 90;
        //private readonly CancellationTokenSource _refreshCancelTokenSource = new();
        private bool _loadStarted;

        public static CryptometaDownloadService Instance { get; } = new();

        private CryptometaDownloadService()
        {
        }

        //public void CancelRefresh()
        //{
        //    _refreshCancelTokenSource.Cancel();
        //}

        public void LoadOrRefresh()
        {
            if (_loadStarted) return;
            _loadStarted = true;
            if (CryptometaFile.Instance.ModifiedDate == null
                || CryptometaFile.Instance.ModifiedDate.Value.AddDays(_refreshAfterDays) < DateTime.Today)
            {
                Task.Run(() =>
                {
                    try
                    {
                        Logging.LogInfo("CryptometaDownloadService refresh started");
                        var logoImages = LogoImages.Instance;
                        var cryptometaClient = new ViewblockCryptometaClient();
                        var allAssets = cryptometaClient.AllAssets();
                        foreach (var asset in allAssets)
                        {
                            if (asset.Asset != null && asset.Image != null)
                            {
                                logoImages.SaveImage(asset.Asset.Bech32Address, asset.Image);
                            }
                        }
                        CryptometaFile.Instance.Assets = allAssets.Select(a => a.Asset!).ToList();
                        var allEcosystems = cryptometaClient.AllEcosystems();
                        foreach (var ecosystem in allEcosystems)
                        {
                            if (ecosystem.Ecosystem != null && ecosystem.Image != null)
                            {
                                logoImages.SaveImage(ecosystem.Ecosystem.Key, ecosystem.Image);
                            }
                        }
                        CryptometaFile.Instance.Ecosystems = allEcosystems.Select(a => a.Ecosystem!).ToList();
                        CryptometaFile.Instance.ModifiedDate = DateTime.Today;
                        CryptometaFile.Instance.Save();
                        Logging.LogInfo("CryptometaDownloadService refresh completed");
                        AfterLoadCompleted();
                    }
                    catch (TaskCanceledException)
                    {
                        Logging.LogInfo("CryptometaDownloadService refresh aborted");
                    }
                    catch (Exception e)
                    {
                        Logging.LogError($"CryptometaDownloadService failed: {e.Message}", e);
                    }
                }); //, _refreshCancelTokenSource.Token);
            }
            else
            {
                AfterLoadCompleted();
            }
        }

        private void AfterLoadCompleted()
        {
            // load Logo images from disk
            LogoImages.Instance.LoadImages();

            // COMMENTED OUT! already loaded, by KnownAddressService AddSmartContract function
            //// add known addresses
            //foreach (var asset in CryptometaFile.Instance.Assets)
            //{
            //    KnownAddressService.Instance.AddUnique(asset.Bech32Address, $"{asset.NameShort()} ({asset.SymbolShort()})");
            //}
            foreach (var ecosystem in CryptometaFile.Instance.Ecosystems
                         .Where(e => e.Addresses != null))
            {
                for (int i = 1; i <= ecosystem.Addresses!.Length; i++)
                {
                    var address = ecosystem.Addresses![i - 1];
                    KnownAddressService.Instance.AddUnique(address, $"Ecosystem {ecosystem.Categories?.FirstOrDefault()}", 
                        $"{ecosystem.Name} #{i}");
                }
            }

            // load token models
            TokenDataService.Instance.StartLoadTokens();
        }
    }
}
