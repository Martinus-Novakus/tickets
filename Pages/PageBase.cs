using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TicketingSample.Features.Basket.Get;

namespace TicketingSample.Pages;

public abstract class PageBase<T> : PageBase
{
    protected readonly ILogger<T> _logger;
    protected readonly IMediator _mediator;

    public PageBase(ILogger<T> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }
    
    protected virtual async Task SetDataInternalAsync(CancellationToken cancellationToken) => await Task.CompletedTask;
    protected virtual async Task SetDataInternalAsync(int id, CancellationToken cancellationToken) => await Task.CompletedTask;

    protected async Task SetDataAsync(CancellationToken cancellationToken)
    {
        await SetBasket(cancellationToken);
        await SetDataInternalAsync(cancellationToken);
    }

    protected async Task SetDataAsync(int id, CancellationToken cancellationToken)
    {
        await SetBasket(cancellationToken);
        await SetDataInternalAsync(id, cancellationToken);
    }

    private async Task SetBasket(CancellationToken cancellationToken)
        => Basket = await _mediator.Send(new GetQuery(), cancellationToken);
}

public abstract class PageBase : PageModel
{
    public BasketResponseDTO Basket { get; set; } = null!;
}
