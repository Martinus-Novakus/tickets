using MediatR;

namespace TicketingSample.Features.Events.GetBasketEvents;

///<summary>
///Query na ziskanie zoznamu vstupeniek na vybrane podujatia v kosiku
///</summary>
public record GetBasketEventsQuery() : IRequest<IEnumerable<BasketItemDetailDTO>>;