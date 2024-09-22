using AutoMapper;
using TicketingSample.DomainEntities;

namespace TicketingSample.Features.Events.GetEventCategoryList;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<EventCategoryModel, EventCategoryResponseDTO>();
    }
}