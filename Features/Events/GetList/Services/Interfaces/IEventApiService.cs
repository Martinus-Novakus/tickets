namespace TicketingSample.Features.Events.GetList;

public interface IEventApiService
{
    public Task<IEnumerable<EventSerializableDTO>> GetEventsAsync(CancellationToken cancellationToken);
}