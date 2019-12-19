using System;
using System.Runtime.Caching;
using Caching.Abstract;

namespace Caching.Concrete
{
    public class CacheService : ICacheService
    {
        private readonly ICacheconfig _config;

        public CacheManager(ICacheconfig config)
        {
            _config = config;
        }
        public void AddItem<T>(string key, T data)
        {
            var cache = MemoryCache.Default;
            var results = (T)cache.Get(key);
            if (results != null) return;

            var cacheItemPolicy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddHours(_config.DefaultCachePeriod)
            };
            cache.Add(key, data, cacheItemPolicy);
        }

        public T Get<T>(string key)
        {
            var cache = MemoryCache.Default;
            var results = (T)cache.Get(key);
            return results;
        }

        public void RemoveKey(string key)
        {
            var cache = MemoryCache.Default;
            cache.Remove(key);
        }
    }
}
