using Newtonsoft.Json;
using Octokit;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.ApiClient.ViewblockApi.Model;

namespace Zilliqa.DesktopWallet.ApiClient.ViewblockApi
{
    public class ViewblockCryptometaClient
    {
        private const string GithubUserAgent = "Zillifriends.ZilliqaDesktopWallet";
        private const string GithubBaseUrl = "https://raw.githubusercontent.com/ViewBlock/cryptometa/master/data/zilliqa";

        public List<CryptometaAssetResult> AllAssets(StatusProgressText statusProgressText = null)
        {
            var github = new GitHubClient(new ProductHeaderValue(GithubUserAgent));

            return Task.Run(async () =>
            {
                var githubFolders = await github.Repository.Content
                    .GetAllContents("ViewBlock", "cryptometa", "data/zilliqa/assets");
                if (statusProgressText != null)
                {
                    statusProgressText.ItemCount = githubFolders.Count;
                }
                return githubFolders.Select(folder =>
                {
                    if (statusProgressText != null)
                    {
                        statusProgressText.CurrentItem++;
                    }
                    return GetAsset(folder.Name);
                }).ToList();
            }).GetAwaiter().GetResult();
        }

        public List<CryptometaEcosystemResult> AllEcosystems(StatusProgressText statusProgressText = null)
        {
            var github = new GitHubClient(new ProductHeaderValue(GithubUserAgent));

            return Task.Run(async () =>
            {
                var githubFolders = await github.Repository.Content
                    .GetAllContents("ViewBlock", "cryptometa", "data/zilliqa/ecosystem");
                if (statusProgressText != null)
                {
                    statusProgressText.ItemCount = githubFolders.Count;
                }
                return githubFolders.Select(folder =>
                {
                    if (statusProgressText != null)
                    {
                        statusProgressText.CurrentItem++;
                    }
                    return GetEcosystem(folder.Name);
                }).ToList();
            }).GetAwaiter().GetResult();
        }

        public CryptometaAssetResult GetAsset(string bech32Address)
        {
            var result = new CryptometaAssetResult();
            using var client = new RestClient(GithubBaseUrl);
            try
            {
                var request = new RestRequest($"assets/{bech32Address}/meta.json");
                var response = client.Execute(request);
                if (!response.IsSuccessful) return result;
                result.Asset = JsonConvert.DeserializeObject<CryptometaAsset>(response.Content 
                                    ?? throw new Exception("Content is null"));
                if (result.Asset != null)
                {
                    result.Asset.Bech32Address = bech32Address;
                    result.Found = true;
                    if (!string.IsNullOrEmpty(result.Asset.Gen.Logo))
                    {
                        var imageRequest = new RestRequest($"assets/{bech32Address}/{result.Asset.Gen.Logo}");
                        var imageResponse = client.Execute(imageRequest);
                        if (!imageResponse.IsSuccessful) return result;
                        result.Image = imageResponse.RawBytes;
                    }
                }

            }
            catch (Exception e)
            {
                throw new ApiCallException($"ViewblockCryptometaClient.GetAsset('{bech32Address}') failed: {e.Message}", e);
            }

            return result;
        }

        public CryptometaEcosystemResult GetEcosystem(string name)
        {
            var result = new CryptometaEcosystemResult();
            using var client = new RestClient(GithubBaseUrl);
            try
            {
                var request = new RestRequest($"ecosystem/{name}/meta.json");
                var response = client.Execute(request);
                if (!response.IsSuccessful) return result;
                result.Ecosystem = JsonConvert.DeserializeObject<CryptometaEcosystem>(response.Content
                                                                              ?? throw new Exception("Content is null"));
                result.Found = result.Ecosystem != null;
                if (!string.IsNullOrEmpty(result.Ecosystem?.Gen.Logo))
                {
                    var imageRequest = new RestRequest($"ecosystem/{name}/{result.Ecosystem.Gen.Logo}");
                    var imageResponse = client.Execute(imageRequest);
                    if (!imageResponse.IsSuccessful) return result;
                    result.Image = imageResponse.RawBytes;
                }

            }
            catch (Exception e)
            {
                throw new ApiCallException($"ViewblockCryptometaClient.GetEcosystem('{name}') failed: {e.Message}", e);
            }

            return result;
        }

    }
}
