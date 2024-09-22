using MediatR;

namespace TicketingSample.Features.Basket.Reservation;

public record ReservationCommand(int EventId, int SectorId, IEnumerable<SeatRequestDTO> SelectedSeats) : IRequest;