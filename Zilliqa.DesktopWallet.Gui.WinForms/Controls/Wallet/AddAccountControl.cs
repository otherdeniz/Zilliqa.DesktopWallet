﻿using System.ComponentModel;
using Zilliqa.DesktopWallet.Core;
using Zilliqa.DesktopWallet.Core.Services;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Wallet
{
    public partial class AddAccountControl : UserControl
    {
        public AddAccountControl()
        {
            InitializeComponent();
            panelPrivateKey.Dock = DockStyle.Fill;
            panelLedger.Dock = DockStyle.Fill;
        }

        public event EventHandler<EventArgs>? ValueChanged;

        [Browsable(false)]
        public string Title => textWalletName.Text;

        [Browsable(false)]
        public AddWalletType AddType
        {
            get
            {
                if (radioButtonNew.Checked)
                {
                    return AddWalletType.AddNew;
                }
                if (radioButtonImportPrivateKey.Checked)
                {
                    return AddWalletType.ImportPrivateKey;
                }
                if (radioButtonLedger.Checked)
                {
                    return AddWalletType.ConnectLedger;
                }
                return AddWalletType.NotSelected;
            }
        }

        [Browsable(false)]
        public string PrivateKey => textPrivateKey.Text;

        [Browsable(false)]
        public string? LedgerAddressBech32 { get; private set; }

        public bool CheckFields()
        {
            if (AddType == AddWalletType.NotSelected
                || string.IsNullOrEmpty(Title))
            {
                return false;
            }
            if (AddType == AddWalletType.ImportPrivateKey)
            {
                return !string.IsNullOrEmpty(PrivateKey);
            }
            if (AddType == AddWalletType.ConnectLedger)
            {
                return !string.IsNullOrEmpty(LedgerAddressBech32);
            }
            return true;
        }

        private void OnValueChanged()
        {
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }

        private void textWalletName_TextChanged(object sender, EventArgs e)
        {
            OnValueChanged();
        }

        private void radioButtonNew_Click(object sender, EventArgs e)
        {
            panelPrivateKey.Visible = false;
            panelLedger.Visible = false;
            OnValueChanged();
        }

        private void radioButtonImportPrivateKey_Click(object sender, EventArgs e)
        {
            panelPrivateKey.Visible = true;
            panelLedger.Visible = false;
            OnValueChanged();
        }

        private void radioButtonLedger_Click(object sender, EventArgs e)
        {
            panelPrivateKey.Visible = false;
            panelLedger.Visible = true;
            OnValueChanged();
        }

        private void textPrivateKey_TextChanged(object sender, EventArgs e)
        {
            OnValueChanged();
        }

        private void buttonGetLedgerAddress_Click(object sender, EventArgs e)
        {
            buttonGetLedgerAddress.Enabled = false;
            labelQueryLedger.Visible = true;
            labelLedgerError.Visible = false;
            textLedgerAddress.Visible = false;
            textLedgerAddress.ForeColor = Color.Blue;
            LedgerAddressBech32 = null;
            OnValueChanged();
            Task.Run(async () =>
            {
                using (var ledgerService = new LedgerWalletService())
                {
                    try
                    {
                        var bech32Address = await ledgerService.ReadAddressBech32Async();
                        LedgerAddressBech32 = bech32Address;
                        WinFormsSynchronisationContext.ExecuteSynchronized(() =>
                        {
                            textLedgerAddress.Text = bech32Address;
                            labelQueryLedger.Visible = false;
                            labelLedgerError.Visible = false;
                            textLedgerAddress.Visible = true;
                            OnValueChanged();
                            buttonGetLedgerAddress.Enabled = true;
                        });
                    }
                    catch (Exception exception)
                    {
                        WinFormsSynchronisationContext.ExecuteSynchronized(() =>
                        {
                            labelLedgerError.Text = exception.Message;
                            labelQueryLedger.Visible = false;
                            labelLedgerError.Visible = true;
                            textLedgerAddress.Visible = false;
                            OnValueChanged();
                            buttonGetLedgerAddress.Enabled = true;
                        });
                    }
                }
            });
        }

        public enum AddWalletType
        {
            NotSelected = 0,
            AddNew = 1,
            ImportPrivateKey = 2,
            ConnectLedger = 3
        }
    }
}
