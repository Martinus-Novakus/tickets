using AutoMapper;
using MediatR;

namespace TicketingSample.Features.Basket.Get;

public class GetQueryHandler : IRequestHandler<GetQuery, BasketResponseDTO>
{
    private readonly IEventBasketService _eventBasketService;

    public GetQueryHandler(
        IEventBasketService eventBasketService
    )
    {
        _eventBasketService = eventBasketService;
    }

    public async Task<BasketResponseDTO> Handle(GetQuery request, CancellationToken cancellationToken)
    {
        var basket = _eventBasketService.Get();
        return await Task.FromResult(new BasketResponseDTO(basket.TotalPrice, basket.Items.Count()));
    }
}