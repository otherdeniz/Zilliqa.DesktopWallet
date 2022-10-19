using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.ViewModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class ContractCallTransactionForm : DialogWithPasswordBaseForm
    {
        public static void ExecuteShow(Form parentForm, 
            AccountViewModel? account = null, 
            string? contractAddress = null)
        {
            var form = new ContractCallTransactionForm();
            form.LoadSenderAccounts(account?.AccountData as MyAccount);
            //form.ToAddress
            form.Show(parentForm);
        }

        public ContractCallTransactionForm()
        {
            InitializeComponent();
        }

        public string ToAddress { get; private set; } = string.Empty;

        public decimal Amount { get; private set; }

        protected override void ExecuteResult()
        {

        }

        protected override bool OnOk()
        {
            if (base.OnOk())
            {
                return true;
            }
            return false;
        }

        protected override bool CheckFields()
        {
            return base.CheckFields();
        }

        protected override void AccountSelected(AccountViewModel selectedAccount)
        {

        }
    }
}
