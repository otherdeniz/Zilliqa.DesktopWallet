using Newtonsoft.Json;
using Zilligraph.Database.Contract;
using Zilliqa.DesktopWallet.DatabaseSchema.ParsedData;

namespace Zilliqa.DesktopWallet.DatabaseSchema
{
    public class SmartContract
    {
        public static class ContractNames
        {
            public const string FungibleToken = "FungibleToken";
            public const string NonfungibleToken = "NonfungibleToken";
        }

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
        public string ContractName { get; set; }

        [JsonProperty("D")]
        public List<DataParam> ConstructorValues { get; set; }

        [JsonProperty("E")]
        [PropertyIndex]
        public string OwnerAddress { get; set; }

        [JsonProperty("F")]
        [PropertyIndex]
        public string ContractAddress { get; set; }

        [CalculatedIndex]
        public string? TokenSymbol()
        {
            return GetConstructorValue("symbol");
        }

        public string? TokenName()
        {
            return GetConstructorValue("name");
        }

        public string DisplayName()
        {
            var nameValue = TokenName();
            if (nameValue != null)
            {
                return $"{ContractName}, {nameValue}";
            }
            return ContractName;
        }

        public string? GetConstructorValue(string vName)
        {
            return ConstructorValues
                .Where(p => p.Vname == vName)
                .Select(p => p.Value.ToString())
                .FirstOrDefault();
        }
    }

}
