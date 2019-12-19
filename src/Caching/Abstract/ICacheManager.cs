namespace Caching.Abstract
{
    public interface ICacheService
    {
        void AddItem<T>(string key, T data);
        T Get<T>(string key);
        void RemoveKey(string key);
    }
}
