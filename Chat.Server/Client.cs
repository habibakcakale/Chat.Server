namespace Chat.Server
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net.Sockets;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Threading.Tasks;

    using Common;

    internal class Client
    {
        public Client(Socket socket, Guid guid)
        {
            this.Socket = socket;
            this.Identity = guid;
        }

        private const int BUFFERSIZE = 1024 * 1024;
        public Socket Socket { get; private set; }

        public Guid Identity { get; private set; }
        public string Name { get; set; }
        internal void StartComminication()
        {
            Task.Run(
                () =>
                {
                    while (Socket.Connected)
                    {
                        var buffer = Socket.ReadByteBuffer();
                        switch ((Protocol)buffer.ReadByte())
                        {
                            case Protocol.Connect:
                                HandleConnect(buffer);
                                break;
                            case Protocol.PrivateMessage:
                                HandlePrivateMessage(buffer);
                                break;
                            case Protocol.GlobalMessage:
                                HandleGlobalMessage(buffer);
                                break;
                            default:
                                break;
                        }
                    }
                });
        }

        private void HandleGlobalMessage(BinaryReader buffer)
        {
            var message = (GlobalMessage)serializer.Deserialize(buffer.ReadBytes(BUFFERSIZE));
            message.User = new User()
            {
                Identity = this.Identity,
                Name = this.Name
            };
            foreach (var client in MainForm.Clients)
            {
                var messageBuffer = new ByteBuffer().WriteByte((byte)Protocol.GlobalMessage).WriteByteArray(serializer.Serialize(message));
                client.Value.Socket.Send(messageBuffer.ToArray());
            }
        }

        private void HandlePrivateMessage(BinaryReader buffer)
        {
            var message = (PrivateMessage)serializer.Deserialize(buffer.ReadBytes(BUFFERSIZE));
            Client client;
            if (MainForm.Clients.TryGetValue(message.To.Identity, out client))
            {
                ByteBuffer toMessage = new ByteBuffer();
                toMessage.WriteByte((byte)Protocol.PrivateMessage)
                    .WriteByteArray(serializer.Serialize(new PrivateMessage() { To = new User() { Identity = this.Identity, Name = this.Name }, Message = message.Message }));
                client.Socket.Send(toMessage.ToArray());
            }
        }

        private void HandleConnect(System.IO.BinaryReader buffer)
        {
            var length = buffer.ReadInt32();
            byte[] bf = new byte[length];
            buffer.Read(bf, 0, length);
            this.Name = Encoding.UTF8.GetString(bf);
            this.NotifyNewUser();
            this.SendUserList();
        }

        private void SendUserList()
        {
            NewUserPackage package = new NewUserPackage();
            foreach (var client in MainForm.Clients.Where(item => item.Key != this.Identity))
            {
                package.Users.Add(new User
                {
                    Identity = client.Key,
                    Name = client.Value.Name
                });
            }
            if (package.Users.Count < 1) return;
            using (var stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, package);
                using (var buffer = new ByteBuffer())
                {
                    buffer.WriteByte((byte)Protocol.UserList).WriteByteArray(stream.ToArray());
                    this.Socket.Send(buffer.ToArray());
                }
            }
        }
        ChatSerializer serializer = new ChatSerializer();
        private void NotifyNewUser()
        {
            using (var response = new ByteBuffer())
            {
                var user = new User { Identity = this.Identity, Name = this.Name };
                response.WriteByte((byte)Protocol.NewUser)
                    .WriteByteArray(serializer.Serialize(user));
                foreach (var client in MainForm.Clients.Where(item => item.Key != this.Identity))
                {
                    client.Value.Socket.Send(response.ToArray());
                }
            }
        }


    }
}