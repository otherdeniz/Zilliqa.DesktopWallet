using Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown
{
    public partial class DrillDownMasterPanelControl : UserControl
    {
        private readonly List<ViewValuePathItem> _displayHierarchy = new();
        private string? _mainValueUniqueId;
        private readonly HashSet<string> _valueUniqueIds = new();

        public DrillDownMasterPanelControl()
        {
            InitializeComponent();
        }

        public void SetMainValueUniqueId(object value)
        {
            SetMainValueUniqueId(ValueSelectionHelper.GetValueUniqueId(value));
        }

        public void SetMainValueUniqueId(string uniqueId)
        {
            _mainValueUniqueId = uniqueId;
            if (!_valueUniqueIds.Contains(uniqueId))
            {
                _valueUniqueIds.Add(uniqueId);
            }
        }

        public bool ContainsValueUniqueId(object value)
        {
            return _valueUniqueIds.Contains(ValueSelectionHelper.GetValueUniqueId(value));
        }

        public bool ContainsValueUniqueId(string valueUniqueId)
        {
            return _valueUniqueIds.Contains(valueUniqueId);
        }

        public void DisplayValue(object viewValue, bool resetHistory, Action<object?>? afterClose = null, object? afterCloseArgument = null)
        {
            if (resetHistory)
            {
                _displayHierarchy.LastOrDefault()?.AfterClose?.Invoke(afterCloseArgument);
                _displayHierarchy.Clear();
                _valueUniqueIds.Clear();
                if (_mainValueUniqueId != null)
                {
                    _valueUniqueIds.Add(_mainValueUniqueId);
                }
            }

            var viewModelUniqueId = ValueSelectionHelper.GetValueUniqueId(viewValue);
            if (!_valueUniqueIds.Contains(viewModelUniqueId))
            {
                _valueUniqueIds.Add(viewModelUniqueId);
            }

            var childControl = ValueSelectionHelper.CreateDisplayControl(viewValue);
            if (childControl is DrillDownBaseControl drillDownChildControl)
            {
                drillDownChildControl.DrillDownPanel = this;
            }
            var pathItem = new ViewValuePathItem(viewValue, viewModelUniqueId, childControl, afterClose);

            labelTitle.Text = pathItem.Title;
            _displayHierarchy.Add(pathItem);

            if (_displayHierarchy.Count == 1)
            {
                toolStripDropDownBack.Enabled = false;
            }
            else
            {
                toolStripDropDownBack.Enabled = true;
                toolStripDropDownBack.DropDownItems.Clear();
                for (int i = 1; i < _displayHierarchy.Count; i++)
                {
                    var pathIndex = _displayHierarchy.Count - i - 1;
                    var pathButton = new ToolStripMenuItem(_displayHierarchy[pathIndex].Title);
                    pathButton.Tag = pathIndex;
                    pathButton.Click += (sender, args) =>
                    {
                        if (sender is ToolStripMenuItem { Tag: int itemPathIndex })
                        {
                            GoBackInHistory(itemPathIndex);
                        }
                    };
                    toolStripDropDownBack.DropDownItems.Add(pathButton);
                }
            }

            if (!panelRight.Visible)
            {
                panelRight.Width = Width / 2;
            }
            panelRight.Visible = true;
            splitterRight.Visible = true;
            ShowDisplayControl(pathItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            panelRightControl.Controls.Clear();
            _displayHierarchy.ForEach(h => h.DisplayControl.Dispose());
            _displayHierarchy.Clear();
            base.Dispose(disposing);
        }

        private void GoBackInHistory(int pathIndex)
        {

        }

        private void ShowDisplayControl(ViewValuePathItem pathItem)
        {
            panelRightControl.Controls.Clear();
            pathItem.DisplayControl.Dock = DockStyle.Fill;
            panelRightControl.Controls.Add(pathItem.DisplayControl);
        }

        private void buttonCloseRight_Click(object sender, EventArgs e)
        {
            panelRight.Visible = false;
            splitterRight.Visible = false;
            panelRightControl.Controls.Clear();
            _displayHierarchy.ForEach(h => h.DisplayControl.Dispose());
            _displayHierarchy.FirstOrDefault()?.AfterClose?.Invoke(null);
            _displayHierarchy.Clear();
            _valueUniqueIds.Clear();
            if (_mainValueUniqueId != null)
            {
                _valueUniqueIds.Add(_mainValueUniqueId);
            }
        }

        private class ViewValuePathItem
        {
            public ViewValuePathItem(object viewValue, 
                string viewModelUniqueId, 
                Control displayControl, 
                Action<object?>? afterClose, 
                object? afterCloseArgument = null)
            {
                ViewValue = viewValue;
                Title = ValueSelectionHelper.GetValueTitle(viewValue);
                DisplayControl = displayControl;
                ViewModelUniqueId = viewModelUniqueId;
                AfterClose = afterClose;
                AfterCloseArgument = afterCloseArgument;
            }

            public object ViewValue { get; }

            public string Title { get; }

            public Control DisplayControl { get; }

            public string ViewModelUniqueId { get; }

            public Action<object?>? AfterClose { get; }

            public object? AfterCloseArgument { get; }
        }

    }
}
