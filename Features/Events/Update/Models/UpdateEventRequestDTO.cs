namespace TicketingSample.Features.Events.Update;

public record UpdateEventRequestDTO(
    int Id,
    string Name,
    string PlaceName,
    string StreetAndNumber,
    string City,
    string Description,
    DateTime EventStart,
    DateTime EventReservationsEnd
);