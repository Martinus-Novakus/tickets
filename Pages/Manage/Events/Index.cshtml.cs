using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketingSample.Features.Events.GetEventCategoryList;
using TicketingSample.Features.Events.GetList;

namespace TicketingSample.Pages;

public class ManageEventsIndexModel : PageBase<ManageEventsIndexModel>
{
    public ManageEventsIndexModel(ILogger<ManageEventsIndexModel> logger, IMediator mediator) : base(logger, mediator)
    {
    }

    public IEnumerable<EventResponseDTO> Events { get; set; } = [];
    public IEnumerable<SelectListItem> CategoryOptions { get; set; } = [];

    public async Task OnGetAsync(CancellationToken cancellationToken)
    {
        await SetDataAsync(cancellationToken);
    }

    protected override async Task SetDataInternalAsync(CancellationToken cancellationToken)
    {
        Events = await _mediator.Send(new GetListQuery(), cancellationToken);
        CategoryOptions = (await _mediator.Send(new GetEventCategoryListQuery(), cancellationToken))
            .Select(x => new SelectListItem(x.Name, x.Id.ToString()));
    }
}
