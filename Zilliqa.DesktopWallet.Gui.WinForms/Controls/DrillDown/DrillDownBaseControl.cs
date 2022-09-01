using System.ComponentModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown
{
    public partial class DrillDownBaseControl : UserControl
    {
        public DrillDownBaseControl()
        {
            InitializeComponent();
        }

        [DefaultValue(null)]
        public DrillDownMasterPanelControl? DrillDownPanel { get; set; }

        [DefaultValue(false)]
        public bool IsDrillDownMainControl { get; set; }

        public bool CanDrillDownToObject(object viewModel)
        {
            return DrillDownPanel?.ContainsValueUniqueId(viewModel) == false;
        }

        public void DrillDownToObject(object viewModel, Action<object?>? afterClose = null, object? afterCloseArgument = null)
        {
            DrillDownPanel?.DisplayViewModel(viewModel, IsDrillDownMainControl, afterClose, afterCloseArgument);
        }
    }
}
