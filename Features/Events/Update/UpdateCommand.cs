using MediatR;

namespace TicketingSample.Features.Events.Update;

///<summary>
///Command na upravu podujatia a jedneho z jeho sektorov
///</summary>
public record UpdateCommand(
    int Id,
    string Name,
    string PlaceName,
    string StreetAndNumber,
    string City,
    string Description,
    int CategoryId,
    DateTime EventStart,
    DateTime EventReservationsEnd,
    int SectorId,
    decimal Price,
    string SectorName,
    int RowCount,
    int SeatsPerRow
) : IRequest;