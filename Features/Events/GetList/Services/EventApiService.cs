using System.Xml.Serialization;
using TicketingSample.Services;

namespace TicketingSample.Features.Events.GetList;

public class EventApiService : IEventApiService
{
    private readonly IApiService _apiService;

    public EventApiService(
        IApiService apiService
    )
    {
        _apiService = apiService;
    }

    public async Task<IEnumerable<EventSerializableDTO>> GetEventsAsync(CancellationToken cancellationToken)
    {
        var responseStream = await _apiService.GetAsync("/xml/out/partnerall.xml?ID_partner=37", cancellationToken);

        var serializer = new XmlSerializer(typeof(EventListSerializableDTO));
        using StreamReader reader = new StreamReader(responseStream);
        var root = serializer.Deserialize(reader) as EventListSerializableDTO;
        return root?.Events ?? [];
    }
}