using Zilliqa.DesktopWallet.Core;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ViewModel.DataSource;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    public partial class MainContractsControl : UserControl
    {
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
            Task.Run(() =>
            {
                var dataSource = RepositoryManager.Instance.DatabaseRepository.ReadSmartContractViewModelsPaged();
                WinFormsSynchronisationContext.ExecuteSynchronized(() =>
                {
                    gridViewContracts.LoadData(dataSource);
                });
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
