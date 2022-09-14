using System.ComponentModel;
using Newtonsoft.Json;
using Zilliqa.DesktopWallet.DatabaseSchema.ParsedData;

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
        [TypeConverter(typeof(ExpandableObjectConverter))] //only for GUI PropertyGrid
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
        private ParamValue? _resolvedValue;

        [JsonProperty("A")]
        public string Type { get; set; }

        [JsonProperty("B")]
        public string Vname { get; set; }

        [JsonProperty("C")]
        public object Value { get; set; }

        [JsonIgnore]
        [TypeConverter(typeof(ExpandableObjectConverter))] //only for GUI PropertyGrid
        public ParamValue ResolvedValue => _resolvedValue ??= ParamValue.ResolveParam(this);
    }

    public class Transition
    {
        [JsonProperty("A")]
        public string Addr { get; set; }

        [JsonProperty("B")]
        public long Depth { get; set; }

        [JsonProperty("C")]
        [TypeConverter(typeof(ExpandableObjectConverter))] //only for GUI PropertyGrid
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
