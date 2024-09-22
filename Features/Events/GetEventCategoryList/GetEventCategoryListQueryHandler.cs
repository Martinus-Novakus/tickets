using AutoMapper;
using MediatR;
using TicketingSample.DomainEntities;
using TicketingSample.Exceptions;
using TicketingSample.Services;

namespace TicketingSample.Features.Events.GetEventCategoryList;

public class GetEventCategoryListQueryHandler : IRequestHandler<GetEventCategoryListQuery, IEnumerable<EventCategoryResponseDTO>>
{
    private readonly IStorageService<EventCategoryModel> _storageService;
    private readonly IMapper _mapper;

    public GetEventCategoryListQueryHandler(
        IStorageService<EventCategoryModel> storageService,
        IMapper mapper
    )
    {
        _storageService = storageService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EventCategoryResponseDTO>> Handle(GetEventCategoryListQuery request, CancellationToken cancellationToken)
    {
        var list = _storageService.GetList();

        return await Task.FromResult(
            list.Select(x => 
                _mapper.Map<EventCategoryResponseDTO>(x)
            )
        );
    }
}