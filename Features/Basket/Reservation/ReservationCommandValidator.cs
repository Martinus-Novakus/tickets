using FluentValidation;
using TicketingSample.DomainEntities;
using TicketingSample.Services;

namespace TicketingSample.Features.Basket.Reservation;

public class ReservationCommandValidator : AbstractValidator<ReservationCommand>
{
    private readonly IStorageService<EventModel> _storageService;

    public ReservationCommandValidator(
        IStorageService<EventModel> storageService
    )
    {

        RuleFor(x => x)
        .Must(BeEventSector).WithMessage(x => $"Selected sector '{x.SectorId}' does not exist in event '{x.EventId}'")
        .Must(BeAvailableSeats).WithMessage(x => $"Some of the selected seats are not available anymore for sector '{x.SectorId}' in event '{x.EventId}'");
        _storageService = storageService;
    }

    private bool BeEventSector(ReservationCommand request)
    {
        var evnt = _storageService.Get(request.EventId);
        return evnt?.Sectors.Any(x => x.Id == request.SectorId) ?? false;
    }

    private bool BeAvailableSeats(ReservationCommand request)
    {
        var evnt = _storageService.Get(request.EventId);
        var sector = evnt?.Sectors.FirstOrDefault(x => x.Id == request.SectorId);
        return sector != null && request.SelectedSeats.All(x => sector.Seats.FirstOrDefault(y => y.RowId == x.RowId && y.SeatId == x.SeatId && y.Reserved) == null);
    }
}