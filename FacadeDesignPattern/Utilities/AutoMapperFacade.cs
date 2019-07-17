using AutoMapper;
using FacadeDesignPattern.Contract;

namespace FacadeDesignPattern.Utilities
{
    public class AutoMapperFacade : IMapperFacade
    {
        private readonly MapperConfiguration _mapper;

        public AutoMapperFacade(params Profile[] profile)
        {
            _mapper = new MapperConfiguration(c =>
              {
                  for (int i = 0; i < profile.Length; i++)
                  {
                      c.AddProfile(profile[i]);
                  }
              });
        }

        public TOutPut Map<TOutPut, TInput>(TInput input)
        {
            return _mapper.CreateMapper().Map<TOutPut>(input);
        }
    }
}
