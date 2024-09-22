using MediatR;

namespace TicketingSample.Features.Events.Create;

public record CreateCommand(
    string Name,
    string PlaceName,
    string StreetAndNumber,
    string City,
    string Description,
    int CategoryId,
    DateTime EventStart,
    DateTime EventReservationsEnd,
    decimal Price,
    string SectorName,
    int RowCount,
    int SeatsPerRow
) : IRequest;