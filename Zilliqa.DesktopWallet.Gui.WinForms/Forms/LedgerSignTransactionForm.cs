using Zilliqa.DesktopWallet.ApiClient.Model;
using Zilliqa.DesktopWallet.Core;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.Services.Model;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class LedgerSignTransactionForm : Form
    {
        private static Form? MainForm;

        public static void Initialise(Form mainForm)
        {
            MainForm = mainForm;
            LedgerSenderAccount.SignTransactionDelegate = OnSignTransaction;
        }

        private static void OnSignTransaction(MyAccount account,
            TransactionPayload transaction,
            string recipient,
            string details)
        {

        }

        public LedgerSignTransactionForm()
        {
            InitializeComponent();
        }

        private void buttonGetLedgerAddress_Click(object sender, EventArgs e)
        {
            buttonGetLedgerAddress.Enabled = false;
            labelConnectHint.Visible = false;
            labelQueryLedger.Visible = true;
            labelLedgerError.Visible = false;
            textLedgerAddress.Visible = false;
            textLedgerAddress.ForeColor = Color.Blue;
            Task.Run(async () =>
            {
                using (var ledgerService = new LedgerWalletService())
                {
                    try
                    {
                        var ledgerAddress = await ledgerService.ReadAddressBech32Async();
                        WinFormsSynchronisationContext.ExecuteSynchronizedAndWait(() =>
                        {
                            textLedgerAddress.Text = ledgerAddress.AddressBech32;
                            labelQueryLedger.Visible = false;
                            labelLedgerError.Visible = false;
                            textLedgerAddress.Visible = true;
                            buttonGetLedgerAddress.Enabled = true;
                        });
                    }
                    catch (Exception exception)
                    {
                        WinFormsSynchronisationContext.ExecuteSynchronizedAndWait(() =>
                        {
                            labelLedgerError.Text = exception.Message;
                            labelQueryLedger.Visible = false;
                            labelLedgerError.Visible = true;
                            textLedgerAddress.Visible = false;
                            buttonGetLedgerAddress.Enabled = true;
                        });
                    }
                }
            });
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
