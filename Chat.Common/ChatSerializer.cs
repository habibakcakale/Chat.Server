namespace Chat.Common
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    public class ChatSerializer
    {
        public byte[] Serialize(object serializeTo)
        {
            using (var stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, serializeTo);
                return stream.ToArray();
            }
        }
        public object Deserialize(byte[] serializeTo)
        {
            using (var stream = new MemoryStream(serializeTo))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return formatter.Deserialize(stream);
            }
        }

    }
}
