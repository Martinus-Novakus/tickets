using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketingSample.Features.Events.Create;
using TicketingSample.Features.Events.GetEventCategoryList;
using TicketingSample.ViewModels.Manage;

namespace TicketingSample.Pages;

public class ManageEventsCreateModel : PageBase<ManageEventsCreateModel>
{
    public ManageEventsCreateModel(ILogger<ManageEventsCreateModel> logger, IMediator mediator) : base(logger, mediator)
    {
    }

    [BindProperty]
    public CreateEventViewModel Input { get; set; } = null!;
    public IEnumerable<SelectListItem> CategoryOptions { get; set; } = [];
    protected override async Task SetDataInternalAsync(CancellationToken cancellationToken)
    {
        CategoryOptions = (await _mediator.Send(new GetEventCategoryListQuery(), cancellationToken))
            .Select(x => new SelectListItem(x.Name, x.Id.ToString()));
    }

    public async Task OnGetAsync(CancellationToken cancellationToken)
    {
        await SetDataAsync(cancellationToken);
    }

    public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
    {
        if(!ModelState.IsValid)
        {
            await SetDataAsync(cancellationToken);
            return Page();
        }

        await _mediator.Send(new CreateCommand(
            Input.Name,
            Input.PlaceName,
            Input.StreetAndNumber,
            Input.City,
            Input.Description,
            Input.CategoryId,
            Input.EventStart,
            Input.EventReservationsEnd,
            Input.Price,
            Input.SectorName,
            Input.RowCount,
            Input.SeatsPerRow
        ), cancellationToken);

        return RedirectToPage("./Index");
    }
}
