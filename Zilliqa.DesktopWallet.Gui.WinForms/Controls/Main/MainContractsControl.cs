using Zilligraph.Database.Storage.FilterQuery;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ViewModel.DataSource;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    public partial class MainContractsControl : UserControl
    {
        private PageableDataSource<Transaction>? _pageableDataSource;

        public MainContractsControl()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void timerLoading_Tick(object sender, EventArgs e)
        {
            timerLoading.Enabled = false;
            _pageableDataSource = new PageableDataSource<Transaction>();
            _pageableDataSource.ExecuteAfterLoadCompleted(s => gridViewContracts.LoadData(s, typeof(Transaction)), true);
            Task.Run(() =>
            {
                var db = RepositoryManager.Instance.DatabaseRepository.Database;
                var transactionTable = db.GetTable<Transaction>();

                var filter = new FilterQueryField(nameof(Transaction.TransactionType),
                    (int)TransactionType.ContractDeployment);

                _pageableDataSource.Load(transactionTable.EnumerateRecords(filter).ToList());
            });
        }

        private void MainContractsControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                timerLoading.Enabled = true;
            }
        }

        private void gridViewContracts_SelectionChanged(object sender, GridView.GridViewControl.SelectedItemEventArgs e)
        {
            if (e.SelectedItem?.Value is Transaction selectedTransaction)
            {
                textBoxData.Text = selectedTransaction.Data;
                textBoxCode.Text = selectedTransaction.Code;
            }
        }
    }
}
