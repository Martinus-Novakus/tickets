using TicketingSample.DomainEntities;

namespace TicketingSample.Features.Basket.Reservation;

///<summary>
///Business layer sluzba na pridanie vstupeniek do kosika
///</summary>
public interface IEventBasketService
{
    public void AddRange(IEnumerable<BasketItemModel> reservations);
}