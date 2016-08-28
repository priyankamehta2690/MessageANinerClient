using System.Windows.Forms;

namespace MessageANiner.UserControls
{
    public partial class MessageHolder : UserControl
    {
        public MessageHolder()
        {
            InitializeComponent();
        }

        public MessageHolder(string message)
        {
            InitializeComponent();
            //label1.Text = message;
            richTextBoxContent.Text = message;

            richTextBoxContent.ContentsResized += richTextBoxContent_ContentsResized;
            richTextBoxContent.ReadOnly = true;
        }

        private void richTextBoxContent_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            ((RichTextBox)sender).Height = e.NewRectangle.Height + 5;
        }
    }
}
