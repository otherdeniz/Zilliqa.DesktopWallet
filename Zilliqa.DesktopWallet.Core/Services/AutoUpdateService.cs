using Octokit;

namespace Zilliqa.DesktopWallet.Core.Services
{
    public class AutoUpdateService
    {
        private const string GithubUserAgent = "Zillifriends.ZilliqaDesktopWallet";

        public static AutoUpdateService Instance { get; } = new();

        private AutoUpdateService()
        {
        }

        public ReleaseAsset? GetLatestRelease()
        {
            var github = new GitHubClient(new ProductHeaderValue(GithubUserAgent));

            return Task.Run(async () =>
            {
                var release = await github.Repository.Release.GetLatest("otherdeniz", "Zilliqa.DesktopWallet");
                return release?.Assets.FirstOrDefault();
            }).GetAwaiter().GetResult();
        }
    }

    public class GithubReleaseInfo
    {
        public string Name { get; set; }

        public decimal Version { get; set; }

        public DateTime CreatedAt { get; set; }

        public string DownloadUrl { get; set; }
    }
}
