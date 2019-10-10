using SpecificationPattern.ApplicationServices.Specifications;
using SpecificationPattern.Entities;
using SpecificationPattern.FakeRepository;
using System;
using System.Collections.Generic;

namespace SpecificationPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            NameSpecification nameSpecification = new NameSpecification("mehdi");
            var Personrepo = new PersonRepository();
            IReadOnlyCollection<Person> FilteredPeople = Personrepo.GetPeople(nameSpecification);
            Display(FilteredPeople);
            Console.ReadKey();
        }

        public static void Display(IReadOnlyCollection<Person> people)
        {
            foreach (var item in people)
            {
                Console.WriteLine($"Id : {item.Id}  -- Name : {item.FirstName}");
            }
        }
    }
}
