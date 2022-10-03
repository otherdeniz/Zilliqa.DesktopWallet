using System.Text.RegularExpressions;

namespace Zilliqa.DesktopWallet.Core.ContractCode
{
    public class ScillaParser
    {
        public static readonly Regex ContractNameRegEx =
            new Regex(@"^\s*contract\s+(\w+)", RegexOptions.Multiline | RegexOptions.Compiled);
        public static readonly Regex ContractNameSingleLineRegEx =
            new Regex(@"\s+contract\s+(\w+)\s*\(", RegexOptions.Compiled);
        public static readonly Regex FieldRegEx =
            new Regex(@"^\s*field\s+(\w+)\s*:", RegexOptions.Multiline | RegexOptions.Compiled);
        public static readonly Regex TransitionRegEx =
            new Regex(@"transition ([A-z]+)\s*\(((?:[A-z\d:\s,]|\([A-z\d:\s,]*\))*)\)", RegexOptions.Multiline | RegexOptions.Compiled);
        public static readonly Regex TransitionArgumentRegEx =
            new Regex(@"([A-z]*):((?:[A-z\d:\s]|\([A-z\d:\s]*\))*)", RegexOptions.Multiline | RegexOptions.Compiled);

        public ScillaParser(string code)
        {
            Code = code;
        }

        public string Code { get; }

        public string? ParseContractName()
        {
            var contractNameMatch = ContractNameRegEx.Match(Code);
            if (contractNameMatch.Success)
            {
                return contractNameMatch.Groups[1].Value;
            }
            var contractNameSingleLineMatch = ContractNameSingleLineRegEx.Match(Code);
            if (contractNameSingleLineMatch.Success)
            {
                return contractNameSingleLineMatch.Groups[1].Value;
            }
            return null;
        }

        public string[] ParseFields()
        {
            return FieldRegEx.Matches(Code)
                .Select(f => f.Groups[1].Value)
                .ToArray();
        }

        public List<CodeTransition> ParseTransitions()
        {
            return TransitionRegEx.Matches(Code)
                .Select(t => new CodeTransition(t.Groups[1].Value, t.Groups[2].Value))
                .ToList();
        }
    }

    public class CodeTransition
    {
        public CodeTransition(string name, string arguments)
        {
            Name = name;
            Arguments = arguments;
        }

        public string Name { get; }

        public string Arguments { get; }

        public List<CodeTransitionArgument> ParseArguments()
        {
            return ScillaParser.TransitionArgumentRegEx.Matches(Arguments)
                .Select(t => new CodeTransitionArgument(t.Groups[1].Value, t.Groups[2].Value))
                .ToList();
        }
    }

    public class CodeTransitionArgument
    {
        public CodeTransitionArgument(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; }

        public string Type { get; }
    }
}
