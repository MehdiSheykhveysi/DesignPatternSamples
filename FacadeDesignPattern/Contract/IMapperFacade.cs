namespace FacadeDesignPattern.Contract
{
    public interface IMapperFacade
    {
        TOutPut Map<TOutPut, TInput>(TInput input);
    }
}
