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
    private readonly IStorageService<EventModel> _eventStorageService;
    private readonly IStorageService<EventCategoryModel> _eventCategoryStorageService;

    public UpdateCommandHandler(
        IValidator<UpdateCommand> validator,
        IStorageService<EventModel> eventStorageService,
        IStorageService<EventCategoryModel> eventCategoryStorageService
    )
    {
        _validator = validator;
        _eventStorageService = eventStorageService;
        _eventCategoryStorageService = eventCategoryStorageService;
    }

    public async Task Handle(UpdateCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);
        
        var evnt = _eventStorageService.Get(request.Id) 
            ?? throw new EntityNotFoundException<EventModel>();

        _eventStorageService.Update(
            MapEvent(request, evnt)
        );
    }

    private EventModel MapEvent(UpdateCommand source, EventModel destination)
    {
        var category = _eventCategoryStorageService.Get(source.CategoryId) 
            ?? throw new EntityNotFoundException<EventCategoryModel>();

        destination.Category = category;
        destination.Name = source.Name;
        destination.PlaceName = source.PlaceName;
        destination.StreetAndNumber = source.StreetAndNumber;
        destination.City = source.City;
        destination.Description = source.Description;
        destination.EventStart = source.EventStart;
        destination.EventReservationsEnd = source.EventReservationsEnd;

        if(source != null)
        {
            destination.UpdateSector(
                new SectorModel(
                    source.SectorId,
                    source.SectorName,
                    source.Price,
                    SeatsHelper.GenerateSeats(source.RowCount, source.SeatsPerRow)
                )
            );
        }
        
        return destination;
    }
}