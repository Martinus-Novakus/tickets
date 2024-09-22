namespace TicketingSample.Features.Events.Get;

public class EventResponseDTO
{
    public EventResponseDTO()
    {
    }

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string EventUrl { get; set; } = string.Empty;
    public EventCategoryResponseDTO Category { get; set; } = null!;
    public DateTime EventStart { get; set; }
    public DateTime EventReservationsEnd { get; set; }
    public string PlaceName { get; set; } = string.Empty;
    public string StreetAndNumber { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string[] PriceList { get; set; } = [];
    public string PromoterName { get; set; } = string.Empty;
    public string LocationLat { get; set; } = string.Empty;
    public string LocationLon { get; set; } = string.Empty;
    public IEnumerable<SectorResponseDTO> Sectors { get; set; } = [];
}