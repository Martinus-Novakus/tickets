using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketingSample.Features.Events.GetList;

namespace TicketingSample.Pages;

public class IndexModel : PageBase<IndexModel>
{
    public IndexModel(ILogger<IndexModel> logger, IMediator mediator) : base(logger, mediator)
    {
    }

    public IEnumerable<EventResponseDTO> Events { get; set; } = [];
    public IEnumerable<SelectListItem> EventTypeOptions { get; set; } = [];

    public async Task OnGetAsync(CancellationToken cancellationToken)
    {
        await SetDataAsync(cancellationToken);
    }

    protected override async Task SetDataInternalAsync(CancellationToken cancellationToken)
    {
        Events = await _mediator.Send(new GetListQuery(), cancellationToken);
        EventTypeOptions = Events.DistinctBy(x => x.Category.Id).Select(x => new SelectListItem(x.Category.Name, x.Category.Id.ToString()));
    }
}
