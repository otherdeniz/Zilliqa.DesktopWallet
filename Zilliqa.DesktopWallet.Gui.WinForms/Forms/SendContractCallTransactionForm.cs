using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.ViewModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class SendContractCallTransactionForm : DialogWithPasswordBaseForm
    {
        public SendContractCallTransactionForm()
        {
            InitializeComponent();
        }

        public string ToAddress { get; private set; } = string.Empty;

        public decimal Amount { get; private set; }

        public static void ExecuteShow(Form parentForm, AccountViewModel account)
        {
            var form = new SendContractCallTransactionForm();
            form.LoadSenderAccounts(account.AccountData as MyAccount);
            form.Show(parentForm);
        }

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
