namespace TicketingSample.Features.Events.Get;

public class SeatResponseDTO
{
    public int Id { get; set; }
    public int RowId { get; set; }
    public int SeatId { get; set; }
    public bool Reserved { get; set; }
}