﻿#nullable enable
using Newtonsoft.Json;

namespace Zilliqa.DesktopWallet.ApiClient.ViewblockApi.Model
{
    public class CryptometaEcosystemResult
    {
        public bool Found { get; set; }

        public CryptometaEcosystem? Ecosystem { get; set; }

        public byte[]? Image { get; set; }
    }

    public class CryptometaEcosystem
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("web")]
        public string Web { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("addresses")] 
        public string[]? Addresses { get; set; }

        [JsonProperty("categories")]
        public string[]? Categories { get; set; }

        [JsonProperty("links")]
        public CryptometaLinks Links { get; set; } = new();

        [JsonProperty("gen")]
        public CryptometaGen Gen { get; set; } = new();

    }

}
