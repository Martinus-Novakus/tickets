using FluentValidation;
using MediatR;
using TicketingSample.DomainEntities;
using TicketingSample.Helpers;
using TicketingSample.Services;

namespace TicketingSample.Features.Events.Create;

public class CreateCommandHandler : IRequestHandler<CreateCommand>
{
    private readonly IValidator<CreateCommand> _validator;
    private readonly IStorageService<EventModel> _storageService;

    public CreateCommandHandler(
        IValidator<CreateCommand> validator,
        IStorageService<EventModel> storageService
    )
    {
        _validator = validator;
        _storageService = storageService;
    }

    public async Task Handle(CreateCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);
        
        var list = _storageService.GetList();
        var id = list.OrderByDescending(x => x.Id).FirstOrDefault()?.Id ?? 0;
        _storageService.Create(
            MapEvent(id, request)
        );
    }

    private static EventModel MapEvent(int id, CreateCommand request)
    {
        return new EventModel(id){
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