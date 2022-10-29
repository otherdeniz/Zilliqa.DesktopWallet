using System.Collections;
using System.ComponentModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls
{
    public partial class HighlitableBaseControl : UserControl
    {
        private bool _isSelected;
        private Color? _unselectedBackColor;

        public HighlitableBaseControl()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(null)]
        public Color? UnselectedBackColor
        {
            get => _unselectedBackColor;
            set
            {
                _unselectedBackColor = value;
                if (!IsSelected && !IsHover && value != null)
                {
                    BackColor = value.Value;
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(false)]
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                SetBackColor();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(false)]
        public bool IsHover { get; set; }

        protected virtual void ClickAction()
        {
            // to override
        }

        private void SetBackColor()
        {
            if (_isSelected)
            {
                IsHover = false;
                this.BackColor = GuiColors.SelectedBackColor;
            }
            else
            {
                var isMouseOver = ClientRectangle.Contains(PointToClient(MousePosition));
                IsHover = isMouseOver;
                BackColor = isMouseOver ? GuiColors.HoverBackColor : UnselectedBackColor ?? GuiColors.DefaultBackColor;
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
