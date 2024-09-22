using AutoMapper;
using MediatR;
using TicketingSample.DomainEntities;
using TicketingSample.Helpers;
using TicketingSample.Services;

namespace TicketingSample.Features.Events.GetList;

public class GetListQueryHandler : IRequestHandler<GetListQuery, IEnumerable<EventResponseDTO>>
{
    private readonly IEventApiService _eventApiService;
    private readonly IStorageService<EventModel> _storageService;
    private readonly IMapper _mapper;

    public GetListQueryHandler(
        IEventApiService eventApiService,
        IStorageService<EventModel> storageService,
        IMapper mapper
    )
    {
        _eventApiService = eventApiService;
        _storageService = storageService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EventResponseDTO>> Handle(GetListQuery request, CancellationToken cancellationToken)
    {
        var list = _storageService.GetList();

        if(list.Any())
        {
            return _mapper.Map<List<EventResponseDTO>>(list);
        }

        var dtoList = await _eventApiService.GetEventsAsync(cancellationToken);
        list = _mapper.Map<List<EventModel>>(dtoList);

        foreach (var item in list)
        {
            item.Sectors = item.Sectors.Select(x => {
                x.Seats = SeatsHelper.GenerateRandomSeats();
                return x;
            }).ToList();
        }

        _storageService.SetList(list);

        return _mapper.Map<List<EventResponseDTO>>(list);
    }
}