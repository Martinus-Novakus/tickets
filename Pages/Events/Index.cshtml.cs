using MediatR;
using TicketingSample.Features.Events.Get;

namespace TicketingSample.Pages;

public class EventsIndexModel : PageBase<EventsIndexModel>
{
    public EventsIndexModel(ILogger<EventsIndexModel> logger, IMediator mediator) : base(logger, mediator)
    {
    }

    public EventResponseDTO Detail { get; set; } = null!;

    public async Task OnGetAsync(int id, CancellationToken cancellationToken)
    {
        await SetDataAsync(id, cancellationToken);
    }

    
    protected override async Task SetDataInternalAsync(int id, CancellationToken cancellationToken)
    {
        Detail = await _mediator.Send(new GetQuery(id), cancellationToken);
    }
}
