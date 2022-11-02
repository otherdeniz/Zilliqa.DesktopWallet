using System.ComponentModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Notification
{
    public partial class NotificationBaseControl : HighlitableBaseControl
    {
        public NotificationBaseControl()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime? CreatedTimestamp { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int DisplayTicks { get; set; }

        public void RefreshTimeInfo()
        {
            if (CreatedTimestamp != null)
            {
                var diffTime = DateTime.UtcNow - CreatedTimestamp.Value;
                string timeAgoText;
                if (diffTime.TotalDays > 1)
                {
                    timeAgoText = $"{diffTime.TotalDays:0.0} days";
                }
                else if (diffTime.TotalHours > 1)
                {
                    timeAgoText = $"{diffTime.TotalHours:0.0} hours";
                }
                else if (diffTime.TotalMinutes > 1)
                {
                    timeAgoText = $"{diffTime.TotalMinutes:0.0} minutes";
                }
                else
                {
                    timeAgoText = $"{diffTime.TotalSeconds:0} seconds";
                }
                labelTimeInfo.Text = $"{CreatedTimestamp.Value:g} - {timeAgoText} ago";
            }
        }
    }
}
