using Newtonsoft.Json;
using RestSharp;
using Zilliqa.DesktopWallet.WebContract;

namespace Zilliqa.DesktopWallet.WebClient
{
    public class WalletWebClient
    {
        public WalletWebClient(string serverUrl)
        {
            ServerUrl = serverUrl;
        }

        public string ServerUrl { get; }

        public SnapshotInfo? GetSnapshotInfo()
        {
            using (var client = GetClient())
            {
                var request = new RestRequest("snapshot");
                var response = client.Execute(request);
                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    return JsonConvert.DeserializeObject<SnapshotInfo>(response.Content);
                }
            }
            return null;
        }

        public FileDownloadInfo? DownloadSnapshot(string snapshotId, string destinationFilePath)
        {
            throw new NotImplementedException();
        }

        private RestClient GetClient()
        {
            var client = new RestClient($"{ServerUrl}/api");
            return client;
        }

    }
}