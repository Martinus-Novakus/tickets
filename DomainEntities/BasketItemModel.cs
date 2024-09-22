namespace TicketingSample.DomainEntities;

public class BasketItemModel
{
    public int EventId { get; set; }
    public int SectorId { get; set; }
    public int RowId { get; set; }
    public int SeatId { get; set; }
    public decimal Price { get; set; }
}