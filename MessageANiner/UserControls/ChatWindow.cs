using SocketHandler;
using System;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace MessageANiner.UserControls
{
    public partial class ChatWindow : UserControl
    {
        private SocketClient myClient = null;
        SpeechSynthesizer synthesizer = null;
        long myUID;
        public long friendUID;
        string friendName;
        private Timer tmrTypingNotification = new Timer() { Interval = 500 };
        PictureBox pb = new PictureBox();

        public ChatWindow()
        {
            InitializeComponent();
        }

        public ChatWindow(SocketClient client, long myUID, long friendsUID, string friendName)
        {
            InitializeComponent();
            this.myUID = myUID;
            friendUID = friendsUID;
            this.friendName = friendName;
            myClient = client;
            label1.Text = friendName;
            synthesizer = new SpeechSynthesizer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == string.Empty)
                return;
            string message = richTextBox1.Text;
            messageSpecs.TextMessage textMessage = new messageSpecs.TextMessage();
            textMessage.sender = myUID.ToString();
            textMessage.receiver = friendUID.ToString();
            textMessage.TextToSend = message;
            myClient.Send(textMessage.getMessageString());

            MessageHolder MH = new MessageHolder("You : " + message);
            chatMessageArea.RowCount += 1;
            chatMessageArea.Controls.Add(MH, 1, chatMessageArea.RowCount - 2);
            chatMessageArea.AutoScrollPosition = new Point(0, chatMessageArea.VerticalScroll.Maximum);
            richTextBox1.Clear();
        }

        public void showReceivedMessage(string message)
        {

            switch (message.Substring(0, 5))
            {
                case messageSpecs.UserTyping.UserTypingMessageType:
                    handleTypingNotification(message);
                    break;
                case messageSpecs.TextMessage.TextMessageType:
                    handleTextMessage(message);
                    break;
                case messageSpecs.PictureMessage.PictureMessageType:
                    handlePictureMessage(message);
                    break;
                case messageSpecs.FileMessage.FileMessageType:
                    handleFileMessage(message);
                    break;
            }

        }

        private void handleTextMessage(string message)
        {
            messageSpecs.TextMessage textMessage = new messageSpecs.TextMessage(message);
            MessageHolder MH = new MessageHolder(textMessage.sender + " : " + textMessage.TextToSend);
            chatMessageArea.RowCount += 1;
            chatMessageArea.Controls.Add(MH, 0, chatMessageArea.RowCount - 2);
            chatMessageArea.AutoScrollPosition = new Point(0, chatMessageArea.VerticalScroll.Maximum);
        }

        private void handlePictureMessage(string message)
        {
            messageSpecs.PictureMessage pictureMessage = new messageSpecs.PictureMessage(message);
            String text = pictureMessage.sender + ":";
            PictureMessageHolder PMH = new PictureMessageHolder(text, pictureMessage.PictureMsg);
            chatMessageArea.RowCount += 1;
            chatMessageArea.Controls.Add(PMH, 0, chatMessageArea.RowCount - 2);
            chatMessageArea.AutoScrollPosition = new Point(0, chatMessageArea.VerticalScroll.Maximum);
        }
        private void handleFileMessage(string message)
        {
            messageSpecs.FileMessage fileMessage = new messageSpecs.FileMessage(message);
            
            String text = fileMessage.sender + ":";

            FileMessageHolder FMH = new FileMessageHolder(text,fileMessage.FileName);
            chatMessageArea.RowCount += 1;
            chatMessageArea.Controls.Add(FMH, 0, chatMessageArea.RowCount - 2);
            chatMessageArea.AutoScrollPosition = new Point(0, chatMessageArea.VerticalScroll.Maximum);
        }
        private void handleTypingNotification(string message)
        {
            messageSpecs.UserTyping userTypingMessage = new messageSpecs.UserTyping(message);
            tmrTypingNotification.Tick += new EventHandler(typingHandler);
            tmrTypingNotification.Start();
            labelNotificationTyping.Text = userTypingMessage.sender + " is typing...";
            labelNotificationTyping.Visible = true;
        }

        private void typingHandler(object sender, EventArgs e)
        {
            tmrTypingNotification.Stop();
            labelNotificationTyping.Visible = false;
            labelNotificationTyping.Text = string.Empty;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(richTextBox1.Text))
            {
                messageSpecs.UserTyping userTyping = new messageSpecs.UserTyping();
                userTyping.sender = myUID.ToString();
                userTyping.receiver = friendUID.ToString();
                myClient.Send(userTyping.getMessageString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (of.ShowDialog() == DialogResult.OK)
            {

                Image loadedImage = Image.FromFile(of.FileName);
                pb.Image = loadedImage;

                messageSpecs.PictureMessage pictureMessage = new messageSpecs.PictureMessage();
                pictureMessage.sender = myUID.ToString();
                pictureMessage.receiver = friendUID.ToString();
                pictureMessage.PictureMsg = pb.Image;
                myClient.Send(pictureMessage.getMessageString());

                PictureMessageHolder PMH = new PictureMessageHolder("You : ", pictureMessage.PictureMsg);
                chatMessageArea.RowCount += 1;
                chatMessageArea.Controls.Add(PMH, 1, chatMessageArea.RowCount - 2);
                chatMessageArea.AutoScrollPosition = new Point(0, chatMessageArea.VerticalScroll.Maximum);
            }
        }

        private void voiceControl_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(synthesizer.ToString()))
                    synthesizer.Dispose();
                int RowCount = chatMessageArea.RowCount - 1;

                if (!String.IsNullOrEmpty
                    (chatMessageArea.Controls.OfType<MessageHolder>().Last().richTextBoxContent.Text))
                {
                    synthesizer = new SpeechSynthesizer();
                    synthesizer.SpeakAsync(chatMessageArea.Controls.OfType<MessageHolder>().Last().richTextBoxContent.Text.Split(':').Last());
                }
            }
            catch (Exception)
            {
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();

            if (of.ShowDialog() == DialogResult.OK)
            {
                messageSpecs.FileMessage file = new messageSpecs.FileMessage();
                of.Filter = "Text Files (*.txt;*.doc;*.docx)|*.TXT;*.DOC;*.DOCX";
                file.FileName = of.FileName;
                file.Extension = of.FileName.Substring(of.FileName.LastIndexOf('.'), of.FileName.Length - of.FileName.LastIndexOf('.'));
                file.receiver = friendUID.ToString();
                file.sender = myUID.ToString();
                myClient.Send(file.getMessageString());
                MessageBox.Show("Your file has been sent");
            }
        }
    }
}
