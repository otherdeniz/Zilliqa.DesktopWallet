using System.ComponentModel;
using System.Diagnostics;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values
{
    public partial class Bech32AddressLabel : UserControl
    {
        private string? _bech32Address;

        public Bech32AddressLabel()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string? Bech32Address
        {
            get => _bech32Address;
            set
            {
                _bech32Address = value;
                SetAddressLabel();
                ApplySize();
            }
        }

        private void SetAddressLabel()
        {
            if (_bech32Address?.Length == 42)
            {
                label2.Text = _bech32Address.Substring(4, 3);
                label3.Text = _bech32Address.Substring(7, 32);
                label4.Text = _bech32Address.Substring(39);
            }
            else
            {
                label2.Text = "---";
                label3.Text = "-----------------------------------";
                label4.Text = "---";
            }
        }

        private void ApplySize()
        {
            label2.Refresh();
            label3.Left = label2.Left + label2.Width - 2;
            label3.Refresh();
            label4.Left = label3.Left + label3.Width - 2;
            label4.Refresh();
            panelAddress.Width = label4.Left + label4.Width;
            Height = label1.Height;
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            if (_bech32Address == null) return;
            buttonCopy.BackColor = Color.Green;
            buttonCopy.Refresh();
            timerButtonPressed.Enabled = true;
            Clipboard.SetText(_bech32Address);
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (_bech32Address == null) return;
            buttonBrowse.BackColor = Color.Green;
            buttonBrowse.Refresh();
            timerButtonPressed.Enabled = true;
            BlockExplorerBrowser.ShowAddress(_bech32Address);
        }

        private void timerButtonPressed_Tick(object sender, EventArgs e)
        {
            timerButtonPressed.Enabled = false;
            buttonCopy.BackColor = SystemColors.Control;
            buttonBrowse.BackColor = SystemColors.Control;
        }

        private void Bech32AddressLabel_Resize(object sender, EventArgs e)
        {
            ApplySize();
        }
    }
}
