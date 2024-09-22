using AutoMapper;
using MediatR;
using TicketingSample.DomainEntities;
using TicketingSample.Services;

namespace TicketingSample.Features.Basket.Get;

public class GetQueryHandler : IRequestHandler<GetQuery, BasketResponseDTO>
{
    private readonly ICookieService<BasketModel> _cookieService;

    public GetQueryHandler(
        ICookieService<BasketModel> cookieService
    )
    {
        _cookieService = cookieService;
    }

    public async Task<BasketResponseDTO> Handle(GetQuery request, CancellationToken cancellationToken)
    {
        var basket = _cookieService.Get() ?? new();
        return await Task.FromResult(new BasketResponseDTO(basket.TotalPrice, basket.Items.Count()));
    }
}