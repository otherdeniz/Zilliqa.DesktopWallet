
namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class SendContractCallTransactionForm : DialogWithPasswordBaseForm
    {
        public SendContractCallTransactionForm()
        {
            InitializeComponent();
        }

        protected override bool CheckFields()
        {
            return base.CheckFields();
        }

        protected override bool OnOk()
        {
            if (base.OnOk())
            {
                return true;
            }
            return false;
        }
    }
}
