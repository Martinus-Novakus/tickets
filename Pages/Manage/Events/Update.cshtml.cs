using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketingSample.Features.Events.Get;
using TicketingSample.Features.Events.GetEventCategoryList;
using TicketingSample.Features.Events.Update;
using TicketingSample.Helpers;
using TicketingSample.ViewModels.Manage;

namespace TicketingSample.Pages;

public class ManageEventsUpdateModel : PageBase<ManageEventsUpdateModel>
{
    private readonly IMapper _mapper;

    public ManageEventsUpdateModel(ILogger<ManageEventsUpdateModel> logger, IMediator mediator, IMapper mapper) : base(logger, mediator)
    {
        _mapper = mapper;
    }

    [BindProperty]
    public UpdateEventViewModel Input { get; set; } = null!;
    public IEnumerable<SelectListItem> SectorOptions { get; set; } = [];
    public EventResponseDTO Detail { get; set; } = null!;
    public IEnumerable<SelectListItem> CategoryOptions { get; set; } = [];

    protected override async Task SetDataInternalAsync(int id, CancellationToken cancellationToken)
    {
        Detail = await _mediator.Send(new GetQuery(id), cancellationToken);
        SectorOptions = Detail.Sectors.Select(x => new SelectListItem(x.Name, x.Id.ToString()));
        CategoryOptions = (await _mediator.Send(new GetEventCategoryListQuery(), cancellationToken))
            .Select(x => new SelectListItem(x.Name, x.Id.ToString(), Detail.Category.Id == x.Id));
    }

    public async Task OnGetAsync(int id, CancellationToken cancellationToken)
    {
        await SetDataAsync(id, cancellationToken);

        if(Detail.Sectors.Any())
        {
            Input = new (Detail, Detail.Sectors.First());
        }
    }

    public async Task<IActionResult> OnGetSectorAsync(int id, int sectorId, CancellationToken cancellationToken)
    {
        var evnt = await _mediator.Send(new GetQuery(id), cancellationToken);
        var sector = evnt.Sectors.FirstOrDefault(x => x.Id == sectorId);
        
        return sector == null ? NotFound() 
            : new JsonResult(
                new {
                    name = sector.Name,
                    price = sector.Price,
                    rowCount = SeatsHelper.GetRowCount(sector.Seats),
                    seatsPerRow = SeatsHelper.GetSeatCount(sector.Seats)
                }
            );
    }

    public async Task<IActionResult> OnPostAsync(int id, CancellationToken cancellationToken)
    {
        if(!ModelState.IsValid)
        {
            await SetDataAsync(id, cancellationToken);
            return Page();
        }

        await _mediator.Send(new UpdateCommand(
            Input.Id,
            Input.Name,
            Input.PlaceName,
            Input.StreetAndNumber,
            Input.City,
            Input.Description,
            Input.CategoryId,
            Input.EventStart ?? default,
            Input.EventReservationsEnd ?? default,
            Input.SectorId,
            Input.Price ?? default,
            Input.SectorName,
            Input.RowCount ?? default,
            Input.SeatsPerRow ?? default
        ), cancellationToken);

        await SetDataAsync(cancellationToken);

        return RedirectToPage("./Index");
    }
}
