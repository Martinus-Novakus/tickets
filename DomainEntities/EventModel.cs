using TicketingSample.Helpers;

namespace TicketingSample.DomainEntities;

public class EventModel : EntityBaseModel
{
    public EventModel(int id) : base(id)
    {
    }

    public string Name { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string EventUrl { get; set; } = string.Empty;
    public EventCategoryModel Category { get; set; } = null!;
    public DateTime EventStart { get; set; }
    public DateTime EventReservationsEnd { get; set; }
    public string PlaceName { get; set; } = string.Empty;
    public string StreetAndNumber { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string PromoterName { get; set; } = string.Empty;
    public string LocationLat { get; set; } = string.Empty;
    public string LocationLon { get; set; } = string.Empty;
    public IEnumerable<SectorModel> Sectors { get; set; } = [];

    public void UpdateSector(SectorModel? sector)
    {
        if(sector != null && Sectors.Any(x => x.Id == sector.Id))
        {
            // var list = Sectors.ToList();
            // list.RemoveAll(x => x.Id == sector!.Id);
            // list.Add(
            //     new (
            //         sector.Id,
            //         sector.Name,
            //         sector.Price,
            //         sector.Seats = SeatsHelper.GenerateSeats(sector.)
            //     )
            // );
            var newSector = Sectors.First(x => x.Id == sector.Id);
            newSector.Name = sector.Name;
            newSector.Price = sector.Price;
            newSector.Seats = sector.Seats;
        }
    }
}