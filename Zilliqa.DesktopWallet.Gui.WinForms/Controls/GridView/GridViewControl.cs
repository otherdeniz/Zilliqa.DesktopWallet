using System.Collections;
using System.ComponentModel;
using System.Reflection;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Core.ViewModel.Attributes;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView
{
    public partial class GridViewControl : DesignableUserControl
    {
        private Type? _itemType;
        private IList _dataSourceList;
        private readonly Dictionary<int, DynamicColumnCategory> _columnDynamicCategories = new();
        private readonly Dictionary<int, GridViewFormatAttribute> _columnIndexesFormatAttributes = new();
        private readonly Dictionary<int, PropertyInfo> _selectableColumns = new();
        //private int? _hoveredRowIndex;
        private CellIdentity? _hoverCell;
        private CellIdentity? _selectedCell;

        public GridViewControl()
        {
            InitializeComponent();
        }

        //public event EventHandler<RowSelectionEventArgs> RowSelected;

        public event EventHandler<SelectedItemEventArgs> SelectionChanged;

        [Browsable(false)]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SelectionItem? SelectedItem { get; private set; }

        [DefaultValue(true)]
        public bool EnableSelection { get; set; } = true;

        [DefaultValue(false)]
        public bool AutoSelectFirstRow { get; set; } = false;

        public void LoadData(IList dataSource, Type itemType)
        {
            _itemType = itemType;
            _dataSourceList = dataSource;
            _columnDynamicCategories.Clear();
            _columnIndexesFormatAttributes.Clear();
            _selectableColumns.Clear();
            dataGridView.DataSource = dataSource;
        }

        public void ClearSelection()
        {
            if (_selectedCell != null)
            {
                ApplyRowBackground(_selectedCell.RowIndex, null);
            }
            _hoverCell = null;
            _selectedCell = null;
            SelectedItem = null;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            DisplayCurrenciesService.Instance.DisplayCurrenciesChanged -= InstanceOnDisplayCurrenciesChanged;
            base.Dispose(disposing);
        }

        private void OnSelectCell(CellIdentity? selectCell)
        {
            if (!EnableSelection 
                || selectCell?.Equals(_selectedCell) == true) return;

            if (_selectedCell != null)
            {
                _selectedCell.UnSelect();
                _selectedCell = null;
            }

            _hoverCell = null;
            if (selectCell != null)
            {
                var rowObject = _dataSourceList[selectCell.RowIndex];
                if (rowObject == null) return;
                if (selectCell.ColumnIndex == null)
                {
                    SelectedItem = new SelectionItem(selectCell.RowIndex, rowObject, SelectionItemType.Row);
                }
                else if (_selectableColumns.TryGetValue(selectCell.ColumnIndex.Value, out var cellPropertyInfo))
                {
                    var cellObject = cellPropertyInfo.GetValue(rowObject);
                    SelectedItem = new SelectionItem(selectCell.RowIndex, cellObject, SelectionItemType.Cell);
                }
                selectCell.Select();
            }
            else
            {
                SelectedItem = null;
            }
            _selectedCell = selectCell;
            SelectionChanged?.Invoke(this, new SelectedItemEventArgs(SelectedItem));
        }

        private void ApplyVisibleDynamicColumns()
        {
            foreach (var columnDynamicCategory in _columnDynamicCategories)
            {
                dataGridView.Columns[columnDynamicCategory.Key].Visible =
                    IsDynamicColumnCategoryVisible(columnDynamicCategory.Value);
            }
        }

        private bool IsDynamicColumnCategoryVisible(DynamicColumnCategory category)
        {
            var currentDisplay = DisplayCurrenciesService.Instance.CurrentDisplayed;
            switch (category)
            {
                case DynamicColumnCategory.CurrencyChf:
                    return currentDisplay.DisplayChf;
                case DynamicColumnCategory.CurrencyEur:
                    return currentDisplay.DisplayEur;
                case DynamicColumnCategory.CurrencyGbp:
                    return currentDisplay.DisplayGbp;
                case DynamicColumnCategory.CurrencyBtc:
                    return currentDisplay.DisplayBtc;
                case DynamicColumnCategory.CurrencyEth:
                    return currentDisplay.DisplayEth;
                case DynamicColumnCategory.CurrencyLtc:
                    return currentDisplay.DisplayLtc;
            }
            return false;
        }

        private void InstanceOnDisplayCurrenciesChanged(object? sender, EventArgs e)
        {
            ApplyVisibleDynamicColumns();
        }

        private void GridViewControl_Load(object sender, EventArgs e)
        {
            if (!InDesignMode())
            {
                DisplayCurrenciesService.Instance.DisplayCurrenciesChanged += InstanceOnDisplayCurrenciesChanged;
            }
        }

        private void ApplyRowBackground(int rowIndex, Color? rowBackColor)
        {
            var row = dataGridView.Rows[rowIndex];
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (_selectedCell != null 
                    && _selectedCell.RowIndex == rowIndex 
                    && _selectedCell.ColumnIndex == cell.ColumnIndex)
                {
                    // this cell is selected and will not be back-color changed
                }
                else
                {
                    cell.Style.BackColor = rowBackColor ?? cell.OwningColumn.DefaultCellStyle.BackColor;
                }
            }
        }

        private void ApplyCellBackground(int rowIndex, int columnIndex, Color? rowBackColor)
        {
            var cell = dataGridView.Rows[rowIndex].Cells[columnIndex];
            cell.Style.BackColor = rowBackColor ?? cell.OwningColumn.DefaultCellStyle.BackColor;
        }

        private void dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (_itemType == null) return;
            var baseType = _itemType.BaseType;
            _columnIndexesFormatAttributes.Clear();
            _columnDynamicCategories.Clear();
            _selectableColumns.Clear();
            foreach (var propertyInfo in _itemType.GetProperties())
            {
                var column = dataGridView.Columns[propertyInfo.Name];
                if (column != null)
                {
                    var parentPropertyInfo = baseType?.GetProperty(propertyInfo.Name);
                    if ((propertyInfo.GetCustomAttributes(typeof(GridViewFormatAttribute), false).FirstOrDefault()
                         ?? parentPropertyInfo?.GetCustomAttributes(typeof(GridViewFormatAttribute), false).FirstOrDefault())
                        is GridViewFormatAttribute formatAttribute)
                    {
                        if (!string.IsNullOrEmpty(formatAttribute.Format))
                        {
                            column.DefaultCellStyle.Format = formatAttribute.Format;
                        }
                        _columnIndexesFormatAttributes.Add(column.Index, formatAttribute);
                    }
                    if ((propertyInfo.GetCustomAttributes(typeof(GridViewBackgroundAttribute), false).FirstOrDefault()
                         ?? parentPropertyInfo?.GetCustomAttributes(typeof(GridViewBackgroundAttribute), false).FirstOrDefault())
                        is GridViewBackgroundAttribute backgroundAttribute)
                    {
                        column.DefaultCellStyle.BackColor = backgroundAttribute.BackColor;
                    }

                    if ((propertyInfo.GetCustomAttributes(typeof(GridViewDynamicColumnAttribute), false).FirstOrDefault()
                         ?? parentPropertyInfo?.GetCustomAttributes(typeof(GridViewDynamicColumnAttribute), false).FirstOrDefault())
                        is GridViewDynamicColumnAttribute dynamicColumnAttribute)
                    {
                        _columnDynamicCategories.Add(column.Index, dynamicColumnAttribute.Category);
                    }

                    if (DrillDownControlFactory.IsSelectableCell(propertyInfo.PropertyType))
                    {
                        _selectableColumns.Add(column.Index, propertyInfo);
                    }
                }
            }
            ApplyVisibleDynamicColumns();
            if (AutoSelectFirstRow && _dataSourceList.Count > 0)
            {
                OnSelectCell(CellIdentity.Create(this, 0, null));
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_dataSourceList.Count > 0)
            {
                if (e.RowIndex > -1)
                {
                    OnSelectCell(CellIdentity.Create(this, e.RowIndex, e.ColumnIndex));
                }
            }
            //TODO: add sorting features if Header clicked (RowIndex = -1)
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView.ClearSelection();
        }

        private void dataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return; // is Header

            var mouseHoverCellIdentiy = CellIdentity.Create(this, e.RowIndex, e.ColumnIndex);

            if (mouseHoverCellIdentiy.Equals(_hoverCell)) return; // already hovered
            if (_hoverCell != null)
            {
                _hoverCell.UnHover();
                _hoverCell = null;
            }

            if (mouseHoverCellIdentiy.Equals(_selectedCell)) return; // already selected

            _hoverCell = mouseHoverCellIdentiy;
            _hoverCell.Hover();
        }

        private void dataGridView_MouseLeave(object sender, EventArgs e)
        {
            if (_hoverCell != null)
            {
                _hoverCell.UnHover();
                _hoverCell = null;
            }
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (_columnIndexesFormatAttributes.TryGetValue(e.ColumnIndex, out var formatAttribute))
            {
                if (formatAttribute.UseGreenOrRedNumbers)
                {
                    if (e.Value is decimal decimalValue)
                    {
                        if (decimalValue == 0)
                        {
                            e.CellStyle.ForeColor = Color.Black;
                        }
                        else if (decimalValue > 0)
                        {
                            e.CellStyle.ForeColor = Color.ForestGreen;
                        }
                        else
                        {
                            e.CellStyle.ForeColor = Color.Red;
                        }
                    }
                    else if (e.Value is ValueNumberDisplay numberDisplay)
                    {
                        if (numberDisplay.BaseNumber == 0)
                        {
                            e.CellStyle.ForeColor = Color.Black;
                        }
                        else if (numberDisplay.BaseNumber > 0)
                        {
                            e.CellStyle.ForeColor = Color.ForestGreen;
                        }
                        else
                        {
                            e.CellStyle.ForeColor = Color.Red;
                        }
                    }
                }
            }
        }

        [Obsolete("SelectedItemEventArgs is the new")]
        public class RowSelectionEventArgs : EventArgs
        {
            public object? SelectedRow { get; }

            public RowSelectionEventArgs(object? selectedRow)
            {
                SelectedRow = selectedRow;
            }
        }

        public class SelectedItemEventArgs : EventArgs
        {
            public SelectedItemEventArgs(SelectionItem? selectedItem)
            {
                SelectedItem = selectedItem;
            }
            public SelectionItem? SelectedItem { get; }
        }

        public class SelectionItem
        {
            public SelectionItem(int rowIndex, object? selectedItem, SelectionItemType selectionItemType, int? cellColumnIndex = null)
            {
                RowIndex = rowIndex;
                SelectedItem = selectedItem;
                SelectionItemType = selectionItemType;
                CellColumnIndex = cellColumnIndex;
            }
            public int RowIndex { get; }
            public object? SelectedItem { get; }
            public SelectionItemType SelectionItemType { get; }
            public int? CellColumnIndex { get; }
        }

        public enum SelectionItemType
        {
            Row = 0,
            Cell = 1
        }

        private sealed class CellIdentity : IEquatable<CellIdentity>
        {
            private readonly GridViewControl _control;

            public static CellIdentity Create(GridViewControl control, int rowIndex, int? columnIndex)
            {
                if (columnIndex != null 
                    && control._selectableColumns.ContainsKey(columnIndex.Value))
                {
                    return new CellIdentity(control)
                    {
                        RowIndex = rowIndex, 
                        ColumnIndex = columnIndex
                    };
                }

                return new CellIdentity(control)
                {
                    RowIndex = rowIndex,
                    ColumnIndex = null
                };
            }

            private CellIdentity(GridViewControl control)
            {
                _control = control;
            }

            public int RowIndex { get; private init; }

            public int? ColumnIndex { get; private init; }

            public bool Equals(CellIdentity? cell)
            {
                if (cell == null)
                {
                    return false;
                }
                return cell.RowIndex == RowIndex
                       && cell.ColumnIndex == ColumnIndex;
            }

            public void Hover()
            {
                if (ColumnIndex == null)
                {
                    _control.ApplyRowBackground(RowIndex, GuiColors.HoverBackColor);
                }
                else
                {
                    _control.ApplyCellBackground(RowIndex, ColumnIndex.Value, GuiColors.HoverBackColor);
                }
            }

            public void UnHover()
            {
                if (ColumnIndex == null)
                {
                    _control.ApplyRowBackground(RowIndex, null);
                }
                else if (_control.SelectedItem?.RowIndex == RowIndex)
                {
                    _control.ApplyCellBackground(RowIndex, ColumnIndex.Value, GuiColors.SelectedBackColor);
                }
                else
                {
                    _control.ApplyCellBackground(RowIndex, ColumnIndex.Value, null);
                }
            }

            public void Select()
            {
                if (ColumnIndex == null)
                {
                    _control.ApplyRowBackground(RowIndex, GuiColors.SelectedBackColor);
                }
                else
                {
                    _control.ApplyCellBackground(RowIndex, ColumnIndex.Value, GuiColors.SelectedBackColor);
                }
            }

            public void UnSelect()
            {
                if (ColumnIndex == null)
                {
                    _control.ApplyRowBackground(RowIndex, null);
                }
                else
                {
                    _control.ApplyCellBackground(RowIndex, ColumnIndex.Value, null);
                }
            }
        }
    }
}
