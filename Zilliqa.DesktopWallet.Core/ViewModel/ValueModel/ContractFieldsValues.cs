using Zilliqa.DesktopWallet.Core.ContractCode;
using Zilliqa.DesktopWallet.DatabaseSchema;
using Zilliqa.DesktopWallet.DatabaseSchema.ParsedData;

namespace Zilliqa.DesktopWallet.Core.ViewModel.ValueModel
{
    public class ContractFieldsValues
    {
        public ContractFieldsValues(SmartContract smartContract)
        {
            SmartContract = smartContract;
            ConstructorArguments = smartContract.ConstructorValues;
            var parser = new ScillaParser(smartContract.DeploymentTransaction.Value?.Code ?? "");
            Fields = parser.Fields;
            CodeTransitions = parser.Transitions;
        }

        public SmartContract SmartContract { get; }

        public IList<DataParam> ConstructorArguments { get; }

        public string[] Fields { get; }

        public IList<CodeTransition> CodeTransitions { get; }
    }
}
