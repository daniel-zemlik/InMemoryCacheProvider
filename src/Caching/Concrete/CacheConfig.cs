using Caching.Abstract;

namespace Caching.Concrete
{
    public class CacheConfig : ICacheConfig
    {
        public int DefaultCachePeriod { get; set; }
    }
}
