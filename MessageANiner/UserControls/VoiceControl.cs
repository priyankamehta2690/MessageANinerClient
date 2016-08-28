using System.Drawing;
using System.Windows.Forms;

namespace MessageANiner.UserControls
{
    public partial class VoiceControl : System.Windows.Forms.Button
    {
        public VoiceControl() : base()
        {
            InitializeComponent();
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Image = Properties.Resources.GoogleVoiceicon;
            this.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
