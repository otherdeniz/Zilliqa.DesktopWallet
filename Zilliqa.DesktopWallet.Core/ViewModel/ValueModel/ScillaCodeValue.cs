using Zilliqa.DesktopWallet.Core.ContractCode;

namespace Zilliqa.DesktopWallet.Core.ViewModel.ValueModel
{
    public class ScillaCodeValue
    {
        public ScillaCodeValue(string code)
        {
            Code = code;
            ScillaParser = new ScillaParser(Code);
        }

        public string Code { get; }

        public ScillaParser ScillaParser { get; }

        public override string ToString()
        {
            return Code;
        }
    }
}
