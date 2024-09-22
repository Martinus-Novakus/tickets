using MediatR;

///<summary>
///Query na ziskanie poctu vstupeniek nachadzajucich sa v kosiku a jeho celkovej cene
///</summary>
namespace TicketingSample.Features.Basket.Get;

public record GetQuery() : IRequest<BasketResponseDTO>;