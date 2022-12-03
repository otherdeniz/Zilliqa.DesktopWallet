using Zilliqa.DesktopWallet.ApiClient.Model;
using Zilliqa.DesktopWallet.Core;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.Services.Model;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class LedgerSignTransactionForm : Form
    {
        private static Form? MainForm;
        private TransactionPayload _transaction = null!;

        public static void Initialise(Form mainForm)
        {
            MainForm = mainForm;
            LedgerSenderAccount.SignTransactionDelegate = OnSignTransaction;
        }

        private static void OnSignTransaction(MyAccount account,
            TransactionPayload transaction,
            string recipient,
            string transactionPayload)
        {
            WinFormsSynchronisationContext.ExecuteSynchronized(() =>
            {
                using (var form = new LedgerSignTransactionForm())
                {
                    form.labelRecipient.Text = recipient;
                    form.labelTransactionPayload.Text = transactionPayload;
                    form.textExpectedAddress.Text = account.GetAddressBech32();
                    form._transaction = transaction;
                    if (form.ShowDialog(MainForm!) != DialogResult.OK)
                    {
                        throw new TransactionCanceledException();
                    }
                }
            });
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
                        WinFormsSynchronisationContext.ExecuteSynchronized(() =>
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
                        WinFormsSynchronisationContext.ExecuteSynchronized(() =>
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
            buttonSign.Enabled = false;
            labelSignHint.Visible = false;
            labelSignQuery.Visible = true;
            labelSignError.Visible = false;
            Task.Run(async () =>
            {
                using (var ledgerService = new LedgerWalletService())
                {
                    try
                    {
                        var signed = await ledgerService.SignTransactionAsync(_transaction);
                        WinFormsSynchronisationContext.ExecuteSynchronized(() =>
                        {
                            labelSignQuery.Visible = false;
                            labelSignError.Visible = false;
                            DialogResult = signed 
                                ? DialogResult.OK
                                : DialogResult.Cancel;
                            Close();
                        });
                    }
                    catch (Exception exception)
                    {
                        WinFormsSynchronisationContext.ExecuteSynchronized(() =>
                        {
                            labelSignError.Text = exception.Message;
                            labelSignQuery.Visible = false;
                            labelSignError.Visible = true;
                            buttonSign.Enabled = true;
                        });
                    }
                }
            });
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
