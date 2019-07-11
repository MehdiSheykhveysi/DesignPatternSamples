namespace ProxyPattern.Domain.Contract
{
    public interface ICasheAdapter
    {
        bool Exist(string key);
        void Add<T>(string key, T value);
        T Get<T>(string key);
        void Remove(string key);
    }
}