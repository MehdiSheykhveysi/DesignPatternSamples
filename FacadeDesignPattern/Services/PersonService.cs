using FacadeDesignPattern.Contract;
using FacadeDesignPattern.DB.Repositories;
using FacadeDesignPattern.Entitties;
using FacadeDesignPattern.Entitties.DTO;

namespace FacadeDesignPattern.Services
{
    public class PersonService
    {
        private readonly IPersonRepository personRepository;
        private readonly IMapperFacade _mapperFacade;

        public PersonService(IMapperFacade mapperFacade)
        {
            this._mapperFacade = mapperFacade;
           // personRepository = new PersonRepository();
        }
        public PersonDTO GetPerson()
        {
            return _mapperFacade.Map<PersonDTO, Person>(personRepository.GetPerson());
        }
    }
}