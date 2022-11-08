using System.Text.RegularExpressions;

namespace Zilliqa.DesktopWallet.Core.ContractCode
{
    public class ScillaParser
    {
        public static readonly Regex ContractNameRegEx =
            new Regex(@"^\s*contract\s+(\w+)\s*\(((?:[A-z\d:\s,]|\([A-z\d:\s,]*\))*)\)", RegexOptions.Multiline | RegexOptions.Compiled);
        public static readonly Regex ContractNameSingleLineRegEx =
            new Regex(@"\s+contract\s+(\w+)\s*\(((?:[A-z\d:\s,]|\([A-z\d:\s,]*\))*)\)", RegexOptions.Multiline | RegexOptions.Compiled);
        public static readonly Regex FieldRegEx =
            new Regex(@"^\s*field\s+(\w+)\s*:", RegexOptions.Multiline | RegexOptions.Compiled);
        public static readonly Regex TransitionRegEx =
            new Regex(@"transition\s+([A-z]+)\s*\(((?:[A-z\d:\s,]|\([A-z\d\s\(\)]*\)|\(\*.+\*\))*)\)", RegexOptions.Multiline | RegexOptions.Compiled);
        public static readonly Regex ArgumentRegEx =
            new Regex(@"([A-z\d]*)\s*:\s*((?:[A-z\d:\s]|\([A-z\d\s\(\)]*\))*)", RegexOptions.Multiline | RegexOptions.Compiled);

        private string[]? _fields;
        private List<CodeTransition>? _transitions;
        private (bool, CodeContract?)? _contractName;

        public ScillaParser(string code)
        {
            Code = code;
        }

        public string Code { get; }

        public CodeContract? ContractName
        {
            get
            {
                if (_contractName == null)
                {
                    _contractName = (true, ParseContractName());
                }
                return _contractName.Value.Item2;
            }
        }

        public string[] Fields => _fields ??= ParseFields();

        public List<CodeTransition> Transitions => _transitions ??= ParseTransitions();

        private CodeContract? ParseContractName()
        {
            var contractNameMatch1 = ContractNameRegEx.Match(Code);
            if (contractNameMatch1.Success)
            {
                return new CodeContract(contractNameMatch1.Groups[1].Value, contractNameMatch1.Groups[2].Value);
            }
            var contractNameMatch2 = ContractNameSingleLineRegEx.Match(Code);
            if (contractNameMatch2.Success)
            {
                return new CodeContract(contractNameMatch2.Groups[1].Value, contractNameMatch2.Groups[2].Value);
            }
            return null;
        }

        private List<CodeTransition> ParseTransitions()
        {
            return TransitionRegEx.Matches(Code)
                .Select(t => new CodeTransition(t.Groups[1].Value, t.Groups[2].Value))
                .ToList();
        }

        private string[] ParseFields()
        {
            return FieldRegEx.Matches(Code)
                .Select(f => f.Groups[1].Value)
                .Distinct()
                .ToArray();
        }

    }

    public class CodeContract
    {
        public CodeContract(string name, string argumentsJson)
        {
            Name = name;
            ArgumentsJson = argumentsJson;
        }

        public string Name { get; }

        public string ArgumentsJson { get; }

        public List<CodeTransitionArgument> ParseArguments()
        {
            return ScillaParser.ArgumentRegEx.Matches(ArgumentsJson)
                .Select(t => new CodeTransitionArgument(t.Groups[1].Value, t.Groups[2].Value))
                .ToList();
        }
    }

    public class CodeTransition
    {
        public CodeTransition(string name, string argumentsJson)
        {
            Name = name;
            ArgumentsJson = argumentsJson;
        }

        public string Name { get; }

        public string ArgumentsJson { get; }

        public List<CodeTransitionArgument> ParseArguments()
        {
            return ScillaParser.ArgumentRegEx.Matches(ArgumentsJson)
                .Select(t => new CodeTransitionArgument(t.Groups[1].Value, t.Groups[2].Value))
                .ToList();
        }
    }

    public class CodeTransitionArgument
    {
        public CodeTransitionArgument(string name, string type)
        {
            Name = name.Trim();
            Type = type.Trim();
        }

        public string Name { get; }

        public string Type { get; }
    }
}
