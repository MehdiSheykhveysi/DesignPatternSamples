namespace MediatorPatternwithHangfire
{
    public interface IChatRoomMedaitor
    {
        void SendMessageToAll(string message);
        void SendMessageToUser(IPerson  person, string message);
        void RemoveClient(IPerson person);
    }
}
