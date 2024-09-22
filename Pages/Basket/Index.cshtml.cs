using MediatR;
using TicketingSample.Features.Events.GetBasketEvents;

namespace TicketingSample.Pages;

public class BasketIndexModel : PageBase<BasketIndexModel>
{
    public BasketIndexModel(ILogger<BasketIndexModel> logger, IMediator mediator) : base(logger, mediator)
    {
    }

    public IEnumerable<BasketItemDetailDTO> List { get; set; } = null!;

    public async Task OnGetAsync(CancellationToken cancellationToken)
    {
        await SetDataAsync(cancellationToken);
    }

    protected override async Task SetDataInternalAsync(CancellationToken cancellationToken)
    {
        List = await _mediator.Send(new GetBasketEventsQuery(), cancellationToken);
    }
}
