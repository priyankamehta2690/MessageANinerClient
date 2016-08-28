using System;
using System.Drawing;
using System.Windows.Forms;

namespace MessageANiner.UserControls
{
    public partial class PictureMessageHolder : UserControl
    {
        public PictureMessageHolder()
        {
            InitializeComponent();
        }
        public PictureMessageHolder(String text, Image image)
        {
            InitializeComponent();
            labelName.Text = text;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Image = image;
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
