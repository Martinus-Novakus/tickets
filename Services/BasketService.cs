using System.Text.Json;
using TicketingSample.DomainEntities;
using TicketingSample.Exceptions;

namespace TicketingSample.Services;

public class BasketService : IBasketService
{
    private readonly HttpContext _httpContext;
    private readonly string _basketCookie = "BASKET";
    private readonly JsonSerializerOptions _jsonSerializerOptions = new ();
    public BasketService(
        IHttpContextAccessor httpContextAccessor
    )
    {
        _httpContext = httpContextAccessor.HttpContext ?? throw new HttpContextUnavailableException();
    }

    public void Update(BasketModel basket)
    {
        _httpContext.Response.Cookies.Delete(_basketCookie);
        _httpContext.Response.Cookies.Append(_basketCookie, JsonSerializer.Serialize(basket));
    }

    public BasketModel Get()
    {
        var cookie = _httpContext?.Request.Cookies.FirstOrDefault(x => x.Key == _basketCookie);
        var basket = cookie.HasValue && cookie.Value.Value != null ? JsonSerializer.Deserialize<BasketModel>(cookie.Value.Value, _jsonSerializerOptions) : null;
        return  basket ?? new ();
    }
}