using MediatR;

namespace TicketingSample.Features.Events.Get;

///<summary>
///Query na ziskanie detailu podujatia
///</summary>
public record GetQuery(int Id) : IRequest<EventResponseDTO>;