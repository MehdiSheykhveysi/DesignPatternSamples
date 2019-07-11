using Microsoft.Extensions.Caching.Memory;
using ProxyPattern.Domain.Contract;

namespace ProxyPattern.Cashe.CasheImpliments
{
    public class InMemoryCacheAdapter : ICasheAdapter
    {
        private readonly IMemoryCache _memoryCache;

        public InMemoryCacheAdapter(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Add<T>(string key,T value)
        {
            _memoryCache.Set(key, value);
        }

        public bool Exist(string key)
        {
            return _memoryCache.TryGetValue(key, out object temp);
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }
    }
}
