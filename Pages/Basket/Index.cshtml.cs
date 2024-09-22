using MediatR;
using TicketingSample.Features.Events.GetBasketEvents;

namespace TicketingSample.Pages;

public class BasketIndexModel : PageBase<BasketIndexModel>
{
    public BasketIndexModel(ILogger<BasketIndexModel> logger, IMediator mediator) : base(logger, mediator)
    {
    }

    public IEnumerable<BasketItemDetailDTO> List { get; set; } = null!;

    public async Task OnGetAsync(int id, CancellationToken cancellationToken)
    {
        await SetDataAsync(id, cancellationToken);
    }

    protected override async Task SetDataInternalAsync(int id, CancellationToken cancellationToken)
    {
        List = await _mediator.Send(new GetBasketEventsQuery(), cancellationToken);
    }
}
