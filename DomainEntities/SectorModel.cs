namespace TicketingSample.DomainEntities;

///<summary>
///Core model pre sektor podujatia
///</summary>
public class SectorModel : EntityBaseModel
{
    public SectorModel(int id, string name, decimal price, IEnumerable<SeatModel> seats) : base(id)
    {
        Name = name;
        Price = price;
        Seats = seats;
    }

    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public IEnumerable<SeatModel> Seats { get; set; } = [];
}