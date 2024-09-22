using AutoMapper;
using MediatR;
using TicketingSample.DomainEntities;
using TicketingSample.Services;

namespace TicketingSample.Features.Events.GetBasketEvents;

public class GetBasketEventsQueryHandler : IRequestHandler<GetBasketEventsQuery, IEnumerable<BasketItemDetailDTO>>
{
    private readonly ICookieService<BasketModel> _basketService;
    private readonly IStorageService<EventModel> _storageService;
    private readonly IMapper _mapper;

    public GetBasketEventsQueryHandler(
        ICookieService<BasketModel> basketService,
        IStorageService<EventModel> storageService,
        IMapper mapper
    )
    {
        _basketService = basketService;
        _storageService = storageService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BasketItemDetailDTO>> Handle(GetBasketEventsQuery request, CancellationToken cancellationToken)
    {
        var basket = _basketService.Get() ?? new();

        var result = basket.Items.Select(item => {
            var evnt = _storageService.Get(item.EventId);
            var res = _mapper.Map<BasketItemDetailDTO>(evnt);
            res = _mapper.Map(item, res);
            res.SectorName = evnt?.Sectors.FirstOrDefault(e => e.Id == item.SectorId)?.Name ?? string.Empty;
            return res;
        });

        return await Task.FromResult(result);
    }
}