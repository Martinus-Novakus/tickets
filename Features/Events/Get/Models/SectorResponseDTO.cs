namespace TicketingSample.Features.Events.Get;

public class SectorResponseDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public IEnumerable<SeatResponseDTO> Seats { get; set; } = [];
}