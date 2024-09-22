using System.Runtime.CompilerServices;
using AutoMapper;
using TicketingSample.DomainEntities;

namespace TicketingSample.Features.Events.GetBasketEvents;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {        
        CreateMap<EventModel, BasketItemDetailDTO>();
        CreateMap<BasketItemModel, BasketItemDetailDTO>();
    }
}