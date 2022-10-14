using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class ContractStateQueryForm : Form
    {
        public static void ExecuteShow(Form parentForm, SmartContract smartContract, string field)
        {
            var form = new ContractStateQueryForm();
            form.labelContract.Text = smartContract.DisplayName();
            form.labelField.Text = field;
            form.QueryValue(smartContract, field);
            form.Show(parentForm);
        }

        public ContractStateQueryForm()
        {
            InitializeComponent();
        }

        private void QueryValue(SmartContract smartContract, string field)
        {
            Task.Run(async () =>
            {
                string value = "";
                try
                {
                    value =
                        (await ZilliqaClient.DefaultInstance.GetSmartContractSubStateValue<object>(
                            smartContract.ContractAddress, field))
                        ?.ToString() ?? "";
                }
                catch (Exception e)
                {
                    value = e.Message;
                }
                WinFormsSynchronisationContext.ExecuteSynchronized(() =>
                {
                    textValue.Text = value;
                });
            });
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
