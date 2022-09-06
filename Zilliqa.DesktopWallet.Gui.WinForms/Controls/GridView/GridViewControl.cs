using System.Collections;
using System.ComponentModel;
using System.Reflection;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Core.ViewModel.Attributes;
using Zilliqa.DesktopWallet.Core.ViewModel.DataSource;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView
{
    public partial class GridViewControl : DesignableUserControl
    {
        private Type? _itemType;
        private IList? _dataSourceList;
        private IPageableDataSource? _dataSourcePageable;
        private readonly Dictionary<int, DynamicColumnCategory> _columnDynamicCategories = new();
        private readonly Dictionary<int, GridViewFormatAttribute> _columnIndexesFormatAttributes = new();
        private readonly Dictionary<int, PropertyInfo> _selectableColumns = new();
        private CellIdentity? _hoverCell;
        private CellIdentity? _selectedCell;

        public GridViewControl()
        {
            InitializeComponent();
            labelLoading.Visible = true;
            dataGridView.Visible = false;
            toolStripPaging.Visible = false;
        }

        public event EventHandler<SelectedItemEventArgs>? SelectionChanged;

        public event EventHandler<IsItemSelectableEventArgs>? IsItemSelectable;

        [Browsable(false)]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SelectionItem? SelectedItem { get; private set; }

        [DefaultValue(true)]
        public bool EnableSelection { get; set; } = true;

        [DefaultValue(false)]
        public bool AutoSelectFirstRow { get; set; } = false;

        [DefaultValue(false)]
        public bool DisplayDynamicColumns { get; set; } = false;

        public void LoadData(IPageableDataSource dataSource, Type itemType)
        {
            _dataSourcePageable = dataSource;
            _dataSourceList = null;
            _itemType = itemType;
            _columnDynamicCategories.Clear();
            _columnIndexesFormatAttributes.Clear();
            _selectableColumns.Clear();
            ClearSelection();
            dataGridView.DataSource = GetEmptyGenericList(itemType);
            DataBindingInitialise();
            _dataSourcePageable.ExecuteAfterLoadCompleted(s =>
            {
                if (_dataSourcePageable == s)
                {
                    _dataSourceList = s.GetPage(1);
                    dataGridView.DataSource = _dataSourceList;
                    DataBindingCompleted();
                    labelLoading.Visible = false;
                    dataGridView.Visible = true;
                    RefreshPagingButtons();
                }
            }, true);
        }

        public void LoadData(IList dataSource, Type itemType)
        {
            _dataSourcePageable = null;
            _itemType = itemType;
            _dataSourceList = dataSource;
            _columnDynamicCategories.Clear();
            _columnIndexesFormatAttributes.Clear();
            _selectableColumns.Clear();
            ClearSelection();
            dataGridView.DataSource = GetEmptyGenericList(itemType);
            DataBindingInitialise();
            dataGridView.DataSource = _dataSourceList;
            DataBindingCompleted();
            labelLoading.Visible = false;
            dataGridView.Visible = true;
            RefreshPagingButtons();
        }

        public void ClearSelection()
        {
            _selectedCell?.UnSelect();
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
            DisplayCurrenciesService.Instance.DisplayCurrenciesChanged -= ServiceOnDisplayCurrenciesChanged;
            base.Dispose(disposing);
        }

        private void LoadDataPage(int pageNumber)
        {
            if (_dataSourcePageable != null)
            {
                var dataSource = _dataSourcePageable.GetPage(pageNumber);
                _dataSourceList = dataSource;
                dataGridView.DataSource = _dataSourceList;
                RefreshPagingButtons();
            }
        }

        private void DataBindingInitialise()
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

                    if (ValueSelectionHelper.IsSelectableGridCell(propertyInfo.PropertyType))
                    {
                        column.HeaderCell.Style.ForeColor = GuiColors.LinkForeColor;
                        column.HeaderCell.Style.Font = new Font(dataGridView.DefaultCellStyle.Font, FontStyle.Underline);
                        _selectableColumns.Add(column.Index, propertyInfo);
                    }
                }
            }
            if (dataGridView.Columns.Count > 0)
            {
                dataGridView.Columns[0].Frozen = true;
            }
            ApplyVisibleDynamicColumns();
        }

        private void DataBindingCompleted()
        {
            if (AutoSelectFirstRow 
                && _dataSourceList?.Count > 0
                && SelectedItem != null)
            {
                OnSelectCell(CellIdentity.Create(this, 0, null));
            }
        }

        private void RefreshPagingButtons()
        {
            if (_dataSourcePageable?.PageCount > 1)
            {
                toolStripPaging.Visible = true;
                labelPageNumber.Text = $"Page {_dataSourcePageable.CurrentPageNumber} of {_dataSourcePageable.PageCount}";
                var firstPageRecord = (_dataSourcePageable.CurrentPageNumber-1) * _dataSourcePageable.PageSize + 1;
                var lastPageRecord = firstPageRecord + _dataSourcePageable.PageSize > _dataSourcePageable.RecordCount
                    ? _dataSourcePageable.RecordCount
                    : firstPageRecord + _dataSourcePageable.PageSize - 1;
                labelRecordRange.Text = $"# {firstPageRecord:#,##0} - {lastPageRecord:#,##0}";
                buttonPageFirst.Enabled = _dataSourcePageable.CurrentPageNumber > 1;
                buttonPageBack.Enabled = _dataSourcePageable.CurrentPageNumber > 1;
                buttonPageNext.Enabled = _dataSourcePageable.CurrentPageNumber < _dataSourcePageable.PageCount;
                buttonPageLast.Enabled = _dataSourcePageable.CurrentPageNumber < _dataSourcePageable.PageCount;
            }
            else
            {
                toolStripPaging.Visible = false;
            }
        }

        private bool CheckIsItemSelectable(CellIdentity cellIdentity)
        {
            var selectionItem = GetCellIdentitySelectionItem(cellIdentity);
            if (selectionItem != null)
            {
                var eventArgs = new IsItemSelectableEventArgs(selectionItem);
                IsItemSelectable?.Invoke(this, eventArgs);
                return eventArgs.IsSelectable;
            }

            return false;
        }

        private void OnSelectCell(CellIdentity? selectCell)
        {
            if (!EnableSelection 
                || selectCell?.Equals(_selectedCell) == true) return;

            if (selectCell != null
                && !CheckIsItemSelectable(selectCell))
            {
                _hoverCell = selectCell;
                selectCell.UnavailableMark();
                return;
            }

            if (_selectedCell != null)
            {
                _selectedCell.UnSelect();
                _selectedCell = null;
            }

            _hoverCell = null;
            if (selectCell != null)
            {
                var selectionItem = GetCellIdentitySelectionItem(selectCell);
                SelectedItem = selectionItem;
                _selectedCell = selectCell;
                selectCell.Select();
            }
            else
            {
                SelectedItem = null;
                _selectedCell = null;
            }
            SelectionChanged?.Invoke(this, new SelectedItemEventArgs(SelectedItem));
        }

        private SelectionItem? GetCellIdentitySelectionItem(CellIdentity cellIdentity)
        {
            var rowObject = _dataSourceList?[cellIdentity.RowIndex];
            if (rowObject != null)
            {
                if (cellIdentity.ColumnIndex == null)
                {
                    return new SelectionItem(cellIdentity.RowIndex, rowObject, SelectionItemType.Row);
                }
                if (_selectableColumns.TryGetValue(cellIdentity.ColumnIndex.Value, out var cellPropertyInfo))
                {
                    var cellObject = cellPropertyInfo.GetValue(rowObject);
                    return new SelectionItem(cellIdentity.RowIndex, cellObject, SelectionItemType.Cell);
                }
            }

            return null;
        }

        private IList GetEmptyGenericList(Type itemType)
        {
            return (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(itemType))!;
        }

        private void ApplyVisibleDynamicColumns()
        {
            foreach (var columnDynamicCategory in _columnDynamicCategories)
            {
                dataGridView.Columns[columnDynamicCategory.Key].Visible =
                    DisplayDynamicColumns &&
                    IsDynamicColumnCategoryVisible(columnDynamicCategory.Value);
            }
        }

        private bool IsDynamicColumnCategoryVisible(DynamicColumnCategory category)
        {
            var currentDisplay = DisplayCurrenciesService.Instance.CurrentDisplayed;
            switch (category)
            {
                case DynamicColumnCategory.CurrencyUsd:
                    return true;
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

        private void ServiceOnDisplayCurrenciesChanged(object? sender, EventArgs e)
        {
            ApplyVisibleDynamicColumns();
        }

        private void GridViewControl_Load(object sender, EventArgs e)
        {
            if (!InDesignMode())
            {
                DisplayCurrenciesService.Instance.DisplayCurrenciesChanged += ServiceOnDisplayCurrenciesChanged;
            }
        }

        private void ApplyRowBackground(int rowIndex, Color? rowBackColor)
        {
            try
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
            catch (Exception)
            {
                // ignore
            }
        }

        private void ApplyCellBackground(int rowIndex, int columnIndex, Color? rowBackColor)
        {
            try
            {
                var cell = dataGridView.Rows[rowIndex].Cells[columnIndex];
                cell.Style.BackColor = rowBackColor ?? cell.OwningColumn.DefaultCellStyle.BackColor;
            }
            catch (Exception)
            {
                // ignore
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_dataSourceList?.Count > 0 
                && e.RowIndex > -1)
            {
                OnSelectCell(CellIdentity.Create(this, e.RowIndex, e.ColumnIndex));
            }
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
            if (CheckIsItemSelectable(mouseHoverCellIdentiy))
            {
                _hoverCell.Hover();
            }
            else
            {
                _hoverCell.UnavailableHover();
            }
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

        private void buttonPageFirst_Click(object sender, EventArgs e)
        {
            LoadDataPage(1);
        }

        private void buttonPageBack_Click(object sender, EventArgs e)
        {
            if (_dataSourcePageable?.CurrentPageNumber > 1)
            {
                LoadDataPage(_dataSourcePageable.CurrentPageNumber - 1);
            }
        }

        private void buttonPageNext_Click(object sender, EventArgs e)
        {
            if (_dataSourcePageable != null)
            {
                LoadDataPage(_dataSourcePageable.CurrentPageNumber + 1);
            }
        }

        private void buttonPageLast_Click(object sender, EventArgs e)
        {
            if (_dataSourcePageable != null)
            {
                LoadDataPage(_dataSourcePageable.PageCount);
            }
        }

        public class IsItemSelectableEventArgs : SelectedItemEventArgs
        {
            public IsItemSelectableEventArgs(SelectionItem selectionItem)
                :base (selectionItem)
            {
            }
            public bool IsSelectable { get; set; } = true;
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
            public SelectionItem(int rowIndex, object? value, SelectionItemType selectionItemType, int? cellColumnIndex = null)
            {
                RowIndex = rowIndex;
                Value = value;
                SelectionItemType = selectionItemType;
                CellColumnIndex = cellColumnIndex;
            }
            public int RowIndex { get; }
            public object? Value { get; }
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
                else if (_control.SelectedItem?.RowIndex == RowIndex
                         && (_control.SelectedItem.CellColumnIndex == null || _control.SelectedItem.CellColumnIndex == ColumnIndex))
                {
                    _control.ApplyCellBackground(RowIndex, ColumnIndex.Value, GuiColors.SelectedBackColor);
                }
                else
                {
                    _control.ApplyCellBackground(RowIndex, ColumnIndex.Value, null);
                }
            }

            public void UnavailableHover()
            {
                if (ColumnIndex == null)
                {
                    _control.ApplyRowBackground(RowIndex, GuiColors.UnavailableHoverBackColor);
                }
                else
                {
                    _control.ApplyCellBackground(RowIndex, ColumnIndex.Value, GuiColors.UnavailableHoverBackColor);
                }
            }

            public void UnavailableMark()
            {
                if (ColumnIndex == null)
                {
                    _control.ApplyRowBackground(RowIndex, GuiColors.UnavailableMarkBackColor);
                }
                else
                {
                    _control.ApplyCellBackground(RowIndex, ColumnIndex.Value, GuiColors.UnavailableMarkBackColor);
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
