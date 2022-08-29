using System.Collections;
using System.ComponentModel;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Core.ViewModel.Attributes;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView
{
    public partial class GridViewControl : DesignableUserControl
    {
        private Type? _itemType;
        private IList _dataSourceList;
        private readonly Dictionary<int, DynamicColumnCategory> _columnDynamicCategories = new();
        private readonly Dictionary<int, GridViewFormatAttribute> _columnIndexesFormatAttributes = new();
        private int? _hoveredRowIndex;

        public GridViewControl()
        {
            InitializeComponent();
        }

        public event EventHandler<RowSelectionEventArgs> RowSelected;

        public event EventHandler<SelectedItemEventArgs> SelectionChanged;

        [Browsable(false)]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object? SelectedRow { get; private set; }

        [Browsable(false)]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? SelectedRowIndex { get; private set; }

        [DefaultValue(true)]
        public bool EnableSelection { get; set; } = true;

        [DefaultValue(false)]
        public bool AutoSelectFirstRow { get; set; } = false;

        public void LoadData(IList dataSource, Type itemType)
        {
            _itemType = itemType;
            _dataSourceList = dataSource;
            dataGridView.DataSource = dataSource;
        }

        public void ClearSelection()
        {
            if (SelectedRowIndex != null)
            {
                ApplyRowBackground(SelectedRowIndex.GetValueOrDefault(), null);
            }
            _hoveredRowIndex = null;
            SelectedRowIndex = null;
            SelectedRow = null;
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

        private void OnSelectRow(int? rowIndex)
        {
            if (!EnableSelection || SelectedRowIndex == rowIndex) return;
            if (SelectedRowIndex != null)
            {
                ApplyRowBackground(SelectedRowIndex.GetValueOrDefault(), null);
            }
            if (rowIndex != null)
            {
                ApplyRowBackground(rowIndex.GetValueOrDefault(), GuiColors.SelectedBackColor);
            }

            _hoveredRowIndex = null;
            SelectedRowIndex = rowIndex;
            SelectedRow = rowIndex == null 
                ? null 
                : _dataSourceList[rowIndex.GetValueOrDefault()];
            RowSelected?.Invoke(this, new RowSelectionEventArgs(SelectedRow));
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
                cell.Style.BackColor = rowBackColor ?? cell.OwningColumn.DefaultCellStyle.BackColor;
            }
        }

        private void dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (_itemType == null) return;
            var baseType = _itemType.BaseType;
            _columnIndexesFormatAttributes.Clear();
            foreach (var propertyInfo in _itemType.GetProperties())
            {
                var parentPropertyInfo = baseType?.GetProperty(propertyInfo.Name);
                if ((propertyInfo.GetCustomAttributes(typeof(GridViewFormatAttribute), false).FirstOrDefault()
                    ?? parentPropertyInfo?.GetCustomAttributes(typeof(GridViewFormatAttribute), false).FirstOrDefault())
                        is GridViewFormatAttribute formatAttribute)
                {
                    try
                    {
                        var column = dataGridView.Columns[propertyInfo.Name];
                        if (!string.IsNullOrEmpty(formatAttribute.Format))
                        {
                            column.DefaultCellStyle.Format = formatAttribute.Format;
                        }
                        _columnIndexesFormatAttributes.Add(column.Index, formatAttribute);
                    }
                    catch (Exception)
                    {
                        // skip
                    }
                }
                if ((propertyInfo.GetCustomAttributes(typeof(GridViewBackgroundAttribute), false).FirstOrDefault()
                     ?? parentPropertyInfo?.GetCustomAttributes(typeof(GridViewBackgroundAttribute), false).FirstOrDefault())
                        is GridViewBackgroundAttribute backgroundAttribute)
                {
                    try
                    {
                        dataGridView.Columns[propertyInfo.Name].DefaultCellStyle.BackColor = backgroundAttribute.BackColor;
                    }
                    catch (Exception)
                    {
                        // skip
                    }
                }

                if ((propertyInfo.GetCustomAttributes(typeof(GridViewDynamicColumnAttribute), false).FirstOrDefault()
                     ?? parentPropertyInfo?.GetCustomAttributes(typeof(GridViewDynamicColumnAttribute), false).FirstOrDefault())
                        is GridViewDynamicColumnAttribute dynamicColumnAttribute)
                {
                    try
                    {
                        var column = dataGridView.Columns[propertyInfo.Name];
                        _columnDynamicCategories.Add(column.Index, dynamicColumnAttribute.Category);
                    }
                    catch (Exception)
                    {
                        // skip
                    }
                }
            }
            ApplyVisibleDynamicColumns();
            if (AutoSelectFirstRow && _dataSourceList.Count > 0)
            {
                OnSelectRow(0);
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_dataSourceList.Count > 0)
            {
                if (e.RowIndex > -1)
                {
                    OnSelectRow(e.RowIndex);
                }
            }
            //TODO: add sorting features if Header clicked (RowIndex = -1)
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView.ClearSelection();
            //if (_dataSourceList.Count > 0)
            //{
            //    if (dataGridView.SelectedCells.Count > 0)
            //    {
            //        OnSelectRow(dataGridView.SelectedCells[0].RowIndex);
            //    }
            //    //if (dataGridView.SelectedRows.Count > 0)
            //    //{
            //    //    OnSelectRow(dataGridView.SelectedRows[0].Index);
            //    //}
            //}
        }

        private void dataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 
                || _hoveredRowIndex == e.RowIndex) return;

            if (_hoveredRowIndex != null 
                && _hoveredRowIndex != SelectedRowIndex)
            {
                ApplyRowBackground(_hoveredRowIndex.GetValueOrDefault(), null);
            }

            if (SelectedRowIndex != e.RowIndex)
            {
                _hoveredRowIndex = e.RowIndex;
                ApplyRowBackground(e.RowIndex, GuiColors.HoverBackColor);
            }
        }

        private void dataGridView_MouseLeave(object sender, EventArgs e)
        {
            if (_hoveredRowIndex != null && _hoveredRowIndex != SelectedRowIndex)
            {
                ApplyRowBackground(_hoveredRowIndex.GetValueOrDefault(), null);
                _hoveredRowIndex = null;
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
            public SelectionItem(int rowIndex, object selectedItem, SelectionItemType selectionItemType, int? cellColumnIndex = null)
            {
                RowIndex = rowIndex;
                SelectedItem = selectedItem;
                SelectionItemType = selectionItemType;
                CellColumnIndex = cellColumnIndex;
            }
            public int RowIndex { get; }
            public object SelectedItem { get; }
            public SelectionItemType SelectionItemType { get; }
            public int? CellColumnIndex { get; }
        }

        public enum SelectionItemType
        {
            Row = 0,
            Cell = 1
        }
    }
}
