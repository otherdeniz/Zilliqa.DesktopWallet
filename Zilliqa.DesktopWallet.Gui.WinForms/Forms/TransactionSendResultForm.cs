using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class TransactionSendResultForm : Form
    {

        public static void ExecuteShow(Form parentForm, SendTransactionResult sendTransactionResult)
        {
            var form = new TransactionSendResultForm();
            form.labelSender.Text = new AddressValue(sendTransactionResult.Sender).ToString();
            form.labelRecipient.Text = new AddressValue(sendTransactionResult.Recipient).ToString();
            form.labelTransactionPayload.Text = sendTransactionResult.PayloadInfo;
            form.labelTransactionMessage.Text = sendTransactionResult.Message;
            form.labelId.Text = sendTransactionResult.TransactionId;
            if (sendTransactionResult.Success)
            {
                form.pictureBox1.Image = form.imageListStatus.Images[1];
                form.labelStatus.Text = "waiting for confirmation";
            }
            else
            {
                form.pictureBox1.Image = form.imageListStatus.Images[2];
                form.labelStatus.Text = "failed";
            }
            form.timerAutoClose.Enabled = true;
            form.Show(parentForm);
        }

        private int _closeSeconds = 9;

        public TransactionSendResultForm()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timerRefreshStatus_Tick(object sender, EventArgs e)
        {

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
