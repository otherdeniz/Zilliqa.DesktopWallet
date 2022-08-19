using Newtonsoft.Json;

namespace Zilliqa.DesktopWallet.DatabaseSchema
{
    //"_tag": "sendFunds",
    //"params": [{
    //    "vname": "accountValues",
    //    "type": "List (AccountValue)",
    //    "value": [{
    //        "constructor": "AccountValue",
    //        "argtypes": [],
    //        "arguments": ["0xc0e28525e9d329156e16603b9c1b6e4a9c7ed813", "50000000000000"]
    //    }
    //    ]
    //}
    //]
    public class TransactionContractCall
    {
        [JsonProperty("t")]
        public string Tag { get; set; }

        [JsonProperty("p")] 
        public List<ContractCallParameter> Parameters { get; set; } = new();
    }

    public class ContractCallParameter
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string Value { get; set; }
    }
}
