using System;
using System.Collections.Generic;
using Caching.Abstract;

namespace Caching.Concrete
{
    public class CachedList<T> : ICachedList<T>
    {
        private readonly Func<IList<T>> _updateCacheMethod;
        private readonly string _key;
        private readonly CacheManager _cacheManager;
        private readonly object _lock = new object();

        public CachedList(ICacheConfiguration config, Func<IList<T>> updateCacheMethod, string key)
        {
            _updateCacheMethod = updateCacheMethod;
            _key = key;
            _cacheManager = new CacheManager(config);
        }

        public IList<T> GetItems()
        {
            var list = _cacheManager.Get<IList<T>>(_key);
            if (list != null) return list;

            lock (_lock)
            {
                if (_cacheManager.Get<IList<T>>(_cacheKey) != null) return;

                var items = _getMethod.Invoke();
                _cacheManager.AddCacheItem(_cacheKey, items);
            }

            return _cacheManager.Get<IList<T>>(_key);
        }

    }
}
