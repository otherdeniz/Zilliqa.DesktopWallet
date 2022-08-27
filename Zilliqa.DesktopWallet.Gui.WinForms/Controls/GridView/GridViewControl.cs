using System.Collections;
using System.ComponentModel;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Core.ViewModel.Attributes;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView
{
    public partial class GridViewControl : UserControl
    {
        private Type? _itemType;
        private IList _dataSourceList;
        private Dictionary<int, DynamicColumnCategory> _columnDynamicCategories = new();
        private Dictionary<int, GridViewFormatAttribute> _columnIndexesFormatAttributes = new();

        public GridViewControl()
        {
            InitializeComponent();
            DisplayCurrenciesService.Instance.DisplayCurrenciesChanged += InstanceOnDisplayCurrenciesChanged;
        }

        public event EventHandler<RowSelectionEventArgs> RowSelected;

        [Browsable(false)]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object? SelectedRow { get; private set; }

        public void LoadData(IList dataSource, Type itemType)
        {
            _itemType = itemType;
            _dataSourceList = dataSource;
            dataGridView.DataSource = dataSource;
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

        private void OnSelectRow(int rowIndex)
        {
            SelectedRow = _dataSourceList[rowIndex];
            RowSelected?.Invoke(this, new RowSelectionEventArgs(SelectedRow));
        }

        private void ApplyVisibleDynamicColumns()
        {
            foreach (var columnDynamicCategory in _columnDynamicCategories)
            {
                if (IsDynamicColumnCategoryVisible(columnDynamicCategory.Value))
                {
                    dataGridView.Columns[columnDynamicCategory.Key].Visible = true;
                    //if (dataGridView.Columns[columnDynamicCategory.Key].Width == 0)
                    //{
                    //    dataGridView.Columns[columnDynamicCategory.Key].Width =
                    //        dataGridView.Columns[columnDynamicCategory.Key]
                    //            .GetPreferredWidth(DataGridViewAutoSizeColumnMode.DisplayedCells, true);
                    //}
                }
                else
                {
                    dataGridView.Columns[columnDynamicCategory.Key].Visible = false;
                }
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

        private void dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (_itemType == null) return;
            _columnIndexesFormatAttributes.Clear();
            foreach (var propertyInfo in _itemType.GetProperties())
            {
                if (propertyInfo.GetCustomAttributes(typeof(GridViewFormatAttribute), false).FirstOrDefault() is
                    GridViewFormatAttribute formatAttribute)
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
                if (propertyInfo.GetCustomAttributes(typeof(GridViewBackgroundAttribute), false).FirstOrDefault() is
                    GridViewBackgroundAttribute backgroundAttribute)
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

                if (propertyInfo.GetCustomAttributes(typeof(GridViewDynamicColumnAttribute), false).FirstOrDefault() is
                    GridViewDynamicColumnAttribute dynamicColumnAttribute)
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
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //TODO: add sorting features if Header clicked (RowIndex = -1)
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (_dataSourceList.Count > 0 && dataGridView.SelectedRows.Count > 0)
            {
                OnSelectRow(dataGridView.SelectedRows[0].Index);
            }
        }

        public class RowSelectionEventArgs : EventArgs
        {
            public object SelectedRow { get; }

            public RowSelectionEventArgs(object selectedRow)
            {
                SelectedRow = selectedRow;
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
    }
}
