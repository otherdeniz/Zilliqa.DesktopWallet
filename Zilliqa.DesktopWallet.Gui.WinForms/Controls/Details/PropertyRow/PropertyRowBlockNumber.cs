using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details.PropertyRow
{
    public partial class PropertyRowBlockNumber : PropertyRowBase
    {
        private int _blockNumber;

        public PropertyRowBlockNumber()
        {
            InitializeComponent();
        }

        public void LoadValue(string title, int blockNumber)
        {
            _blockNumber = blockNumber;
            labelName.Text = title;
            labelNumber.Text = blockNumber.ToString("#,##0");
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            var masterPanel = DrillDownMasterPanelControl.FindParentDrillDownMasterPanel(this);
            var controlIsInRightPanel = DrillDownMasterPanelControl.ControlIsInRightPanel(this);
            if (masterPanel != null)
            {
                masterPanel.DisplayValue(new BlockNumberValue(_blockNumber), !controlIsInRightPanel, _ => { }, this);
            }
        }
    }
}
