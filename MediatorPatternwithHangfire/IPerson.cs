namespace MediatorPatternwithHangfire
{
    public interface IPerson
    {
        void SendToAll(string message);
        void SendMessageTo(IPerson person, string message);
        string ReceiveMessage(string message);
    }
}
