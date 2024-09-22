using TicketingSample.DomainEntities;
using TicketingSample.Services;

namespace TicketingSample.Features.Basket.Get;

public class EventBasketService : IEventBasketService
{
    private readonly IBasketService _basketService;

    public EventBasketService(
        IBasketService basketService
    )
    {
        _basketService = basketService;
    }

    public BasketModel Get()
    {
        return _basketService.Get();
    }
}