using TicketingSample.DomainEntities;

namespace TicketingSample.Features.Basket.Get;

public interface IEventBasketService
{
    public BasketModel Get();
}