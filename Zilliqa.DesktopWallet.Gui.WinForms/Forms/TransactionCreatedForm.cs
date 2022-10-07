using Zilliqa.DesktopWallet.Core.Services;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class TransactionCreatedForm : Form
    {

        public static void ExecuteShow(Form parentForm, SendTransactionResult sendTransactionResult)
        {
            var form = new TransactionCreatedForm();
            form.labelTransactionPayload.Text = sendTransactionResult.PayloadInfo;
            form.labelTransactionMessage.Text = sendTransactionResult.Message;
            form.timerAutoClose.Enabled = true;
            form.Show(parentForm);
        }

        private int _closeSeconds = 9;

        public TransactionCreatedForm()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timerAutoClose_Tick(object sender, EventArgs e)
        {
            if (_closeSeconds > 0)
            {
                buttonClose.Tag ??= buttonClose.Text;
                buttonClose.Text = $"{buttonClose.Tag} ({_closeSeconds})";
                _closeSeconds--;
            }
            else
            {
                Close();
            }
        }
    }
}
