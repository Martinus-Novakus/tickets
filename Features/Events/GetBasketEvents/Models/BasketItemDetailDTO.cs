namespace TicketingSample.Features.Events.GetBasketEvents;

public class BasketItemDetailDTO
{
    public BasketItemDetailDTO()
    {
    }

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string EventUrl { get; set; } = string.Empty;
    public DateTime EventStart { get; set; }
    public string PlaceName { get; set; } = string.Empty;
    public string StreetAndNumber { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string SectorName { get; set; } = string.Empty;
    public int RowId { get; set; }
    public int SeatId { get; set; }
    public decimal Price { get; set; }  
}
