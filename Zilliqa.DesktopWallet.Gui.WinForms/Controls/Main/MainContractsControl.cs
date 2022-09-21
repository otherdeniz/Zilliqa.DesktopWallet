using Zilliqa.DesktopWallet.Core;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    public partial class MainContractsControl : DrillDownMasterPanelControl
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
                    groupBoxGrid.Tag ??= groupBoxGrid.Text;
                    groupBoxGrid.Text = $"{groupBoxGrid.Tag} ({dataSource.RecordCount})";
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
            if (e.SelectedItem?.Value != null
                && sender is GridViewControl gridView)
            {
                DisplayValue(e.SelectedItem.Value, true, o =>
                {
                    if (o != gridView)
                    {
                        gridView.ClearSelection();
                    }
                }, gridView);
            }
        }
    }
}
