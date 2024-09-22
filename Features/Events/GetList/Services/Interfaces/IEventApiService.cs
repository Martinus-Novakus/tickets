namespace TicketingSample.Features.Events.GetList;

///<summary>
///Business layer API na ziskanie zoznamu podujati
///</summary>
public interface IEventApiService
{
    public Task<IEnumerable<EventSerializableDTO>> GetEventsAsync(CancellationToken cancellationToken);
}