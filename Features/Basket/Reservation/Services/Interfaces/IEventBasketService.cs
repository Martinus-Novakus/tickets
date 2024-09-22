using TicketingSample.DomainEntities;

namespace TicketingSample.Features.Basket.Reservation;

public interface IEventBasketService
{
    public void AddRange(IEnumerable<BasketItemModel> reservations);
}