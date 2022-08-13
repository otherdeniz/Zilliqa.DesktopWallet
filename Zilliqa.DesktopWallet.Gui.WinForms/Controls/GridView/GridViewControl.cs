using System.Collections;
using System.ComponentModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView
{
    public partial class GridViewControl : UserControl
    {
        private Type? _itemType;
        private IList _dataSourceList;

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
            if (dataSource.Count > 0)
            {
                OnSelectRow(0);
            }
        }

        private void OnSelectRow(int rowIndex)
        {
            SelectedRow = _dataSourceList[rowIndex];
            RowSelected?.Invoke(this, new RowSelectionEventArgs(SelectedRow));
        }

        private void dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (_itemType == null) return;
            foreach (var propertyInfo in _itemType.GetProperties())
            {
                if (propertyInfo.GetCustomAttributes(typeof(GridViewFormatAttribute), false).FirstOrDefault() is
                    GridViewFormatAttribute formatAttribute)
                {
                    dataGridView.Columns[propertyInfo.Name].DefaultCellStyle.Format = formatAttribute.Format;
                }
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //TODO: add sorting features if Header clicked (RowIndex = -1)
            if (_dataSourceList != null && e.RowIndex > -1)
            {
                OnSelectRow(e.RowIndex);
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
    }
}
