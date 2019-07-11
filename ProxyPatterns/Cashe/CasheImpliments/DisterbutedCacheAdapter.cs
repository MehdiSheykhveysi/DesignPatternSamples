using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using ProxyPattern.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyPattern.Cashe.CasheImpliments
{
    public class DisterbutedCacheAdapter : ICasheAdapter
    {
        private readonly IDistributedCache _distributedCache;

        public DisterbutedCacheAdapter(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public void Add<T>(string key, T value)
        {
            _distributedCache.SetString(key, JsonConvert.SerializeObject(value));
        }

        public bool Exist(string key)
        {
            return string.IsNullOrWhiteSpace(_distributedCache.GetString(key));
        }

        public T Get<T>(string key)
        {
            return JsonConvert.DeserializeObject<T>(_distributedCache.GetString(key));
        }

        public void Remove(string key)
        {
            _distributedCache.Remove(key);
        }
    }
}
