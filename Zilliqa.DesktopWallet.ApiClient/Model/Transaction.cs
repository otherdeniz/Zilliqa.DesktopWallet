using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zilliqa.DesktopWallet.ApiClient.Model
{
    public class Transaction
    {
        [JsonProperty("ID")]
        public string Id { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("gasLimit")]
        public long GasLimit { get; set; }
        //if (_normalTx && _gasLimit <= 1000000000000)
        //{
        //    var zVal = _gasLimit / 1000000000000;
        //    //throw new ArgumentOutOfRangeException($"Normal transactions should have 1 gas, {zVal} found instead");
        //}

        [JsonProperty("gasPrice")]
        public long GasPrice { get; set; }

        [JsonProperty("nonce")]
        public long Nonce { get; set; }

        [JsonProperty("senderPubKey")]
        public string SenderPubKey { get; set; }

        [JsonProperty("toAddr")]
        public string ToAddress { get; set; }

        [JsonProperty("receipt")]
        public Receipt Receipt { get; set; }

        [JsonProperty("signature")]
        public string Signature { get; set; }

        [JsonProperty("version")]
        public int Version {get;set;}

        public class Info
        {
            [JsonProperty("Info")]
            public string InfoMessage { get; set; }
            [JsonProperty("TranID")]
            public string TransactionId { get; set; }
        }

    }

    public class Receipt
    {
        [JsonProperty("cumulative_gas")]
        public long CumulativeGas { get; set; }

        [JsonProperty("epoch_num")]
        public long EpochNum { get; set; }

        [JsonProperty("event_logs")]
        public List<EventLog> EventLogs { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("transitions")]
        public List<Transition> Transitions { get; set; }

        [JsonProperty("errors")]
        public Errors Errors { get; set; }

        [JsonProperty("exceptions")]
        public List<ExceptionMessage> Exceptions { get; set; }
    }

    public class EventLog
    {
        [JsonProperty("_eventname")]
        public string Eventname { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("params")]
        public List<Param> Params { get; set; }
    }

    public class Param
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }

        [JsonProperty("vname")]
        public string Vname { get; set; }
    }

    public class Transition
    {
        [JsonProperty("addr")]
        public string Addr { get; set; }

        [JsonProperty("depth")]
        public long Depth { get; set; }

        [JsonProperty("msg")]
        public Msg Msg { get; set; }
    }

    public class Errors
    {
        [JsonProperty("0")]
        public List<int> Numbers { get; set; }
    }

    public class ExceptionMessage
    {
        [JsonProperty("line")]
        public int Line { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
