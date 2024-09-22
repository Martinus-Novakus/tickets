using System.Xml.Serialization;

namespace TicketingSample.Features.Events.GetList;

[XmlRoot("Root")]
public class EventListSerializableDTO
{
    public EventListSerializableDTO()
    {
    } 

    [XmlElement("event")]
    public EventSerializableDTO[] Events { get; set; } = [];
}