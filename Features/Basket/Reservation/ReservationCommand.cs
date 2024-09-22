using MediatR;

namespace TicketingSample.Features.Basket.Reservation;

///<summary>
///Query na pridanie vybranych vstupeniek do kosika
///</summary>
public record ReservationCommand(int EventId, int SectorId, IEnumerable<SeatRequestDTO> SelectedSeats) : IRequest;