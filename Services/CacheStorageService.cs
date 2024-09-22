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

    private static string GetKey(int id) => $"{typeof(T)}_{id}";

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

    private IEnumerable<string> GetAllKeys()
    {
        var coherentState = typeof(MemoryCache).GetField("_coherentState", BindingFlags.NonPublic | BindingFlags.Instance);
        var coherentStateValue = coherentState?.GetValue(_memoryCache);
        var entriesCollection = coherentStateValue?.GetType().GetProperty("EntriesCollection", BindingFlags.NonPublic | BindingFlags.Instance);
        var entriesCollectionValue = entriesCollection?.GetValue(coherentStateValue) as dynamic;

        if(entriesCollectionValue == null) return [];
        var cacheItems = new List<string>();

        foreach (var cacheItem in entriesCollectionValue)
        {
            var key = cacheItem.GetType().GetProperty("Key").GetValue(cacheItem, null);
            cacheItems.Add(key.ToString());
        }

        return cacheItems.Where(x => x.Contains(typeof(T).ToString()));
    }
}
