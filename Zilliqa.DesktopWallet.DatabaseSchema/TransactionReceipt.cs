using Newtonsoft.Json;

namespace Zilliqa.DesktopWallet.DatabaseSchema
{
    public class TransactionReceipt
    {
        [JsonProperty("A")]
        public long CumulativeGas { get; set; }

        [JsonProperty("B")]
        public long EpochNum { get; set; }

        [JsonProperty("C")]
        public List<EventLog> EventLogs { get; set; }

        [JsonProperty("D")]
        public bool Success { get; set; }

        [JsonProperty("E")]
        public List<Transition> Transitions { get; set; }

        [JsonProperty("F")]
        public Errors Errors { get; set; }

        [JsonProperty("G")]
        public List<ExceptionMessage> Exceptions { get; set; }
    }

    public class EventLog
    {
        [JsonProperty("A")]
        public string Eventname { get; set; }

        [JsonProperty("B")]
        public string Address { get; set; }

        [JsonProperty("C")]
        public List<Param> Params { get; set; }
    }

    public class Param : IParam
    {
        [JsonProperty("A")]
        public string Type { get; set; }

        [JsonProperty("B")]
        public string Vname { get; set; }

        [JsonProperty("C")]
        public object Value { get; set; }

    }

    public class Transition
    {
        [JsonProperty("A")]
        public string Addr { get; set; }

        [JsonProperty("B")]
        public long Depth { get; set; }

        [JsonProperty("C")]
        public Msg Msg { get; set; }
    }

    public class Msg
    {
        [JsonProperty("A")]
        public decimal Amount { get; set; }

        [JsonProperty("B")]
        public string Recipient { get; set; }

        [JsonProperty("C")]
        public string Tag { get; set; }

        [JsonProperty("D")]
        public List<Param> Params { get; set; }
    }

    public class Errors
    {
        [JsonProperty("A")]
        public List<int> Numbers { get; set; }
    }

    public class ExceptionMessage
    {
        [JsonProperty("A")]
        public int Line { get; set; }

        [JsonProperty("B")]
        public string Message { get; set; }
    }
}
