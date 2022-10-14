using Zilliqa.DesktopWallet.Core.ContractCode;

namespace Zilliqa.DesktopWallet.Core.ViewModel.ValueModel
{
    public class ScillaCodeValue
    {
        public ScillaCodeValue(string code)
        {
            Code = code;
        }

        public string Code { get; }

        public ScillaParser ScillaParser => new ScillaParser(Code);

        public override string ToString()
        {
            return Code;
        }
    }
}
