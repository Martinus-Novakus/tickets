using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketingSample.Features.Events.Get;
using TicketingSample.Features.Events.Update;
using TicketingSample.Helpers;
using TicketingSample.ViewModels.Manage;

namespace TicketingSample.Pages;

public class ManageUpdateModel : PageBase<ManageUpdateModel>
{
    private readonly IMapper _mapper;

    public ManageUpdateModel(ILogger<ManageUpdateModel> logger, IMediator mediator, IMapper mapper) : base(logger, mediator)
    {
        _mapper = mapper;
    }

    [BindProperty]
    public UpdateEventViewModel EventInput { get; set; } = null!;

    [BindProperty]
    public UpdateSectorViewModel? SectorInput { get; set; }
    public IEnumerable<SelectListItem> SectorOptions { get; set; } = [];
    public EventResponseDTO Detail { get; set; } = null!;

    protected override async Task SetDataInternalAsync(int id, CancellationToken cancellationToken)
    {
        Detail = await _mediator.Send(new GetQuery(id), cancellationToken);
        SectorOptions = Detail.Sectors.Select(x => new SelectListItem(x.Name, x.Id.ToString()));
    }

    public async Task OnGetAsync(int id, CancellationToken cancellationToken)
    {
        await SetDataAsync(id, cancellationToken);

        EventInput = new (Detail);

        if(Detail.Sectors.Any())
        {
            SectorInput = new(Detail.Sectors.First());
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
            _mapper.Map<UpdateEventRequestDTO>(EventInput),
            SectorInput == null ? null :
                _mapper.Map<UpdateEventSectorRequestDTO>(SectorInput)
        ), cancellationToken);

        await SetDataAsync(cancellationToken);

        return RedirectToPage("./Index");
    }
}
