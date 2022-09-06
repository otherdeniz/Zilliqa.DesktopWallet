using Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values
{
    public class DrillDownLinkLabel : LinkLabel
    {
        private object? _viewValue;
        private DrillDownMasterPanelControl? _drillDownMasterPanel;
        public DrillDownLinkLabel()
        {
            LinkColor = GuiColors.LinkForeColor;
            ActiveLinkColor = GuiColors.LinkForeColor;
            VisitedLinkColor = GuiColors.LinkForeColor;
            LinkClicked += OnLinkClicked;
        }

        public void LoadValue(object viewValue, DrillDownMasterPanelControl? drillDownMasterPanel)
        {
            _viewValue = viewValue;
            _drillDownMasterPanel = drillDownMasterPanel;
            Text = viewValue.ToString();
        }

        private void OnLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_drillDownMasterPanel != null
                && _viewValue != null)
            {
                _drillDownMasterPanel.DisplayValue(_viewValue, false);
            }
        }

    }
}
