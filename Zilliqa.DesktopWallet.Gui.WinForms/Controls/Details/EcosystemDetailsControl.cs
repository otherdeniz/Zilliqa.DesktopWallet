using Zilliqa.DesktopWallet.Core.ViewModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details
{
    public partial class EcosystemDetailsControl : UserControl
    {
        private EcosystemRowViewModel? _viewModel;

        public EcosystemDetailsControl()
        {
            InitializeComponent();
        }

        public void LoadEcosystem(EcosystemRowViewModel viewModel)
        {
            _viewModel = viewModel;
            pictureBoxIcon.Image = viewModel.IconModel.Icon48;
            labelName.Text = viewModel.Name;
            labelDescription.Text = viewModel.Description;

        }
    }
}
