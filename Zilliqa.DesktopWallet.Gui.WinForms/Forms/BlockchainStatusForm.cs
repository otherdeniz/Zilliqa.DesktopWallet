namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class BlockchainStatusForm : Form
    {
        private static BlockchainStatusForm? _form;

        public static void DisplayForm(Form owner)
        {
            if (_form == null)
            {
                _form = new BlockchainStatusForm();
                _form.Show(owner);
            }
            else
            {
                _form.Focus();
            }
        }

        public BlockchainStatusForm()
        {
            InitializeComponent();
        }

        private void BlockchainStatusForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _form = null;
        }
    }
}
