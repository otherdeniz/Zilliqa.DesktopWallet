namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    public partial class RightDrillDownPanelControl : UserControl
    {
        private readonly List<object> _displayHierarchy = new List<object>();

        public RightDrillDownPanelControl()
        {
            InitializeComponent();
        }

        public void DisplayRightPanel(object viewModel)
        {
            toolStripLabelTitle.Visible = true;
            toolStripLabelTitle.Text = viewModel.ToString();
            toolStripDropDownTitle.Visible = false;
            panelRight.Visible = true;
            splitterRight.Visible = true;

        }

        private void buttonCloseRight_Click(object sender, EventArgs e)
        {
            panelRight.Visible = false;
            splitterRight.Visible = false;
        }
    }
}
