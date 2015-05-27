namespace Chat.Common
{
    using System;
    using System.IO;
    using System.Net.Sockets;

    public static class ExtensionMethods
    {
        public static BinaryReader ReadByteBuffer(this Socket socket, int size = 1024*1024*4)
        {
            var response = new byte[size];
            socket.Receive(response);
            return ByteBuffer.Wrap(response);
        }
        public static void SendByte(this Socket socket, byte _byte)
        {
            socket.Send(new[] { _byte });
        }

        public static string F(this string s, params object[] objects)
        {
            return String.Format(s, objects);
        }
    }
}
