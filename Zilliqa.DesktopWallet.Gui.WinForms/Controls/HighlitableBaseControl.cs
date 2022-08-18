﻿using System.Collections;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls
{
    public partial class HighlitableBaseControl : UserControl
    {
        private static readonly Color BackColorInactive = Color.White;
        private static readonly Color BackColorHighligth = Color.LightGray;
        private static readonly Color BackColorSelected = Color.DarkSeaGreen;

        private bool _isSelected;

        public HighlitableBaseControl()
        {
            InitializeComponent();
        }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                SetBackColor();
            }
        }

        protected virtual void ClickAction()
        {
            // to override
        }

        private void SetBackColor()
        {
            if (_isSelected)
            {
                this.BackColor = BackColorSelected;
            }
            else
            {
                var isMouseOver = ClientRectangle.Contains(PointToClient(MousePosition));
                BackColor = isMouseOver ? BackColorHighligth : BackColorInactive;
            }
        }

        private void AddEventHandlers(IList controls)
        {
            foreach (var control in controls.OfType<Control>())
            {
                control.MouseEnter += Control_MouseMovement;
                control.MouseLeave += Control_MouseMovement;
                control.Click += Control_Click;
                AddEventHandlers(control.Controls);
            }
        }

        private void HighlitableBaseControl_Load(object sender, EventArgs e)
        {
            AddEventHandlers(Controls);
        }

        private void Control_MouseMovement(object? sender, EventArgs e)
        {
            SetBackColor();
        }

        private void Control_Click(object? sender, EventArgs e)
        {
            ClickAction();
        }
    }
}