using Newtonsoft.Json;
using Zilligraph.Database.Contract;
using Zilliqa.DesktopWallet.DatabaseSchema.ParsedData;

namespace Zilliqa.DesktopWallet.DatabaseSchema
{
    public class SmartContract
    {
        [RequiredValue]
        [PropertyIndex]
        [JsonProperty("A")]
        public string DeploymentTransactionId { get; set; }

        [SchemaReference(nameof(DeploymentTransactionId), nameof(Transaction.Id))]
        [JsonIgnore]
        public LazyReference<Transaction> DeploymentTransaction { get; set; } = null!;

        [JsonProperty("B")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("C")]
        [PropertyIndex(OverrideMaxChainLength = 100)]
        public string ContractLibrary { get; set; }

        [JsonProperty("D")]
        [PropertyIndex(LowDistinctOptimization = true)]
        public int SmartContractType { get; set; }

        [JsonIgnore]
        public SmartContractType SmartContractTypeEnum => (SmartContractType)SmartContractType;

        [JsonProperty("E")]
        public List<DataParam> ConstructorValues { get; set; }

        [JsonProperty("F")]
        [PropertyIndex]
        public string OwnerAddress { get; set; }

        [JsonProperty("G")]
        [PropertyIndex]
        public string ContractAddress { get; set; }

        [JsonProperty("H")] 
        public SmartContractTokenData TokenData { get; set; } = new();

        public string? TokenName()
        {
            return GetConstructorValue("name");
        }

        public string DisplayName()
        {
            var nameValue = TokenName();
            if (nameValue != null)
            {
                return $"{ContractLibrary}, {nameValue}";
            }
            return ContractLibrary;
        }

        public string? GetConstructorValue(string vName)
        {
            return ConstructorValues
                .Where(p => p.Vname == vName)
                .Select(p => p.Value.ToString())
                .FirstOrDefault();
        }

        public decimal AmountToDecimal(decimal? amountNumber)
        {
            if (amountNumber == null)
            {
                return 0;
            }
            if (TokenData.Decimals > 0)
            {
                var divident = Convert.ToDecimal(Math.Pow(10, TokenData.Decimals));
                return amountNumber.Value / divident;
            }
            return amountNumber.Value;
        }
    }

    public class SmartContractTokenData
    {
        [JsonProperty("A")]
        public string? Name { get; set; }

        [JsonProperty("B")]
        public string? Symbol { get; set; }

        [JsonProperty("C")]
        public int Decimals { get; set; }

        //[JsonProperty("D")]
        //public bool PublicTeam { get; set; }

        //[JsonProperty("E")]
        //public bool Trusted { get; set; }

        //[JsonProperty("F")]
        //public int ViewBlockScore { get; set; }

        //[JsonProperty("G")]
        //public string? Website { get; set; }

        //[JsonProperty("H")]
        //public string? Whitepaper { get; set; }

        //[JsonProperty("I")]
        //public string? Twitter { get; set; }

        //[JsonProperty("J")]
        //public string? Telegram { get; set; }

        //[JsonProperty("K")]
        //public string? Github { get; set; }

        //[JsonProperty("L")]
        //public string? Linkedin { get; set; }

    }

    public enum SmartContractType
    {
        GenericDapp = 0,
        FungibleToken = 1,
        NonfungibleToken = 2,
        DecentralisedExchange = 3
    }
}
