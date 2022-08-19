using System.Collections;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zilliqa.DesktopWallet.DatabaseSchema.ParsedData;

public class ParamValue
{
    public static ParamValue ResolveParam(IParam param)
    {
        if (param.Type == "String")
        {
            return new ParamValueString(param.Value);
        }
        if (param.Type == "ByStr20")
        {
            return new ParamValueHex20Bytes(param.Value);
        }
        if (param.Type == "Uint32"
            && ParamValueUInt32.TryParse(param.Value, out var valueUInt32))
        {
            return valueUInt32;
        }
        if (param.Type == "Uint128"
            && ParamValueUInt128.TryParse(param.Value, out var valueUInt128))
        {
            return valueUInt128;
        }
        if (ParamValueHex20BytesWithFunctionName.TryParse(param.Type, param.Value,
                out var valueHex20BytesWithFunctionName))
        {
            return valueHex20BytesWithFunctionName;
        }
        if (ParamValueConstructorWithArgumentsList.TryParse(param.Type, param.Value,
                out var valueConstructorWithArgumentsList))
        {
            return valueConstructorWithArgumentsList;
        }

        return new ParamValueInvalid();
    }
}

public class ParamValueInvalid : ParamValue
{
    public override string ToString()
    {
        return "(invalid value)";
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

public class ParamValueUInt128 : ParamValue
{
    public static bool TryParse(object value, out ParamValueUInt128 paramValue)
    {
        if (value is string stringValue
            && decimal.TryParse(stringValue, out var decimalValue))
        {
            paramValue = new ParamValueUInt128
            {
                Number128 = decimalValue,
                Number64 = long.TryParse(stringValue, out var longValue) ? longValue : -1
            };
            return true;
        }

        paramValue = null!;
        return false;
    }

    public decimal Number128 { get; private set; }

    public long Number64 { get; private set; }

    public override string ToString()
    {
        return Number128.ToString("0");
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

        paramValue = null;
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
            Hex = stringValue;
        }
    }

    public string Hex { get; } = null!;

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

    private static readonly Regex TypeRegex = new Regex(@"(0x[0-9|a-f]{40})\.([\w|\d]+)", RegexOptions.Compiled);

    public static bool TryParse(string type, object value, out ParamValueHex20BytesWithFunctionName paramValue)
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

        paramValue = null!;
        return false;
    }

    public string Hex { get; private set; } = null!;

    public string FunctionName { get; private set; } = null!;

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

    public static bool TryParse(string type, object value, out ParamValueConstructorWithArgumentsList paramValue)
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

        paramValue = null!;
        return false;
    }

    public string FunctionName { get; set; } = null!;

    public List<ParamValueConstructorWithArguments> Calls { get; private set; } = null!;
}

public class ParamValueConstructorWithArguments : ParamValue
{
    public static bool TryParse(object value, out ParamValueConstructorWithArguments result)
    {
        if (value is JToken jToken)
        {
            try
            {
                result = jToken.ToObject<ParamValueConstructorWithArguments>()!;
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
    public List<object> Arguments { get; set; } = null!;

    public List<object> ArgumentsParsed()
    {
        var list = new List<object>();
        foreach (object argument in Arguments)
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
        return list;
    }
}