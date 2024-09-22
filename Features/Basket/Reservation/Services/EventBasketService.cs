using TicketingSample.DomainEntities;
using TicketingSample.Services;

namespace TicketingSample.Features.Basket.Reservation;

public class EventBasketService : IEventBasketService
{
    private readonly IBasketService _basketService;

    public EventBasketService(
        IBasketService basketService
    )
    {
        _basketService = basketService;
    }

    public void AddRange(IEnumerable<BasketItemModel> reservations)
    {
        var basket = _basketService.Get();

        foreach (var item in reservations)
        {
            basket.AddEvent(item);
        }
        
        _basketService.Update(basket);
    }
}