using MediatR;

namespace TicketingSample.Features.Events.GetEventCategoryList;

public record GetEventCategoryListQuery() : IRequest<IEnumerable<EventCategoryResponseDTO>>;