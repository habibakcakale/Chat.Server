using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat.ClientApplication
{
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Sockets;

    using Common;

    public partial class ClientConsole : Form
    {
        private const int Buffersize = 1024 * 1024;

        readonly ChatSerializer serializer = new ChatSerializer();
        public string messageFormat = "{0} - {1}\n";
        private readonly Dictionary<Guid, PrivateChat> OpenedChats = new Dictionary<Guid, PrivateChat>();
        Socket socket;
        public ClientConsole()
        {
            InitializeComponent();
        }

        private async void Connect_Click(object sender, EventArgs e)
        {
            socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(IpAdress.Text, (int)PortNumber.Value);
            this.SendUserName();
            await Task.Run(() =>
                {
                    while (socket.Connected)
                    {
                        var buffer = socket.ReadByteBuffer();
                        switch ((Protocol)buffer.ReadByte())
                        {
                            case Protocol.NewUser:
                                HandleNewUser(buffer);
                                break;
                            case Protocol.UserList:
                                HandleUserList(buffer);
                                break;
                            case Protocol.PrivateMessage:
                                HandleMessage(buffer);
                                break;
                            case Protocol.GlobalMessage:
                                HandleGlobalMessage(buffer);
                                break;
                        }
                    }
                });
        }

        private void HandleGlobalMessage(BinaryReader buffer)
        {
            var message = (GlobalMessage)serializer.Deserialize(buffer.ReadBytes(Buffersize));
            this.InvokeOnUI(
                () =>
                {
                    GlobalMessages.AppendText(string.Format(messageFormat, message.User.Name, message.Message));
                    GlobalMessageBox.Clear();
                });
        }

        private void HandleMessage(BinaryReader buffer)
        {
            var message = (PrivateMessage)serializer.Deserialize(buffer.ReadBytes(Buffersize));
            this.InvokeOnUI(() =>
                {
                    PrivateChat chatPanel;
                    if (OpenedChats.TryGetValue(message.To.Identity, out chatPanel))
                    {
                        this.InvokeOnUI(chatPanel.Activate);
                        chatPanel.PrintMessage(message.Message, message.To.Name);
                    }
                    else
                    {
                        chatPanel = new PrivateChat(socket, message.To);
                        chatPanel.FormClosed += ChatPanelClosed;
                        chatPanel.PrintMessage(message.Message, message.To.Name);
                        OpenedChats.Add(message.To.Identity, chatPanel);
                        chatPanel.Show();
                    }
                });

        }

        private void HandleUserList(BinaryReader buffer)
        {
            var bytes = buffer.ReadBytes(1024 * 1024);
            var package = (NewUserPackage)serializer.Deserialize(bytes);

            this.Invoke((MethodInvoker)delegate
                {
                    foreach (var user in package.Users)
                    {
                        this.UserList.Items.Add(user);
                    }
                });
        }

        public void InvokeOnUI(Action action)
        {
            this.Invoke((MethodInvoker)delegate
                {
                    if (action != null) action();
                });
        }
        private void HandleNewUser(BinaryReader buffer)
        {
            var bytes = buffer.ReadBytes(1024 * 1024);
            var user = (User)serializer.Deserialize(bytes);
            this.Invoke((MethodInvoker)delegate
                {
                    this.UserList.Items.Add(user);
                });
        }

        private void SendUserName()
        {
            var buffer = new ByteBuffer();
            var name = Encoding.UTF8.GetBytes(this.UserName.Text);
            var request = buffer.WriteByte((byte)Protocol.Connect).WriteInt32(name.Length).WriteByteArray(name).ToArray();
            socket.Send(request);
        }

        private void UserList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var item = UserList.SelectedItem as User;
            if (item != null)
            {
                PrivateChat chatPanel;
                if (OpenedChats.TryGetValue(item.Identity, out chatPanel))
                {
                    chatPanel.Show();
                }
                else
                {
                    chatPanel = new PrivateChat(socket, item);
                    chatPanel.FormClosed += ChatPanelClosed;
                    OpenedChats.Add(item.Identity, chatPanel);
                    chatPanel.Show();
                }
            }
        }

        void ChatPanelClosed(object sender, FormClosedEventArgs e)
        {
            var that = sender as PrivateChat;
            if (that != null)
            {
                OpenedChats.Remove(that.User.Identity);
            }
        }

        private void UserList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GlobalMessageBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(GlobalMessageBox.Text))
                return;
            if (e.KeyData == Keys.Enter)
            {
                var buffer = new ByteBuffer();
                buffer.WriteByte((byte)Protocol.GlobalMessage)
                    .WriteByteArray(serializer.Serialize(new GlobalMessage() { Message = GlobalMessageBox.Text }));
                socket.Send(buffer.ToArray());
            }
        }

    }
}
