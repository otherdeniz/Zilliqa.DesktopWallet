using System.Globalization;
using Zilliqa.DesktopWallet.Core;
using Zilliqa.DesktopWallet.Core.ContractCode;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.DatabaseSchema;
using Zilliqa.DesktopWallet.DatabaseSchema.ParsedData;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values.Arguments;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class ContractDeployTransactionForm : DialogWithPasswordBaseForm
    {
        public static void ExecuteShow(Form parentForm,
            AccountViewModel? account = null,
            SmartContract? templateContract = null)
        {
            var form = new ContractDeployTransactionForm();
            form.LoadSenderAccounts(account?.AccountData as MyAccount);
            if (templateContract != null)
            {
                form.scillaCodeText.Text = templateContract.DeploymentTransaction.Value?.Code ?? "";
                form.LoadConstructorArguments(templateContract.ConstructorValues);
            }
            else
            {
                form.scillaCodeText.Text = "";
            }
            form.Show(parentForm);
        }

        public ContractDeployTransactionForm()
        {
            InitializeComponent();
            scillaCodeText.Dock = DockStyle.Fill;
            panelTabConstructor.Dock = DockStyle.Fill;
        }

        protected override void ExecuteResult()
        {
            var parameters = panelArguments.Controls.OfType<ArgumentEditBaseControl>()
                .Select(c => new DataParam
                {
                    Vname = c.ArgumentName,
                    Type = c.ArgumentType,
                    Value = c.ArgumentValue
                }).ToList();
            var sendResult = SendTransactionService.Instance.DeployContract(
                SenderAccount!.AccountDetails,
                scillaCodeText.Text!,
                parameters);
            TransactionSendResultForm.ExecuteShow(this.Owner, sendResult);
        }

        protected override bool CheckFields()
        {
            return base.CheckFields()
                   && !string.IsNullOrEmpty(scillaCodeText.Text)
                   && buttonStepConstructor.Checked
                   && panelArguments.Controls.Count > 0
                   && panelArguments.Controls.OfType<ArgumentEditBaseControl>().All(c => c.IsValid);
        }

        protected override bool OnOk()
        {
            if (base.OnOk())
            {
                var scillaParser = new ScillaParser(scillaCodeText.Text!);
                if (scillaParser.ParseContractName() == null)
                {
                    MessageBox.Show("Could not read the contract name from scilla code", "Incomplete Scilla Code",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                return true;
            }
            return false;
        }

        private void LoadConstructorArguments(List<DataParam>? refreshArguments = null)
        {
            var scillaVersion = "0";
            if (refreshArguments?.FirstOrDefault(a => a.Vname == "_scilla_version") is { } scillaVersionParam)
            {
                scillaVersion = scillaVersionParam.Value.ToString();
            }
            if (refreshArguments == null)
            {
                var codeConstructorArguments = new ScillaParser(scillaCodeText.Text ?? "")
                    .ParseContractName()?.ParseArguments();
                if (codeConstructorArguments == null)
                {
                    return;
                }
                refreshArguments = codeConstructorArguments
                    .Select(a => new DataParam { Vname = a.Name, Type = a.Type, Value = "" }).ToList();
            }
            if (panelArguments.Controls.Count == 0)
            {
                AddConstructorArgumentControl("_scilla_version", "Uint32", scillaVersion);
            }
            foreach (var refreshArgument in refreshArguments.AsEnumerable().Reverse())
            {
                var currentControl = panelArguments.Controls.OfType<ArgumentEditBaseControl>()
                    .FirstOrDefault(c => c.ArgumentName == refreshArgument.Vname);
                if (currentControl != null && 
                    currentControl.ArgumentType != refreshArgument.Type)
                {
                    currentControl.ArgumentName = $"{currentControl.ArgumentName}:to-remove";
                    currentControl = null;
                }
                if (currentControl == null)
                {
                    AddConstructorArgumentControl(refreshArgument.Vname, refreshArgument.Type, refreshArgument.Value.ToString());
                }
            }

            var removeControls = panelArguments.Controls.OfType<ArgumentEditBaseControl>()
                .Where(c => c.ArgumentName != "_scilla_version"
                            && !refreshArguments.Any(a => a.Vname == c.ArgumentName)).ToArray();
            foreach (var removeControl in removeControls)
            {
                panelArguments.Controls.Remove(removeControl);
                removeControl.ArgumentValueChanged -= ArgumentEditControl_ValueChanged;
                removeControl.Dispose();
            }
        }

        private void AddConstructorArgumentControl(string name, string argumentType, string? currentValue = null)
        {
            var control = ArgumentEditBaseControl.CreateControl(argumentType);
            control.ArgumentValueChanged += ArgumentEditControl_ValueChanged;
            control.NameMinWidth = 90;
            control.TypeMinWidth = 65;
            control.Dock = DockStyle.Top;
            control.ArgumentName = name;
            if (currentValue != null 
                && argumentType != ParamTypes.ByStr20)
            {
                control.ArgumentValue = currentValue;
            }
            panelArguments.Controls.Add(control);
        }

        private void ContractDeployTransactionForm_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                TabButtonClick(buttonStepCode, scillaCodeText);
                textGasPrice.Text = RepositoryManager.Instance.BlockchainBrowserRepository.MinimumGasPrice
                    .ZilSatoshisToZil().ToString(CultureInfo.CurrentCulture);
                Task.Run(() =>
                {
                    var deployGasLimit = SendTransactionService.GasLimitDefaultDeployContract;
                    var deployFee = RepositoryManager.Instance.BlockchainBrowserRepository.MinimumGasPrice *
                                    deployGasLimit;
                    WinFormsSynchronisationContext.ExecuteSynchronized(() =>
                    {
                        textGasCost.Text = deployGasLimit.ToString("#,##0");
                        textFee.Text = deployFee.ZilSatoshisToZil().ToString(CultureInfo.CurrentCulture);
                    });
                });
            }
        }

        private void ArgumentEditControl_ValueChanged(object? sender, EventArgs e)
        {
            RefreshOkButton();
        }

        private void buttonStepCode_Click(object sender, EventArgs e)
        {
            TabButtonClick(buttonStepCode, scillaCodeText);
        }

        private void buttonStepConstructor_Click(object sender, EventArgs e)
        {
            TabButtonClick(buttonStepConstructor, panelTabConstructor);
            LoadConstructorArguments();
        }

        private void TabButtonClick(ToolStripButton button, Control tabPageControl)
        {
            foreach (var item in toolStripTabs.Items)
            {
                if (item is ToolStripButton itemButton)
                {
                    itemButton.Checked = false;
                    itemButton.Font = new Font(itemButton.Font, FontStyle.Regular);
                }
            }
            button.Checked = true;
            button.Font = new Font(button.Font, FontStyle.Bold);

            foreach (Control pageControl in panelTabs.Controls)
            {
                pageControl.Visible = false;
            }
            tabPageControl.Visible = true;
        }

    }
}
