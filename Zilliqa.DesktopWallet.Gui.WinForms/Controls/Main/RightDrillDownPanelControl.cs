using Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    public partial class RightDrillDownPanelControl : UserControl
    {
        private readonly List<DisplayViewModelPathItem> _displayHierarchy = new();

        public RightDrillDownPanelControl()
        {
            InitializeComponent();
        }

        public void DisplayViewModel(object viewModel, bool resetHistory, Action? afterClose = null)
        {
            if (resetHistory)
            {
                _displayHierarchy.LastOrDefault()?.AfterClose?.Invoke();
                _displayHierarchy.Clear();
            }

            var pathItem = new DisplayViewModelPathItem(viewModel, 
                DrillDownControlFactory.CreateDisplayControl(viewModel), afterClose);

            _displayHierarchy.Add(pathItem);
            if (_displayHierarchy.Count == 1)
            {
                toolStripLabelTitle.Visible = true;
                toolStripLabelTitle.Text = viewModel.ToString();
                toolStripDropDownTitle.Visible = false;
            }
            else
            {
                toolStripLabelTitle.Visible = false;
                toolStripDropDownTitle.Visible = true;
                toolStripDropDownTitle.Text = viewModel.ToString();
                toolStripDropDownTitle.DropDownItems.Clear();
                for (int i = 1; i < _displayHierarchy.Count; i++)
                {
                    var pathIndex = _displayHierarchy.Count - i;
                    var pathButton = new ToolStripMenuItem(_displayHierarchy[pathIndex].ViewModel.ToString());
                    pathButton.Tag = pathIndex;
                    pathButton.Click += (sender, args) =>
                    {
                        if (sender is ToolStripMenuItem { Tag: int itemPathIndex })
                        {
                            GoBackInHistory(itemPathIndex);
                        }
                    };
                }
            }
            panelRight.Visible = true;
            splitterRight.Visible = true;
            ShowDisplayControl(pathItem);
        }

        private void GoBackInHistory(int pathIndex)
        {

        }

        private void ShowDisplayControl(DisplayViewModelPathItem pathItem)
        {
            panelRightControl.Controls.Clear();
            pathItem.DisplayControl.Dock = DockStyle.Fill;
            panelRightControl.Controls.Add(pathItem.DisplayControl);
        }

        private void buttonCloseRight_Click(object sender, EventArgs e)
        {
            panelRight.Visible = false;
            splitterRight.Visible = false;
            _displayHierarchy.LastOrDefault()?.AfterClose?.Invoke();
            _displayHierarchy.Clear();
        }

        private class DisplayViewModelPathItem
        {
            public DisplayViewModelPathItem(object viewModel, Control displayControl, Action? afterClose)
            {
                ViewModel = viewModel;
                DisplayControl = displayControl;
                AfterClose = afterClose;
            }

            public object ViewModel { get; }

            public Control DisplayControl { get; }

            public Action? AfterClose { get; }
        }
    }
}
