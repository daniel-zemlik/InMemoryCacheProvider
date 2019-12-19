using System.Collections.Generic;

namespace Caching.Abstract
{
    public interface ICachedList<T>
    {
        IList<T> GetItems();
    }
}
