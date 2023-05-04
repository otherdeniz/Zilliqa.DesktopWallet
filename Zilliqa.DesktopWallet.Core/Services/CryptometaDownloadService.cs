using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.ApiClient.ViewblockApi;
using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.Data.Images;

namespace Zilliqa.DesktopWallet.Core.Services
{
    public class CryptometaDownloadService
    {
        private readonly int _refreshAfterDays = 90;
        private readonly CancellationTokenSource _loadCancelTokenSource = new();
        private bool _loadStarted;
        private bool _loadCompleted;
        private string _loadingStatus = "";
        private StatusProgressText? _loadingStatusProgressText;

        public static CryptometaDownloadService Instance { get; } = new();

        private CryptometaDownloadService()
        {
        }

        public bool LoadStarted => _loadStarted;

        public bool LoadCompleted => _loadCompleted;

        public string LoadingStatus
        {
            get => _loadingStatusProgressText?.ToString() ?? _loadingStatus;
        }

        public void CancelLoad()
        {
            _loadCancelTokenSource.Cancel();
        }

        public void LoadOrRefresh()
        {
            if (_loadStarted) return;
            _loadStarted = true;
            if (!BeginRefreshIfNeeded())
            {
                _loadCompleted = true;
                AfterLoadCompleted();
            }
        }

        /// <summary>
        /// returns true if refresh is needed
        /// </summary>
        public bool BeginRefreshIfNeeded()
        {
            if (CryptometaFile.Instance.ModifiedDate == null
                || CryptometaFile.Instance.ModifiedDate.Value.AddDays(_refreshAfterDays) < DateTime.Today)
            {
                BeginRefresh();
                return true;
            }

            return false;
        }

        /// <summary>
        ///  Download Data And Save To File
        /// </summary>
        public void BeginRefresh()
        {
            Task.Run(() =>
            {
                var cancellationToken = _loadCancelTokenSource.Token;
                try
                {
                    _loadingStatus = "Downloading assets from Github repository";
                    _loadingStatusProgressText = new StatusProgressText(_loadingStatus);
                    Logging.LogInfo($"CryptometaDownloadService LoadOrRefresh: {LoadingStatus}");
                    var logoImages = LogoImages.Instance;
                    var cryptometaClient = new ViewblockCryptometaClient();
                    var allAssets = cryptometaClient.AllAssets(_loadingStatusProgressText);
                    foreach (var asset in allAssets)
                    {
                        if (asset.Asset != null && asset.Image != null)
                        {
                            logoImages.SaveImage(asset.Asset.Bech32Address, asset.Image);
                        }
                    }

                    CryptometaFile.Instance.Assets = allAssets.Select(a => a.Asset!).ToList();

                    if (cancellationToken.IsCancellationRequested) return;

                    _loadingStatus = "Downloading ecosystems from Github repository";
                    _loadingStatusProgressText = new StatusProgressText(_loadingStatus);
                    Logging.LogInfo($"CryptometaDownloadService LoadOrRefresh: {LoadingStatus}");
                    var allEcosystems = cryptometaClient.AllEcosystems(_loadingStatusProgressText);
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

                    _loadCompleted = true;
                    _loadingStatusProgressText = null;
                    _loadingStatus = "Download completed";
                    Logging.LogInfo($"CryptometaDownloadService LoadOrRefresh: {LoadingStatus}");
                    AfterLoadCompleted();
                }
                catch (TaskCanceledException)
                {
                    _loadingStatusProgressText = null;
                    _loadingStatus = "Download aborted";
                    Logging.LogInfo("CryptometaDownloadService LoadOrRefresh: aborted");
                }
                catch (Exception e)
                {
                    _loadingStatusProgressText = null;
                    _loadingStatus = "Download failed";
                    Logging.LogError($"CryptometaDownloadService LoadOrRefresh: failed: {e.Message}", e);
                }

                _loadCompleted = true;
            });
        }

        private void AfterLoadCompleted()
        {
            // load Logo images from disk
            LogoImages.Instance.LoadImages();

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
            TokenDataService.Instance.StartLoadTokens(true);
        }
    }
}
