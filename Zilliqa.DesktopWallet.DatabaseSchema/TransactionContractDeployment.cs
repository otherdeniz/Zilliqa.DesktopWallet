namespace Zilliqa.DesktopWallet.DatabaseSchema
{
    public class TransactionContractDeployment
    {
        public string Code { get; set; }

        private List<TransactionContractDeploymentVariable> Variables { get; set; } = new ();
    }

    public class TransactionContractDeploymentVariable
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public string Type { get; set; }
    }
}
