using TicketingSample.DomainEntities;

namespace TicketingSample.Features.Events.Services;

public interface IEventStorageService
{
    public void Update(EventModel item);
    public void Create(EventModel item);
    public EventModel? Get(int id);
    public IEnumerable<EventModel> GetList();
    public void SetList(IEnumerable<EventModel> list);
}