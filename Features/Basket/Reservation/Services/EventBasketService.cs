using TicketingSample.DomainEntities;
using TicketingSample.Services;

namespace TicketingSample.Features.Basket.Reservation;

public class EventBasketService : IEventBasketService
{
    private readonly ICookieService<BasketModel> _basketService;

    public EventBasketService(
        ICookieService<BasketModel> basketService
    )
    {
        _basketService = basketService;
    }

    public void AddRange(IEnumerable<BasketItemModel> reservations)
    {
        var basket = _basketService.Get() ?? new();

        foreach (var item in reservations)
        {
            basket.AddEvent(item);
        }
        
        _basketService.Update(basket);
    }
}