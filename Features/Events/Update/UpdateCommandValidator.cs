using FluentValidation;
using TicketingSample.DomainEntities;
using TicketingSample.Services;

namespace TicketingSample.Features.Events.Update;

public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
{
    private readonly IStorageService<EventModel> _storageService;

    public UpdateCommandValidator(
        IStorageService<EventModel> storageService
    )
    {
        RuleFor(x => x.EventRequestDto.Id)
        .NotEmpty()
        .Must(BeExistingEvent);

        RuleFor(x => x.EventRequestDto.Name)
        .NotEmpty()
        .MaximumLength(100);

        RuleFor(x => x.EventRequestDto.PlaceName)
        .NotEmpty()
        .MaximumLength(100);

        RuleFor(x => x.EventRequestDto.StreetAndNumber)
        .NotEmpty()
        .MaximumLength(255);

        RuleFor(x => x.EventRequestDto.City)
        .NotEmpty()
        .MaximumLength(50);

        RuleFor(x => x.EventRequestDto.Description)
        .MaximumLength(5000);

        RuleFor(x => x.EventRequestDto.EventStart)
        .NotEmpty();

        RuleFor(x => x.EventRequestDto.EventReservationsEnd)
        .NotEmpty();

        When(x => x.EventSectorRequestDto != null, () => {
            RuleFor(x => x)
            .Must(BeExistingEventSector).WithMessage(x => $"Selected sector does not exist for this event");
        });

        When(x => x.EventSectorRequestDto != null, () => {
            RuleFor(x => x.EventSectorRequestDto!.Price)
            .GreaterThan(1)
            .LessThan(1000000);
        });

        When(x => x.EventSectorRequestDto != null, () => {
            RuleFor(x => x.EventSectorRequestDto!.Name)
            .MaximumLength(100);
        });

        When(x => x.EventSectorRequestDto != null, () => {
            RuleFor(x => x.EventSectorRequestDto!.RowCount)
            .GreaterThan(1)
            .LessThan(100);
        });

        When(x => x.EventSectorRequestDto != null, () => {
            RuleFor(x => x.EventSectorRequestDto!.SeatsPerRow)
            .GreaterThan(1)
            .LessThan(100);
        });

        _storageService = storageService;
    }

    private bool BeExistingEvent(int id)
    {
        return _storageService.GetList().Any(x => x.Id == id);
    }

    private bool BeExistingEventSector(UpdateCommand request)
    {        
        return request.EventSectorRequestDto?.Id == null || _storageService.GetList().Any(x => x.Id == request.EventRequestDto.Id && x.Sectors.Any(y => y.Id == request.EventSectorRequestDto.Id));
    }
}