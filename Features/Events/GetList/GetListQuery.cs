using MediatR;

namespace TicketingSample.Features.Events.GetList;

///<summary>
///Query na ziskanie zoznamu podujati vyuzivajuca cache-first pristup. 
///Najprv pozrie ci nie su ulozene lokalne, ak nie ziska ich z API a ulozi do cache.
///Taktiez ulozi kategorie podujati zvlast.
///</summary>
public record GetListQuery() : IRequest<IEnumerable<EventResponseDTO>>;