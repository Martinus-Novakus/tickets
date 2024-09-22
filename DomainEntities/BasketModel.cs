namespace TicketingSample.DomainEntities;

public class BasketModel
{
    public decimal TotalPrice { get; set; }
    public IEnumerable<BasketItemModel> Items { get; set; } = [];

    public void AddEvent(BasketItemModel basketEvent)
    {
        if(!Items.Any(x => 
            x.EventId == basketEvent.EventId 
            && x.SectorId == basketEvent.SectorId 
            && x.RowId == basketEvent.RowId 
            && x.SeatId == basketEvent.SeatId))
        {
            Items = Items.Append(basketEvent);
            TotalPrice += basketEvent.Price;
        }
    }
}