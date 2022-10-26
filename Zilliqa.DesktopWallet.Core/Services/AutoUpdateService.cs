using System.Diagnostics;
using System.Text.RegularExpressions;
using Octokit;

namespace Zilliqa.DesktopWallet.Core.Services
{
    public class AutoUpdateService
    {
        private const string GithubUserAgent = "Zillifriends.ZilliqaDesktopWallet";
        private static readonly Regex VersionRegex = new Regex(@"v(\d+.\d+)", RegexOptions.Compiled);

        public static AutoUpdateService Instance { get; } = new();

        private readonly string _downloadedInstallerPath =
            Environment.ExpandEnvironmentVariables(@"%TEMP%\Zilliqa.DesktopWallet.WindowsInstaller.msi");

        private AutoUpdateService()
        {
        }

        public void CleanupDownload()
        {
            if (File.Exists(_downloadedInstallerPath))
            {
                try
                {
                    File.Delete(_downloadedInstallerPath);
                }
                catch (Exception)
                {
                    // ignore
                }
            }
        }

        public GithubReleaseInfo? GetLatestRelease()
        {
            var github = new GitHubClient(new ProductHeaderValue(GithubUserAgent));

            return Task.Run(async () =>
            {
                var release = await github.Repository.Release.GetLatest("otherdeniz", "Zilliqa.DesktopWallet");
                if (release != null && VersionRegex.IsMatch(release.Name))
                {
                    var releaseAsset = release.Assets.FirstOrDefault(a => a.Name.EndsWith(".msi"));
                    if (releaseAsset != null)
                    {
                        return new GithubReleaseInfo
                        {
                            Name = release.Name,
                            Version = decimal.Parse(VersionRegex.Match(release.Name).Groups[1].Value),
                            CreatedAt = releaseAsset.CreatedAt.LocalDateTime,
                            FileSize = releaseAsset.Size,
                            DownloadUrl = releaseAsset.BrowserDownloadUrl
                        };
                    }
                }
                return null;
            }).GetAwaiter().GetResult();
        }

        public void UpdateNow(string downloadUrl)
        {
            // download file
            Task.Run(async () =>
            {
                var client = new HttpClient();
                var response = await client.GetAsync(downloadUrl);
                using (var fs = File.Create(_downloadedInstallerPath))
                {
                    await response.Content.CopyToAsync(fs);
                }
            }).GetAwaiter().GetResult();
            // start setup
            Process.Start(new ProcessStartInfo
            {
                FileName = @"C:\Windows\System32\msiexec.exe",
                Arguments = $"/i \"{_downloadedInstallerPath}\" /qr",
                UseShellExecute = true
            });
        }
    }

    public class GithubReleaseInfo
    {
        public string Name { get; set; }

        public decimal Version { get; set; }

        public DateTime CreatedAt { get; set; }

        public long FileSize { get; set; }

        public string DownloadUrl { get; set; }
    }
}
