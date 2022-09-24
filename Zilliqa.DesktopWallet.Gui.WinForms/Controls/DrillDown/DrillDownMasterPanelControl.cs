using Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown
{
    public partial class DrillDownMasterPanelControl : UserControl
    {
        private readonly List<ViewValuePathItem> _displayHierarchy = new();
        private string? _mainValueUniqueId;
        private readonly HashSet<string> _valueUniqueIds = new();

        public static DrillDownMasterPanelControl? FindParentDrillDownMasterPanel(Control control)
        {
            var parentControl = control.Parent;
            while (parentControl != null)
            {
                if (parentControl is DrillDownMasterPanelControl drillDownMasterPanel)
                {
                    return drillDownMasterPanel;
                }
                parentControl = parentControl.Parent;
            }
            return null;
        }

        public static bool ControlIsInRightPanel(Control control)
        {
            var parentControl = control.Parent;
            while (parentControl != null)
            {
                if (parentControl.Tag is string stringTag 
                    && stringTag == "PanelRight")
                {
                    return true;
                }
                parentControl = parentControl.Parent;
            }
            return false;
        }

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
            return ContainsValueUniqueId(ValueSelectionHelper.GetValueUniqueId(value));
        }

        public bool ContainsValueUniqueId(string valueUniqueId)
        {
            return _valueUniqueIds.Contains(valueUniqueId);
        }

        public void CloseRightPanel()
        {
            panelRight.Visible = false;
            splitterRight.Visible = false;
            ResetRightPanel();
        }

        public void DisplayValue(object viewValue, bool resetRightPanel, Action<object?>? afterClose = null, object? afterCloseArgument = null)
        {
            if (resetRightPanel)
            {
                ResetRightPanel(afterCloseArgument);
            }

            var viewModelUniqueId = ValueSelectionHelper.GetValueUniqueId(viewValue);
            if (!_valueUniqueIds.Contains(viewModelUniqueId))
            {
                _valueUniqueIds.Add(viewModelUniqueId);
            }

            var childControl = ValueSelectionHelper.CreateDisplayControl(viewValue);
            if (childControl is DetailsBaseControl drillDownChildControl)
            {
                drillDownChildControl.DrillDownPanel = this;
            }
            var pathItem = new ViewValuePathItem(viewValue, viewModelUniqueId, childControl, afterClose, afterCloseArgument);

            labelTitle.Text = pathItem.Title;
            _displayHierarchy.Add(pathItem);

            RefreshBackButton();

            if (!panelRight.Visible)
            {
                panelRight.Width = Width / 2;
            }
            panelRight.Visible = true;
            splitterRight.Visible = true;
            ShowDisplayControl(pathItem);
        }

        private void RefreshBackButton()
        {
            if (_displayHierarchy.Count <= 1)
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
        }

        private void ResetRightPanel(object? skipAfterCloseArgument = null)
        {
            panelRightControl.Controls.Clear();
            _displayHierarchy.ForEach(h => h.DisplayControl.Dispose());
            var firstPathItem = _displayHierarchy.FirstOrDefault();
            if (firstPathItem?.AfterClose != null
                && firstPathItem.AfterCloseArgument != skipAfterCloseArgument)
            {
                firstPathItem.AfterClose(firstPathItem.AfterCloseArgument);
            }
            _displayHierarchy.Clear();
            _valueUniqueIds.Clear();
            if (_mainValueUniqueId != null)
            {
                _valueUniqueIds.Add(_mainValueUniqueId);
            }
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
            panelRightControl.Controls.Clear();
            var isFirstRemovedItem = true;
            foreach (var closePathItem in _displayHierarchy.Skip(pathIndex + 1).ToArray())
            {
                closePathItem.DisplayControl.Dispose();
                if (isFirstRemovedItem 
                    && closePathItem.AfterClose != null)
                {
                    closePathItem.AfterClose(closePathItem.AfterCloseArgument);
                }
                isFirstRemovedItem = false;
                _displayHierarchy.Remove(closePathItem);
                _valueUniqueIds.Remove(closePathItem.ViewModelUniqueId);
            }

            var pathItem = _displayHierarchy[pathIndex];
            labelTitle.Text = pathItem.Title;
            RefreshBackButton();
            panelRightControl.Controls.Add(pathItem.DisplayControl);
        }

        private void ShowDisplayControl(ViewValuePathItem pathItem)
        {
            panelRightControl.Controls.Clear();
            pathItem.DisplayControl.Dock = DockStyle.Fill;
            panelRightControl.Controls.Add(pathItem.DisplayControl);
        }

        private void buttonCloseRight_Click(object sender, EventArgs e)
        {
            CloseRightPanel();
        }

        private class ViewValuePathItem
        {
            public ViewValuePathItem(object viewValue, 
                string viewModelUniqueId, 
                Control displayControl, 
                Action<object?>? afterClose, 
                object? afterCloseArgument)
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
