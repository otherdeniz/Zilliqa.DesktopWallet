﻿using System.Globalization;
using Newtonsoft.Json;
using Org.BouncyCastle.Math;
using Zillifriends.Shared.Common;
using Zilligraph.Database.Contract;
using Zilliqa.DesktopWallet.DatabaseSchema.ParsedData;

namespace Zilliqa.DesktopWallet.DatabaseSchema
{
    [TableModel(TableKind.NotMutable)]
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
        public string ContractName { get; set; }

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
        public string[] StateFields { get; set; }

        public string? TokenName()
        {
            return GetConstructorValue("name");
        }

        [CalculatedIndex]
        public string? TokenSymbol()
        {
            return GetConstructorValue("symbol");
        }

        public int TokenDecimals()
        {
            return GetConstructorValue<ParamValueUInt32>("decimals")?.Number32 ?? 0;
        }

        public string DisplayName()
        {
            var nameValue = TokenName();
            if (nameValue != null)
            {
                if (ContractName == "NonfungibleToken")
                {
                    return $"NFT, {nameValue.TokenNameShort()}";
                }
                return $"{ContractName}, {nameValue.TokenNameShort()}";
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

        public TParamValue? GetConstructorValue<TParamValue>(string vName) where TParamValue : ParamValue
        {
            return ConstructorValues
                .Where(p => p.Vname == vName)
                .Select(p => p.ResolvedValue as TParamValue)
                .FirstOrDefault();
        }

        public long AmountToTokenSatoshis(decimal amountDecimal)
        {
            var decimals = TokenDecimals();
            if (decimals > 0)
            {
                var multiplicator = Convert.ToDecimal(Math.Pow(10, decimals));
                return Convert.ToInt64(amountDecimal * multiplicator);
            }
            return Convert.ToInt64(amountDecimal);
        }

        public decimal AmountToDecimal(decimal? tokenSatoshis)
        {
            if (tokenSatoshis == null)
            {
                return 0;
            }
            var decimals = TokenDecimals();
            if (decimals > 0)
            {
                var divident = Convert.ToDecimal(Math.Pow(10, decimals));
                return tokenSatoshis.Value / divident;
            }
            return tokenSatoshis.Value;
        }

        public decimal AmountToDecimal(BigInteger? tokenSatoshis)
        {
            if (tokenSatoshis == null)
            {
                return 0;
            }
            var decimals = TokenDecimals();
            if (decimals > 0)
            {
                if (tokenSatoshis.BitLength <= 64)
                {
                    return AmountToDecimal((ulong)tokenSatoshis.LongValue);
                }
                var divident = Convert.ToDecimal(Math.Pow(10, decimals));
                var decimalString = tokenSatoshis.Divide(new BigInteger(divident.ToString(CultureInfo.InvariantCulture)))
                    .ToString();
                return decimal.TryParse(decimalString, out var decimalValue) ? decimalValue : 0;
            }
            return (ulong)tokenSatoshis.LongValue;
        }
    }

    public enum SmartContractType
    {
        GenericDapp = 0,
        FungibleToken = 1,
        NonfungibleToken = 2,
        DecentralisedExchange = 3
    }
}
