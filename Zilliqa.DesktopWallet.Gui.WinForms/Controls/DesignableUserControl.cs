using System.ComponentModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls
{
    public partial class DesignableUserControl : UserControl
    {
        public DesignableUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Checks if any parent Control is in DesignMode.
        /// By default the DesignMode Property only returns true if the current Control is in DesignMode,
        /// but if a parent Control is in DesignMode, it will return the incorrect value and cause the Control
        /// to execute runtimne code while still in DesignMode
        /// This Method is not available in Constructor, please call it in the Load() Event of the control.
        /// </summary>
        protected bool InDesignMode()
        {
            var inDesignMode = DesignMode;
            try
            {
                Control control = this;
                while (!inDesignMode && control != null)
                {
                    var siteProperty = control.GetType().GetProperty("Site");
                    if (siteProperty?.GetGetMethod()?.Invoke(control, Array.Empty<object>()) is ISite site
                        && site.DesignMode)
                    {
                        inDesignMode = true;
                    }
                    control = control.Parent;
                }
            }
            catch (Exception)
            {
                // ignore
            }
            return inDesignMode;
        }
    }
}
