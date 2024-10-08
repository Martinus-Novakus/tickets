using FluentValidation;
using TicketingSample.DomainEntities;
using TicketingSample.Services;

namespace TicketingSample.Features.Events.Update;

public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
{
    private readonly IStorageService<EventModel> _eventStorageService;
    private readonly IStorageService<EventCategoryModel> _eventCategoryStorageService;

    public UpdateCommandValidator(
        IStorageService<EventModel> eventStorageService,
        IStorageService<EventCategoryModel> eventCategoryStorageService
    )
    {
        RuleFor(x => x.Id)
        .NotEmpty()
        .Must(BeExistingEvent);

        RuleFor(x => x.CategoryId)
        .NotEmpty()
        .Must(BeExistingEventCategory);

        RuleFor(x => x.Name)
        .NotEmpty()
        .MaximumLength(100);

        RuleFor(x => x.PlaceName)
        .NotEmpty()
        .MaximumLength(100);

        RuleFor(x => x.StreetAndNumber)
        .NotEmpty()
        .MaximumLength(255);

        RuleFor(x => x.City)
        .NotEmpty()
        .MaximumLength(50);

        RuleFor(x => x.Description)
        .MaximumLength(5000);

        RuleFor(x => x.EventStart)
        .NotEmpty();

        RuleFor(x => x.EventReservationsEnd)
        .NotEmpty();

        RuleFor(x => x)
        .Must(BeExistingEventSector).WithMessage(x => $"Selected sector does not exist for this event");

        RuleFor(x => x.Price)
        .GreaterThan(1)
        .LessThan(1000000);

        RuleFor(x => x.SectorName)
        .MaximumLength(100);

        RuleFor(x => x.RowCount)
        .GreaterThan(1)
        .LessThan(100);

        RuleFor(x => x.SeatsPerRow)
        .GreaterThan(1)
        .LessThan(100);

        _eventStorageService = eventStorageService;
        _eventCategoryStorageService = eventCategoryStorageService;
    }

    private bool BeExistingEvent(int id)
    {
        return _eventStorageService.GetList().Any(x => x.Id == id);
    }

    private bool BeExistingEventCategory(int categoryId)
    {
        return _eventCategoryStorageService.GetList().Any(x => x.Id == categoryId);
    }

    private bool BeExistingEventSector(UpdateCommand request)
    {        
        return _eventStorageService.GetList().Any(x => x.Id == request.Id && x.Sectors.Any(y => y.Id == request.SectorId));
    }
}