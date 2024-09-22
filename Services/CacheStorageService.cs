using Microsoft.Extensions.Caching.Memory;

namespace TicketingSample.Services;

public class CacheStorageService : IStorageService
{
    private readonly IMemoryCache _memoryCache;

    public CacheStorageService(
        IMemoryCache memoryCache
    )
    {
        _memoryCache = memoryCache;
    }

    public T? Get<T>(string key)
    {
        return _memoryCache.Get<T>(key);
    }

    public void Set<T>(string key, T item)
    {
        _memoryCache.Set(key, item);
    }
}