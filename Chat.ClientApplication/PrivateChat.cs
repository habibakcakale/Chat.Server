using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat.ClientApplication
{
    using System.Net.Sockets;

    using Common;

    public partial class PrivateChat : Form
    {
        private string messageFormat = "{0} - {1}\n";
        public Common.User User { get; set; }
        private Socket Socket { get; set; }
        ChatSerializer serializer = new ChatSerializer();
        public PrivateChat(Socket socket, Common.User item)
        {
            this.User = item;
            this.Socket = socket;
            InitializeComponent();
        }

        public void PrintMessage(string message, string from = "Me")
        {
            this.Messages.AppendText(string.Format(messageFormat, from, message));
        }
        private void MessageBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MessageBox.Text)) return;
            if (e.KeyData == Keys.Enter)
            {
                var message = new PrivateMessage() { To = User, Message = MessageBox.Text };
                ByteBuffer buffer = new ByteBuffer();
                buffer.WriteByte((byte)Protocol.PrivateMessage)
                    .WriteByteArray(serializer.Serialize(message));
                Socket.Send(buffer.ToArray());
                PrintMessage(MessageBox.Text);
                MessageBox.Clear();
            }
        }
    }
}
