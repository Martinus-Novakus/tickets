using TicketingSample.DomainEntities;

namespace TicketingSample.Services;

public interface IBasketService
{
    public BasketModel Get();
    public void Update(BasketModel basket);
}