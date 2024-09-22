using System.Reflection;
using Microsoft.Extensions.Caching.Memory;
using TicketingSample.DomainEntities;

namespace TicketingSample.Services;

public class CacheStorageService<T> : IStorageService<T> where T : EntityBaseModel
{
    private readonly IMemoryCache _memoryCache;

    public CacheStorageService(
        IMemoryCache memoryCache
    )
    {
        _memoryCache = memoryCache;
    }

    public void Create(T item)
    {
        _memoryCache.Set(GetKey(item.Id), item);
    }

    public T? Get(int id)
    {
        return _memoryCache.Get<T>(GetKey(id));
    }

    public void Update(T item)
    {
        Create(item);
    }

    public IEnumerable<T> GetList()
    {
        foreach (var key in GetAllKeys())
        {
            var value = _memoryCache.Get<T>(key);

            if(value != null)
                yield return value;
        }
    }

    private static string GetKey(int id) => $"{typeof(T)}_{id}";

    private IEnumerable<string> GetAllKeys()
    {
        var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", BindingFlags.NonPublic | BindingFlags.Instance);
        var cacheEntriesCollection = cacheEntriesCollectionDefinition?.GetValue(_memoryCache) as dynamic;

        if(cacheEntriesCollection == null) return [];
        var cacheItems = new List<string>();

        foreach (var cacheItem in cacheEntriesCollection)
        {
            var key = cacheItem.GetType().GetProperty("Key").GetValue(cacheItem, null);
            cacheItems.Add(key.ToString());
        }

        return cacheItems.Where(x => x.Contains(typeof(T).ToString()));
    }
}
