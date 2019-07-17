using ProxyPattern.Domain;
using ProxyPattern.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ProxyPattern.Infrastructure.Data
{
    public class EFPersonRepository : IPersonRepository
    {
        private readonly DesignPatternContext _context;

        public EFPersonRepository(DesignPatternContext context)
        {
            _context = context;
        }

        public void Add(Person person)
        {
            _context.People.Add(person);
            _context.SaveChanges();
        }

        public Person FindById(int id)
        {
            return _context.People.Find(id);
        }

        public IEnumerable<Person> GetList()
        {
            return _context.People.ToList();
        }

        public void Remove(Person person)
        {
            _context.People.Remove(person);
            _context.SaveChanges();
        }

        public void Update(Person person)
        {
            _context.People.Update(person);
            _context.SaveChanges();
        }
    }
}
