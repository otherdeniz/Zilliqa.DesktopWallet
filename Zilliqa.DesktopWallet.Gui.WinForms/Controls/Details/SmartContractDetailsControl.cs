using Newtonsoft.Json;
using Zilligraph.Database.Storage.FilterQuery;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.ApiClient.Utils;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details
{
    public partial class SmartContractDetailsControl : DetailsBaseControl
    {
        public SmartContractDetailsControl()
        {
            InitializeComponent();
            transactionDetails.Dock = DockStyle.Fill;
            textConstructorArguments.Dock = DockStyle.Fill;
            textScillaCode.Dock = DockStyle.Fill;
            gridViewTransactions.Dock = DockStyle.Fill;
        }

        public void LoadSmartContract(SmartContractViewModel viewModel)
        {
            var deploymentTransaction = viewModel.SmartContractModel.DeploymentTransaction.Value;
            if (deploymentTransaction != null)
            {
                labelDate.Text = deploymentTransaction.Timestamp.ToLocalTime().ToString("g");
                labelTitle.Text = viewModel.SmartContractModel.DisplayName();
                labelAddress.Text = viewModel.SmartContractModel.ContractAddress.FromBase16ToBech32Address();
                transactionDetails.LoadTransaction(deploymentTransaction);
                textScillaCode.Text = deploymentTransaction.Code;
                var paramsText = JsonConvert.SerializeObject(deploymentTransaction.DataContractDeploymentParams,
                    Formatting.Indented, 
                    new JsonSerializerSettings
                    {
                        TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
                        TypeNameHandling = TypeNameHandling.None
                    });
                textConstructorArguments.Text = paramsText;
                LoadTransactions(viewModel);
            }
        }

        private void LoadTransactions(SmartContractViewModel viewModel)
        {
            Task.Run(() =>
            {
                var filter = new FilterCombination
                {
                    Method = FilterQueryCombinationMethod.Or,
                    Queries = new List<IFilterQuery>
                    {
                        new FilterQueryField(nameof(Transaction.SenderAddress),
                            viewModel.SmartContractModel.ContractAddress),
                        new FilterQueryField(nameof(Transaction.ToAddress),
                            viewModel.SmartContractModel.ContractAddress)
                    }
                };
                var contractAddress = new Address(viewModel.SmartContractModel.ContractAddress);
                var dataSource = RepositoryManager.Instance.DatabaseRepository
                    .ReadViewModelsPaged<ContractCallTransactionRowViewModel, Transaction>(t => 
                        new ContractCallTransactionRowViewModel(contractAddress, t),
                        filter);
                WinFormsSynchronisationContext.ExecuteSynchronized(() =>
                {
                    tabButtonTransactions.Tag ??= tabButtonTransactions.Text;
                    tabButtonTransactions.Text = $"{tabButtonTransactions.Tag} ({dataSource.RecordCount:#,##0})";
                    gridViewTransactions.LoadData(dataSource);
                });
            });
        }

        private void TabButtonClick(ToolStripButton button, Control tabPageControl)
        {
            foreach (var item in toolStripPages.Items)
            {
                if (item is ToolStripButton itemButton)
                {
                    itemButton.Checked = false;
                    itemButton.Font = new Font(itemButton.Font, FontStyle.Regular);
                }
            }
            button.Checked = true;
            button.Font = new Font(button.Font, FontStyle.Bold);

            foreach (Control pageControl in panelTabPagesTransactions.Controls)
            {
                pageControl.Visible = false;
            }
            tabPageControl.Visible = true;
        }

        private void SmartContractDetailsControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                TabButtonClick(tabButtonDeployTransaction, transactionDetails);
            }
        }

        private void tabButtonArguments_Click(object sender, EventArgs e)
        {
            TabButtonClick(tabButtonArguments, textConstructorArguments);
        }

        private void tabButtonCode_Click(object sender, EventArgs e)
        {
            TabButtonClick(tabButtonCode, textScillaCode);
        }

        private void tabButtonDeployTransaction_Click(object sender, EventArgs e)
        {
            TabButtonClick(tabButtonDeployTransaction, transactionDetails);
        }

        private void tabButtonTransactions_Click(object sender, EventArgs e)
        {
            TabButtonClick(tabButtonTransactions, gridViewTransactions);
        }
    }
}
