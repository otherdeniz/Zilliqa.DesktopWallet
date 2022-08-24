using System.Collections;
using System.ComponentModel;
using Zilliqa.DesktopWallet.Core.ViewModel.Attributes;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView
{
    public partial class GridViewControl : UserControl
    {
        private Type? _itemType;
        private IList _dataSourceList;

        private Dictionary<int, GridViewFormatAttribute> _columnIndexesFormatAttributes =
            new Dictionary<int, GridViewFormatAttribute>();

        public GridViewControl()
        {
            InitializeComponent();
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

        private void OnSelectRow(int rowIndex)
        {
            SelectedRow = _dataSourceList[rowIndex];
            RowSelected?.Invoke(this, new RowSelectionEventArgs(SelectedRow));
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
                        column.DefaultCellStyle.Format = formatAttribute.Format;
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
                        dataGridView.Columns[propertyInfo.Name].DefaultCellStyle.BackColor = Color.FromKnownColor(backgroundAttribute.BackColor);
                    }
                    catch (Exception)
                    {
                        // skip
                    }
                }
            }
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
                if (formatAttribute.UseGreenOrRedNumbers
                    && e.Value is decimal decimalValue)
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
            }
        }
    }
}
