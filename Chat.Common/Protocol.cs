namespace Chat.Common
{
    public enum Protocol : byte
    {
        Connect = 0,
        GlobalMessage = 1,
        PrivateMessage = 2,
        NewUser = 3,
        UserList = 4
        
    }
}
