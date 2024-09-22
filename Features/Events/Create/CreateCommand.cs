using MediatR;

namespace TicketingSample.Features.Events.Create;

///<summary>
///Command na vytvorenie noveho podujatia s jednym sektorom
///</summary>
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