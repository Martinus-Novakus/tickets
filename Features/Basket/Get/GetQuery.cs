using MediatR;

namespace TicketingSample.Features.Basket.Get;

public record GetQuery() : IRequest<BasketResponseDTO>;