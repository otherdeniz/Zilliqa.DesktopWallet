namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class SendTokenForm : DialogWithPasswordBaseForm
    {
        public SendTokenForm()
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
