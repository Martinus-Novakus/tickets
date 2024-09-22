using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketingSample.Features.Events.Get;
using TicketingSample.Features.Basket.Reservation;
using TicketingSample.ViewModels.Events;

namespace TicketingSample.Pages;

public class EventsTicketsModel : PageBase<EventsTicketsModel>
{
    public EventsTicketsModel(ILogger<EventsTicketsModel> logger, IMediator mediator) : base(logger, mediator)
    {
    }

    public EventResponseDTO Detail { get; set; } = null!;
    public IEnumerable<SelectListItem> SectorOptions { get; set; } = [];

    [BindProperty]
    public SectorViewModel Input { get; set; } = null!;
    protected override async Task SetDataInternalAsync(int id, CancellationToken cancellationToken)
    {
        Detail = await _mediator.Send(new GetQuery(id), cancellationToken);
        SectorOptions = Detail.Sectors.Select(x => new SelectListItem(x.Name, x.Id.ToString()));
    }

    public async Task OnGetAsync(int id, CancellationToken cancellationToken)
    {
        await SetDataAsync(id, cancellationToken);
        
        var firstSector = GetFirstSector(Detail);
        if(firstSector != null)
            Input = new(firstSector);
    }

    public async Task<IActionResult> OnPostAsync(int id, CancellationToken cancellationToken)
    {
        await SetDataAsync(id, cancellationToken);

        var sector = Detail.Sectors.FirstOrDefault(x => x.Id == Input.SectorId);
        if(sector == null)
        {
            ModelState.AddModelError("Sector", "Vybraný sektor neexistuje");
            return Page();            
        }

        if(!Input.SelectedSeats.Any(x => x.Value))
        {
            Input.SetSeats(sector);
            ModelState.AddModelError("Selection", "Vyberte prosím aspoň jedno miesto");
            return Page();
        }

        await _mediator.Send(new ReservationCommand(id, sector.Id, MapPostRequestData(sector, Input.SelectedSeats)), cancellationToken);

        return RedirectToPage("/Basket/Index");
    }

    public async Task<IActionResult> OnGetSectorAsync(int id, int sectorId, CancellationToken cancellationToken)
    {
        Detail = await _mediator.Send(new GetQuery(id), cancellationToken);
        var sector = Detail.Sectors.FirstOrDefault(x => x.Id == sectorId);
        
        if(sector == null)
            return NotFound();

        Input = new(sector);
        return Partial("/Pages/Events/Partials/_SectorPartial.cshtml", Input);
    }

    private static SectorResponseDTO? GetFirstSector(EventResponseDTO detail)
        => detail.Sectors.FirstOrDefault();

    private static List<SeatRequestDTO> MapPostRequestData(SectorResponseDTO sector, IDictionary<int, bool> seats)
    {
        var result = new List<SeatRequestDTO>();
        foreach (var selection in seats.Where(x => x.Value).ToList())
        {
            var seat = sector.Seats.FirstOrDefault(x => x.Id == selection.Key);

            if(seat == null) break;

            result.Add(new(seat.RowId, seat.SeatId));            
        }
        return result;
    }
}
