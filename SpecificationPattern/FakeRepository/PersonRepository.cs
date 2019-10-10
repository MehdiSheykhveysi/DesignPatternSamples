using SpecificationPattern.ApplicationServices.Specifications.Common;
using SpecificationPattern.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecificationPattern.FakeRepository
{
    public class PersonRepository
    {
        private IEnumerable<Person> People = new List<Person>
        {
            new Person
            {
                Id = 1,
                FirstName = "Mehdi"
            },
            new Person
            {
                Id = 1,
                FirstName = "Mohammad"
            },
            new Person
            {
                Id = 1,
                FirstName = "Arman"
            }
        };


        public IReadOnlyCollection<Person> GetPeople(Specification<Person> specification)
        {
            return People.AsQueryable().Where(specification.ToExpression()).ToList();
        }
    }
}
