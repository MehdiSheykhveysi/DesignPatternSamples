using System;

namespace MediatorPatternwithHangfire
{
    class IranianPerson : IPerson,IDisposable
    {
        private readonly IChatRoomMedaitor _chatRoomMedaitor;

        public IranianPerson(IChatRoomMedaitor chatRoomMedaitor)
        {
            _chatRoomMedaitor = chatRoomMedaitor;
        }

        public void Dispose()
        {
            _chatRoomMedaitor.RemoveClient(this);
        }

        public string ReceiveMessage(string message)
        {
            return $"Hi, I Got Message {message}";
        }

        public void SendMessageTo(IPerson person, string message)
        {
            _chatRoomMedaitor.SendMessageToUser(person, message);
        }

        public void SendToAll(string message)
        {
            _chatRoomMedaitor.SendMessageToAll(message);
        }
    }
}
