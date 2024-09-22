using MediatR;

namespace TicketingSample.Features.Events.GetBasketEvents;

public record GetBasketEventsQuery() : IRequest<IEnumerable<BasketItemDetailDTO>>;