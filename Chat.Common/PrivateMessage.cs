namespace Chat.Common
{
    using System;

    [Serializable]
    public class PrivateMessage
    {
        public User To { get; set; }

        public string Message { get; set; }
    }
}
