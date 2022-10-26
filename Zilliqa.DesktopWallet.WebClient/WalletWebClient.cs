using Newtonsoft.Json;
using RestSharp;
using Zilliqa.DesktopWallet.WebContract;

namespace Zilliqa.DesktopWallet.WebClient
{
    public class WalletWebClient
    {
        public const string DefaultServerUrl = "http://zillifriends.org";

        public WalletWebClient(string? serverUrl = null)
        {
            ServerUrl = serverUrl ?? DefaultServerUrl;
        }

        public string ServerUrl { get; }

        public SnapshotInfo? GetSnapshotInfo()
        {
            using (var client = GetClient())
            {
                var request = new RestRequest("snapshot/info");
                var response = client.Execute(request);
                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    return JsonConvert.DeserializeObject<SnapshotInfo>(response.Content);
                }
            }
            return null;
        }

        public Stream? DownloadSnapshotStream(string snapshotId)
        {
            using (var client = GetClient())
            {
                var request = new RestRequest($"snapshot/download?id={snapshotId}");
                return client.DownloadStream(request);
            }
        }

        private RestClient GetClient()
        {
            var client = new RestClient($"{ServerUrl}/api");
            return client;
        }

    }
}