using ProxyPattern.Domain;
using ProxyPattern.Domain.Contract;
using ProxyPattern.Repository;
using System.Collections.Generic;

namespace ProxyPattern.Cashe
{
    public class PersonCasheProxy : IPersonRepository
    {

        private readonly IPersonRepository _personRepository;

        private readonly ICasheAdapter _casheAdapter;

        public PersonCasheProxy(IPersonRepository personRepository, ICasheAdapter casheAdapter)
        {
            _personRepository = personRepository;
            _casheAdapter = casheAdapter;
        }

        public void Add(Person person)
        {
            _personRepository.Add(person);
        }

        public Person FindById(int id)
        {
            string key = $"Person{id}";
            if (_casheAdapter.Exist(key))
                return _casheAdapter.Get<Person>(key);
            else
                return _personRepository.FindById(id);
        }

        public IEnumerable<Person> GetList()
        {
            string key = $"People";

            if (!_casheAdapter.Exist(key))
                return _personRepository.GetList();
            else
                return _casheAdapter.Get<IEnumerable<Person>>(key);
        }

        public void Remove(Person person)
        {
            string key = $"Person{person.ID}";

            if (_casheAdapter.Exist(key))
                _casheAdapter.Remove(key);

            _personRepository.Remove(person);
        }

        public void Update(Person person)
        {
            string key = $"Person{person.ID}";

            if (_casheAdapter.Exist(key))
                _casheAdapter.Remove(key);

            _personRepository.Update(person);
        }
    }
}
