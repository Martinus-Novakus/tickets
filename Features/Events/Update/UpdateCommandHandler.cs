using FluentValidation;
using MediatR;
using TicketingSample.DomainEntities;
using TicketingSample.Exceptions;
using TicketingSample.Helpers;
using TicketingSample.Services;

namespace TicketingSample.Features.Events.Update;

public class UpdateCommandHandler : IRequestHandler<UpdateCommand>
{
    private readonly IValidator<UpdateCommand> _validator;
    private readonly IStorageService<EventModel> _storageService;

    public UpdateCommandHandler(
        IValidator<UpdateCommand> validator,
        IStorageService<EventModel> storageService
    )
    {
        _validator = validator;
        _storageService = storageService;
    }

    public async Task Handle(UpdateCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);
        
        var evnt = _storageService.Get(request.EventRequestDto.Id) 
            ?? throw new EntityNotFoundException<EventModel>();

        _storageService.Update(
            MapEvent(request, evnt)
        );
    }

    private static EventModel MapEvent(UpdateCommand source, EventModel destination)
    {
        destination.Name = source.EventRequestDto.Name;
        destination.PlaceName = source.EventRequestDto.PlaceName;
        destination.StreetAndNumber = source.EventRequestDto.StreetAndNumber;
        destination.City = source.EventRequestDto.City;
        destination.Description = source.EventRequestDto.Description;
        destination.EventStart = source.EventRequestDto.EventStart;
        destination.EventReservationsEnd = source.EventRequestDto.EventReservationsEnd;

        if(source.EventSectorRequestDto != null)
        {
            destination.UpdateSector(
                new SectorModel(
                    source.EventSectorRequestDto.Id,
                    source.EventSectorRequestDto.Name,
                    source.EventSectorRequestDto.Price,
                    SeatsHelper.GenerateSeats(source.EventSectorRequestDto.RowCount, source.EventSectorRequestDto.SeatsPerRow)
                )
            );
        }
        
        return destination;
    }
}