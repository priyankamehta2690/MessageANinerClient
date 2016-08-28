using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MessageANiner.UserControls
{
    public partial class FileMessageHolder : UserControl
    {
        string title;
        string fileName;

        public FileMessageHolder()
        {
            InitializeComponent();
        }

        public FileMessageHolder(string title, string fileName)
        {
            InitializeComponent();
            label1.Text = title + "\n" + title + "sent a file";
            this.title = title;
            this.fileName = fileName;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                SaveFileDialog saveFileBox = new SaveFileDialog();
                saveFileBox.FileName = fileName;
                saveFileBox.ShowDialog();
                System.IO.File.Copy(fileName, saveFileBox.FileName);
            }
            catch (Exception)
            {
            }
        }
    }
}
