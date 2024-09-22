using MediatR;

namespace TicketingSample.Features.Events.GetEventCategoryList;

///<summary>
///Query na ziskanie zoznamu kategorii podujati 
///(extrahovanych zo zoznamu podujati - toto by za normalnych okolnosti bolo brane ako zvlast entita so zvlast zdrojom ako API)
///</summary>
public record GetEventCategoryListQuery() : IRequest<IEnumerable<EventCategoryResponseDTO>>;