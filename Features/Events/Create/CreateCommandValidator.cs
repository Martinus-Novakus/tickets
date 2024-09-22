using FluentValidation;
using TicketingSample.DomainEntities;
using TicketingSample.Services;

namespace TicketingSample.Features.Events.Create;

public class CreateCommandValidator : AbstractValidator<CreateCommand>
{
    private readonly IStorageService<EventCategoryModel> _eventCategoryStorageService;

    public CreateCommandValidator(
        IStorageService<EventCategoryModel> eventCategoryStorageService
    )
    {
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

        RuleFor(x => x.Price)
        .NotEmpty()
        .GreaterThan(1)
        .LessThan(1000000);

        RuleFor(x => x.SectorName)
        .NotEmpty()
        .MaximumLength(100);

        RuleFor(x => x.RowCount)
        .NotEmpty()
        .GreaterThan(1)
        .LessThan(100);

        RuleFor(x => x.SeatsPerRow)
        .NotEmpty()
        .GreaterThan(1)
        .LessThan(100);
        _eventCategoryStorageService = eventCategoryStorageService;
    }

    private bool BeExistingEventCategory(int categoryId)
    {
        return _eventCategoryStorageService.GetList().Any(x => x.Id == categoryId);
    }
}