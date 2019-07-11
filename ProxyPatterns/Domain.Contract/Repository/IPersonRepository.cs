using ProxyPattern.Domain;
using System.Collections.Generic;

namespace ProxyPattern.Repository
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetList();
        void Add(Person person);
        void Remove(Person person);
        void Update(Person person);
        Person FindById(int id);
    }
}
