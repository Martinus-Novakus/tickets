using AutoMapper;
using MediatR;
using TicketingSample.DomainEntities;
using TicketingSample.Helpers;
using TicketingSample.Services;

namespace TicketingSample.Features.Events.GetList;

public class GetListQueryHandler : IRequestHandler<GetListQuery, IEnumerable<EventResponseDTO>>
{
    private readonly IEventApiService _eventApiService;
    private readonly IStorageService<EventModel> _eventStorageService;
    private readonly IStorageService<EventCategoryModel> _eventCategoryStorageService;
    private readonly IMapper _mapper;

    public GetListQueryHandler(
        IEventApiService eventApiService,
        IStorageService<EventModel> eventStorageService,
        IStorageService<EventCategoryModel> eventCategoryStorageService,
        IMapper mapper
    )
    {
        _eventApiService = eventApiService;
        _eventStorageService = eventStorageService;
        _eventCategoryStorageService = eventCategoryStorageService;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<EventResponseDTO>> Handle(GetListQuery request, CancellationToken cancellationToken)
    {
        var list = _eventStorageService.GetList();

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

            _eventStorageService.Create(item);
        }

        StoreEventCategories(list.Select(x => x.Category).DistinctBy(x => x.Id).ToList());

        return _mapper.Map<List<EventResponseDTO>>(list);
    }

    private void StoreEventCategories(IEnumerable<EventCategoryModel> categories)
    {
        foreach (var category in categories)
        {
            _eventCategoryStorageService.Create(category);            
        }
    }
}