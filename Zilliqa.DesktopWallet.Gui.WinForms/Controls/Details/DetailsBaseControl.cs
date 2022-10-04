using System.ComponentModel;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details
{
    public partial class DetailsBaseControl : UserControl
    {
        public DetailsBaseControl()
        {
            InitializeComponent();
        }

        [DefaultValue(null)]
        public DrillDownMasterPanelControl? DrillDownPanel { get; set; }

        [DefaultValue(false)]
        public bool IsDrillDownMainControl { get; set; }

        public virtual void LoadViewModel(object viewModel)
        {
        }

        public bool CanDrillDownToObject(object viewModel)
        {
            return DrillDownPanel?.ContainsValueUniqueId(viewModel) == false;
        }

        public void DrillDownToObject(object viewModel, Action<object?>? afterClose = null, object? afterCloseArgument = null)
        {
            DrillDownPanel?.DisplayValue(viewModel, IsDrillDownMainControl, afterClose, afterCloseArgument);
        }
    }
}
