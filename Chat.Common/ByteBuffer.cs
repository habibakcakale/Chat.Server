namespace Chat.Common
{
    using System;
    using System.IO;

    public class ByteBuffer:IDisposable
    {
        MemoryStream stream = new MemoryStream();
        BinaryWriter writer;

        public ByteBuffer()
        {
            this.writer = new BinaryWriter(this.stream);
        }

        public static BinaryReader Wrap(byte[] buffer)
        {
            return new BinaryReader(new MemoryStream(buffer, 0, buffer.Length));
        }

        public ByteBuffer WriteInt32(int i)
        {
            this.writer.Write(i);
            return this;
        }

        public ByteBuffer WriteByte(byte b)
        {
            this.writer.Write(b);
            return this;
        }

        public ByteBuffer WriteByteArray(byte[] key)
        {
            this.writer.Write(key);
            return this;
        }

        public byte[] ToArray()
        {
            this.writer.Flush();
            return this.stream.ToArray();
        }

        public void Dispose()
        {
            this.stream.Dispose();
        }
    }
}
