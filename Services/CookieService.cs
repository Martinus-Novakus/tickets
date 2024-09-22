using System.Text.Json;
using TicketingSample.Exceptions;

namespace TicketingSample.Services;

public class CookieService<T> : ICookieService<T> where T : class
{
    private readonly string _key = typeof(T).ToString();
    private readonly HttpContext _httpContext;
    private readonly JsonSerializerOptions _jsonSerializerOptions = new ();
    public CookieService(
        IHttpContextAccessor httpContextAccessor
    )
    {
        _httpContext = httpContextAccessor.HttpContext ?? throw new HttpContextUnavailableException();
    }

    public void Update(T basket)
    {
        _httpContext.Response.Cookies.Delete(_key);
        _httpContext.Response.Cookies.Append(_key, JsonSerializer.Serialize(basket));
    }

    public T? Get()
    {
        var cookie = _httpContext?.Request.Cookies.FirstOrDefault(x => x.Key == _key);
        return cookie.HasValue && cookie.Value.Value != null 
            ? JsonSerializer.Deserialize<T>(cookie.Value.Value, _jsonSerializerOptions) 
            : null;
    }
}