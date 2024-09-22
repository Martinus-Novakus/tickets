using AutoMapper;
using MediatR;
using TicketingSample.DomainEntities;
using TicketingSample.Exceptions;
using TicketingSample.Services;

namespace TicketingSample.Features.Events.Get;

public class GetQueryHandler : IRequestHandler<GetQuery, EventResponseDTO>
{
    private readonly IStorageService<EventModel> _storageService;
    private readonly IMapper _mapper;

    public GetQueryHandler(
        IStorageService<EventModel> storageService,
        IMapper mapper
    )
    {
        _storageService = storageService;
        _mapper = mapper;
    }

    public async Task<EventResponseDTO> Handle(GetQuery request, CancellationToken cancellationToken)
    {
        var result = _storageService.Get(request.Id) 
            ?? throw new EntityNotFoundException<EventModel>();

        return await Task.FromResult(_mapper.Map<EventResponseDTO>(result));
    }
}