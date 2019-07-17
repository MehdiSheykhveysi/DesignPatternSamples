using AutoMapper;
using FacadeDesignPattern.Entitties;
using FacadeDesignPattern.Entitties.DTO;

namespace FacadeDesignPattern.Utilities
{
    public class MyProfile : Profile
    {
        public MyProfile()
        {
            CreateMap<Person, PersonDTO>().ReverseMap();
        }
    }
}
