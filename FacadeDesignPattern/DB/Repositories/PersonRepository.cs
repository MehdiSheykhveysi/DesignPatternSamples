using FacadeDesignPattern.Contract;
using FacadeDesignPattern.Entitties;
using FacadeDesignPattern.Entitties.DTO;

namespace FacadeDesignPattern.DB.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public Person GetPerson()
        {
            return new Person
            {
                 FirstName="Mehdi",
                  Lastname="SheykhVeysi",
                   Address=new Address
                   {
                        Phone="0930 751 ****",
                        Province="Golestan"
                   }
            };
        }
    }
}
