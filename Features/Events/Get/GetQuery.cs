using MediatR;

namespace TicketingSample.Features.Events.Get;

public record GetQuery(int Id) : IRequest<EventResponseDTO>;