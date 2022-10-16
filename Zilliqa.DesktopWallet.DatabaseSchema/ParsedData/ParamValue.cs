using System.Collections;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Math;
using Zilliqa.DesktopWallet.ApiClient.Utils;

namespace Zilliqa.DesktopWallet.DatabaseSchema.ParsedData;

public class ParamValue
{
    public static ParamValue ResolveParam(IParam param)
    {
        if (param.Type == ParamTypes.String)
        {
            return new ParamValueString(param.Value);
        }
        if (param.Type == ParamTypes.ByStr20)
        {
            return new ParamValueHex20Bytes(param.Value);
        }
        if (param.Type == ParamTypes.Uint32
            && ParamValueUInt32.TryParse(param.Value, out var valueUInt32))
        {
            return valueUInt32;
        }
        if (param.Type == ParamTypes.BNum
            && ParamValueUInt32.TryParse(param.Value, out var valueBnum))
        {
            return valueBnum;
        }
        if ((param.Type == ParamTypes.Uint128 || param.Type == ParamTypes.Uint256)
            && ParamValueBigInteger.TryParse(param.Value, out var valueBigInteger))
        {
            return valueBigInteger;
        }
        if (ParamValueHex20BytesWithFunctionName.TryParse(param.Type, param.Value,
                out var valueHex20BytesWithFunctionName))
        {
            return valueHex20BytesWithFunctionName!;
        }
        if (ParamValueConstructorWithArgumentsList.TryParse(param.Type, param.Value,
                out var valueConstructorWithArgumentsList))
        {
            return valueConstructorWithArgumentsList!;
        }

        return new ParamValueUnknown();
    }
}

public class ParamValueUnknown : ParamValue
{
    public override string ToString()
    {
        return "(unknown value)";
    }
}

public class ParamValueString : ParamValue
{
    public ParamValueString(object value)
    {
        if (value is string stringValue)
        {
            Text = stringValue;
        }
    }

    public string Text { get; } = null!;

    public override string ToString()
    {
        return Text;
    }
}

public class ParamValueBigInteger : ParamValue
{
    public static bool TryParse(object value, out ParamValueBigInteger paramValue)
    {
        try
        {
            if (value is string stringValue)
            {
                paramValue = new ParamValueBigInteger(new BigInteger(stringValue),
                    long.TryParse(stringValue, out var longValue) ? longValue : -1);
                return true;
            }
        }
        catch (Exception)
        {
            // failed
        }

        paramValue = null!;
        return false;
    }

    public ParamValueBigInteger(BigInteger numberBig, long number64)
    {
        NumberBig = numberBig;
        Number64 = number64;
    }

    public BigInteger NumberBig { get; }

    public long Number64 { get; }

    public override string ToString()
    {
        return NumberBig.ToString();
    }
}

public class ParamValueUInt32 : ParamValue
{
    public static bool TryParse(object value, out ParamValueUInt32 paramValue)
    {
        if (value is string stringValue
            && int.TryParse(stringValue, out var number))
        {
            paramValue = new ParamValueUInt32
            {
                Number32 = number
            };
            return true;
        }

        paramValue = null!;
        return false;
    }

    public int Number32 { get; private set; }

    public override string ToString()
    {
        return Number32.ToString();
    }
}

public class ParamValueHex20Bytes : ParamValue
{
    public ParamValueHex20Bytes(object value)
    {
        if (value is string stringValue)
        {
            Hex = stringValue.StartsWith("0x") ? stringValue.Substring(2) : stringValue;
        }
    }

    public string Hex { get; } = null!;

    public string? Bech32Address => Hex.FromBase16ToBech32Address();
    
    public override string ToString()
    {
        return Hex;
    }
}

public class ParamValueHex20BytesWithFunctionName : ParamValue
{
#pragma warning disable S125 // commented out code
    // Example type = 0x459cb2d3baf7e61cfbd5fe362f289ae92b2babb0.Coins
    /*
     "value": {
        "argtypes": [],
        "arguments": [
          {
            "argtypes": [],
            "arguments": [],
            "constructor": "0x459cb2d3baf7e61cfbd5fe362f289ae92b2babb0.Zil"
          },
          "338675615897421"
        ],
        "constructor": "0x459cb2d3baf7e61cfbd5fe362f289ae92b2babb0.Coins"
      }
     */
#pragma warning restore S125

