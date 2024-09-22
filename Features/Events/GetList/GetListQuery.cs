using MediatR;

namespace TicketingSample.Features.Events.GetList;

public record GetListQuery() : IRequest<IEnumerable<EventResponseDTO>>;