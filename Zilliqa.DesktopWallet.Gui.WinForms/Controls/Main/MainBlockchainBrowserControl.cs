using Zilliqa.DesktopWallet.Core.ViewModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    public partial class MainBlockchainBrowserControl : UserControl
    {
        private readonly SynchronizationContext? _currentContext;
        private BlockchainBrowserViewModel _viewModel;

        public MainBlockchainBrowserControl()
        {
            InitializeComponent();
            _currentContext = SynchronizationContext.Current;
            _viewModel = new BlockchainBrowserViewModel();
            _viewModel.AfterRefresh += ViewModelOnAfterRefresh;
        }

        private void ViewModelOnAfterRefresh(object? sender, EventArgs e)
        {
            _currentContext?.Send(_ =>
            {
                propertyGridBlockchainInfo.SelectedObject = _viewModel.BlockchainInfo;
            }, null);
        }
    }
}
