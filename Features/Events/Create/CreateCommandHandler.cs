using FluentValidation;
using MediatR;
using TicketingSample.DomainEntities;
using TicketingSample.Exceptions;
using TicketingSample.Helpers;
using TicketingSample.Services;

namespace TicketingSample.Features.Events.Create;

public class CreateCommandHandler : IRequestHandler<CreateCommand>
{
    private readonly IValidator<CreateCommand> _validator;
    private readonly IStorageService<EventModel> _eventStorageService;
    private readonly IStorageService<EventCategoryModel> _eventCategoryStorageService;

    public CreateCommandHandler(
        IValidator<CreateCommand> validator,
        IStorageService<EventModel> eventStorageService,
        IStorageService<EventCategoryModel> eventCategoryStorageService
    )
    {
        _validator = validator;
        _eventStorageService = eventStorageService;
        _eventCategoryStorageService = eventCategoryStorageService;
    }

    public async Task Handle(CreateCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);
        
        var list = _eventStorageService.GetList();
        var id = list.OrderByDescending(x => x.Id).FirstOrDefault()?.Id ?? 1;
        _eventStorageService.Create(
            MapEvent(id, request)
        );
    }

    private EventModel MapEvent(int id, CreateCommand request)
    {
        var category = _eventCategoryStorageService.Get(request.CategoryId) 
            ?? throw new EntityNotFoundException<EventCategoryModel>();

        return new EventModel(id){
            Category = category,
            Name = request.Name,
            PlaceName = request.PlaceName,
            StreetAndNumber = request.StreetAndNumber,
            City = request.City,
            Description = request.Description,
            EventStart = request.EventStart,
            EventReservationsEnd = request.EventReservationsEnd,
            Sectors = new List<SectorModel>{
                new (
                    1, 
                    request.SectorName,
                    request.Price,
                    SeatsHelper.GenerateSeats(
                        request.RowCount,
                        request.SeatsPerRow
                    )
                )
            }
        };
    }
}