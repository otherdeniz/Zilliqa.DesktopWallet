namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown
{
    public partial class DrillDownObjectControl : UserControl
    {
        private object? _viewModel;

        public DrillDownObjectControl()
        {
            InitializeComponent();
        }

        public void LoadGenericViewModel(object viewModel)
        {
            _viewModel = viewModel;
        }
    }
}
