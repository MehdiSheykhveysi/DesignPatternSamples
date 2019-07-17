using FacadeDesignPattern.Entitties.DTO;
using FacadeDesignPattern.Services;
using FacadeDesignPattern.Utilities;
using System;

namespace FacadeDesignPattern
{
    public class Program
    {
        private PersonService _personService;

        public static Program Instance => new Program();
        public Program()
        {
            _personService = new PersonService(new AutoMapperFacade(new MyProfile()));
        }

        public static void Main(string[] args)
        {
            var result = Instance.TestFacade();

            Console.WriteLine($"Firstname:{result.FirstName} \n LastName:{result.LastName} \n PhoneNumber :{result.AddressPhone} \n Province :{result.AddressProvince}");
            Console.ReadKey();
        }
        
        public PersonDTO TestFacade()
        {
            return _personService.GetPerson();
        }
    }
}
