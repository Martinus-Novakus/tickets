using AutoMapper;
using TicketingSample.DomainEntities;

namespace TicketingSample.Features.Events.Get;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {        
        CreateMap<EventModel, EventResponseDTO>();
        CreateMap<EventCategoryModel, EventCategoryResponseDTO>();
        CreateMap<SectorModel, SectorResponseDTO>();
        CreateMap<SeatModel, SeatResponseDTO>();
    }
}