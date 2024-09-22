using TicketingSample.DomainEntities;
using TicketingSample.Services;

namespace TicketingSample.Features.Events.Services;

public class EventStorageService : IEventStorageService
{
    //TODO: ulozit kategorie zvlast do cache
    //spravit category feature
    //spravit category storage service
    //pri vytvarani podujatia tahat zo zoznamu existujucich kategorii
    private readonly string _key = "EVENT_LIST";
    private readonly IStorageService<EventModel> _storageService;

    public EventStorageService(
        IStorageService<EventModel> storageService
    )
    {
        _storageService = storageService;
    }

    public void Create(EventModel item)
    {
        var list = GetList();
        _storageService.Set(_key, list.Append(item));        
    }

    public void Update(EventModel item)
    {
        var list = GetList().ToList();
        list.RemoveAll(x => x.Id == item.Id);
        _storageService.Set(_key, list.Append(item));
    }

    public EventModel? Get(int id)
    {
        var list = GetList();
        return list.FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<EventModel> GetList()
    {
        return _storageService.Get<IEnumerable<EventModel>>(_key) ?? [];
    }

    public void SetList(IEnumerable<EventModel> list)
    {
        _storageService.Set(_key, list);
    }
}