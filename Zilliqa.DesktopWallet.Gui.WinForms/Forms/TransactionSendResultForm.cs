using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.DatabaseSchema;

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
            form._transactionId = sendTransactionResult.TransactionId;
            if (sendTransactionResult.TransactionId != null 
                && sendTransactionResult.Success)
            {
                form.RefreshTransactionStatus();
                form.timerRefreshStatus.Enabled = true;
            }
            else
            {
                form.pictureBox1.Image = form.imageListStatus.Images[2];
                form.labelStatus.Text = "Failed";
            }
            form.Show(parentForm);
        }

        private string? _transactionId;
        private int _closeSeconds = 9;

        public TransactionSendResultForm()
        {
            InitializeComponent();
        }

        private void RefreshTransactionStatus()
        {
            if (_transactionId == null) return;
            var foundTransaction = RepositoryManager.Instance.DatabaseRepository.Database.GetTable<Transaction>()
                .FindRecord(nameof(Transaction.Id), _transactionId);
            if (foundTransaction == null)
            {
                pictureBox1.Image = imageListStatus.Images[0];
                labelStatus.Text = "Waiting for block download";
            }
            else if (foundTransaction.TransactionFailed)
            {
                pictureBox1.Image = imageListStatus.Images[2];
                labelStatus.Text = "Failed";
                timerRefreshStatus.Enabled = false;
            }
            else
            {
                pictureBox1.Image = imageListStatus.Images[1];
                labelStatus.Text = "Completed";
                timerRefreshStatus.Enabled = false;
                timerAutoClose.Enabled = true;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timerRefreshStatus_Tick(object sender, EventArgs e)
        {
            RefreshTransactionStatus();
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
