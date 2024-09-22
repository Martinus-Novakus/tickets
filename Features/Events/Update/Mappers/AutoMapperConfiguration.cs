using AutoMapper;
using TicketingSample.DomainEntities;
using TicketingSample.ViewModels.Manage;

namespace TicketingSample.Features.Events.Update;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {        
        CreateMap<UpdateEventViewModel, UpdateEventRequestDTO>();
        CreateMap<UpdateSectorViewModel, UpdateEventSectorRequestDTO>();
    }
}