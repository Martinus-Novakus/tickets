namespace TicketingSample.Features.Events.Update;

public record UpdateEventSectorRequestDTO(
    int Id,
    string Name,
    decimal? Price,
    int? RowCount,
    int? SeatsPerRow
);