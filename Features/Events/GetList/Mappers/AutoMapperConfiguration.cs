using AutoMapper;
using TicketingSample.DomainEntities;

namespace TicketingSample.Features.Events.GetList;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<EventSerializableDTO, EventModel>()
            .BeforeMap((x, y) => y.Category = new EventCategoryModel(x.TypeId, x.TypeName))
            .BeforeMap((x, y) => y.Sectors = x.Prices.Split(";").Select((price, id) => {
                var priceSplit = price.Split(':');
                return new SectorModel(++id, priceSplit[0].Trim(), Convert.ToDecimal(priceSplit[1]), []);
            }));
        
        CreateMap<EventModel, EventResponseDTO>();
        CreateMap<EventCategoryModel, EventCategoryResponseDTO>();
    }
}