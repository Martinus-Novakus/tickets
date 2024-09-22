using System.Xml.Serialization;

namespace TicketingSample.Features.Events.GetList;

[XmlRoot("event")]
public class EventSerializableDTO
{
    public EventSerializableDTO()
    {
    }

    [XmlElement("ID")]
    public int Id { get; set; }
    
    [XmlElement("nazov")]
    public string Name { get; set; } = string.Empty;

    [XmlElement("link_pict")]
    public string ImageUrl { get; set; } = string.Empty;

    [XmlElement("linka")]
    public string EventUrl { get; set; } = string.Empty;

    [XmlElement("ID_typ_podujatia")]
    public int TypeId { get; set; }

    [XmlElement("typ_podujatia")]
    public string TypeName { get; set; } = string.Empty;

    [XmlElement("zaciatok")]
    public DateTime EventStart { get; set; }

    [XmlElement("koniec_rez")]
    public DateTime EventReservationsEnd { get; set; }

    [XmlElement("hladisko")]
    public string PlaceName { get; set; } = string.Empty;

    [XmlElement("adresa")]
    public string StreetAndNumber { get; set; } = string.Empty;

    [XmlElement("mesto")]
    public string City { get; set; } = string.Empty;

    [XmlElement("popis")]
    public string Description { get; set; } = string.Empty;

    [XmlElement("ceny")]
    public string Prices { get; set; } = string.Empty;

    [XmlElement("promoterName")]
    public string PromoterName { get; set; } = string.Empty;

    [XmlElement("evtLocLat")]
    public string LocationLat { get; set; } = string.Empty;

    [XmlElement("evtLocLon")]
    public string LocationLon { get; set; } = string.Empty;
}