    private static readonly Regex TypeRegex = new Regex(@"0x([0-9|a-f]{40})\.([\w|\d]+)", RegexOptions.Compiled);

    public static bool TryParse(string type, object value, out ParamValueHex20BytesWithFunctionName? paramValue)
    {
        var match = TypeRegex.Match(type);
        if (match.Success)
        {
            paramValue = new ParamValueHex20BytesWithFunctionName
            {
                Hex = match.Groups[1].Value,
                FunctionName = match.Groups[2].Value
            };
            if (ParamValueConstructorWithArguments.TryParse(value, out var valueConstructorWithArguments))
            {
                paramValue.Value = valueConstructorWithArguments;
            }
            return true;
        }

        paramValue = null;
        return false;
    }

    public string Hex { get; private set; } = null!;

    public string? Bech32Address => Hex.FromBase16ToBech32Address();

    public string FunctionName { get; private set; } = null!;

    [TypeConverter(typeof(ExpandableObjectConverter))] //Attribute only for GUI PropertyGrid
    public ParamValueConstructorWithArguments? Value { get; private set; }

    public override string ToString()
    {
        return $"{Hex}.{FunctionName}";
    }
}

public class ParamValueConstructorWithArgumentsList : ParamValue
{
#pragma warning disable S125 // commented out code
    // Example type = "List (AccountValue)"
    /*
     "value": [{
            "constructor": "AccountValue",
            "argtypes": [],
            "arguments": ["0xc0e28525e9d329156e16603b9c1b6e4a9c7ed813", "50000000000000"]
           }
        ]
     */
#pragma warning restore S125

    private static readonly Regex TypeRegex = new Regex(@"List \(([\w|\d]+)\)", RegexOptions.Compiled);

    public static bool TryParse(string type, object value, out ParamValueConstructorWithArgumentsList? paramValue)
    {
        var match = TypeRegex.Match(type);
        if (match.Success && value is JToken jTokenList)
        {
            paramValue = new ParamValueConstructorWithArgumentsList
            {
                FunctionName = match.Groups[1].Value
            };

            var calls = new List<ParamValueConstructorWithArguments>();
            if (jTokenList.ToObject<List<object>>() is IList valueList)
            {
                foreach (object listItem in valueList)
                {
                    if (ParamValueConstructorWithArguments.TryParse(listItem, out var valueConstructorWithArguments))
                    {
                        calls.Add(valueConstructorWithArguments);
                    }
                }
            }

            paramValue.Calls = calls;
            return true;
        }

        paramValue = null;
        return false;
    }

    public string FunctionName { get; set; } = null!;

    [TypeConverter(typeof(ExpandableObjectConverter))] //only for GUI PropertyGrid
    public List<ParamValueConstructorWithArguments> Calls { get; private set; } = null!;
}

public class ParamValueConstructorWithArguments : ParamValue
{
    private List<object>? _argumentsRaw;
    private List<object>? _argumentsParsed;

    public static bool TryParse(object value, out ParamValueConstructorWithArguments? result)
    {
        if (value is JToken jToken)
        {
            try
            {
                result = jToken.ToObject<ParamValueConstructorWithArguments>();
                return result != null;
            }
            catch (Exception)
            {
                // failed
            }
        }

        result = null!;
        return false;
    }

    [JsonProperty("constructor")]
    public string Constructor { get; set; } = null!;

    [JsonProperty("argtypes")]
    public List<object> Argtypes { get; set; } = null!;

    [JsonProperty("arguments")]
    public List<object> Arguments
    {
        get => _argumentsParsed ??= GetArgumentsParsed();
        set
        {
            _argumentsRaw = value;
            _argumentsParsed = null;
        }
    }

    private List<object> GetArgumentsParsed()
    {
        var list = new List<object>();
        if (_argumentsRaw != null)
        {
            foreach (object argument in _argumentsRaw)
            {
                if (argument is string stringValue)
                {
                    list.Add(stringValue);
                }
                else if (TryParse(argument, out var valueConstructorWithArguments))
                {
                    list.Add(valueConstructorWithArguments);
                }
                else
                {
                    list.Add(argument);
                }
            }
        }
        return list;
    }
}