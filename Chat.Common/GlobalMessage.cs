namespace Chat.Common
{
    using System;

    [Serializable]
    public class GlobalMessage
    {
        public User User { get; set; }
        public string Message { get; set; }
    }
}
