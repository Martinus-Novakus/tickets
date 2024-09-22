using FluentValidation;
using MediatR;
using TicketingSample.DomainEntities;
using TicketingSample.Exceptions;
using TicketingSample.Services;

namespace TicketingSample.Features.Basket.Reservation;

public class ReservationCommandHandler : IRequestHandler<ReservationCommand>
{
    private readonly IValidator<ReservationCommand> _validator;
    private readonly IStorageService<EventModel> _storageService;
    private readonly IEventBasketService _eventBasketService;

    public ReservationCommandHandler(
        IValidator<ReservationCommand> validator,
        IStorageService<EventModel> storageService,
        IEventBasketService eventBasketService
    )
    {
        _validator = validator;
        _storageService = storageService;
        _eventBasketService = eventBasketService;
    }

    public async Task Handle(ReservationCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var evnt = _storageService.Get(request.EventId) ?? throw new EntityNotFoundException<EventModel>();
        var sector = evnt.Sectors.FirstOrDefault(x => x.Id == request.SectorId) ?? throw new EntityNotFoundException<SectorModel>();

        _eventBasketService.AddRange(
            request.SelectedSeats.Select(x => new BasketItemModel(){
                EventId = request.EventId,
                SectorId = request.SectorId,
                RowId = x.RowId,
                SeatId = x.SeatId,
                Price = sector.Price
        }));

        //next steps: okrem ulozenia do kosika by mozno bolo vhodne rovno urobit docasnu rezervaciu kym sa objednavka nepotvrdi
        //sucastou potvrdenia objednavky by malo byt aj overenie ceny listkov v kosiku (cookie) s cenou z uloziska v pripade, 
        //ze by pouzivatel zasahoval do cookies...
    }
}