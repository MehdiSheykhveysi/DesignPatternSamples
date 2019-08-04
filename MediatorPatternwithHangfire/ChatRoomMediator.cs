using System.Collections.Generic;

namespace MediatorPatternwithHangfire
{
    public class ChatRoomMediator : IChatRoomMedaitor
    {
        private readonly List<IPerson> _people;

        public ChatRoomMediator(params IPerson[] people)
        {
            _people.AddRange(people);
        }

        public void RemoveClient(IPerson person)
        {
            _people.Remove(person);
        }

        public void SendMessageToAll(string message)
        {
            _people.ForEach(p=>p.ReceiveMessage(message));
        }

        public void SendMessageToUser(IPerson person, string message)
        {
            person.ReceiveMessage(message);
        }
    }
}
