using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Zilliqa.DesktopWallet.ApiClient.Model
{
    public class TransactionDataContractCall
    {
        [JsonProperty("_tag")]
        public string Tag { get; set; }

        [JsonProperty("params")]
        public List<Param> Params { get; set; }
    }
}
