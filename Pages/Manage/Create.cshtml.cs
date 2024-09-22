using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketingSample.Features.Events.Create;
using TicketingSample.ViewModels.Manage;

namespace TicketingSample.Pages;

public class ManageCreateModel : PageBase<ManageCreateModel>
{
    public ManageCreateModel(ILogger<ManageCreateModel> logger, IMediator mediator) : base(logger, mediator)
    {
    }

    [BindProperty]
    public CreateEventViewModel Input { get; set; } = null!;

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
