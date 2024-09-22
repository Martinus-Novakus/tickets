namespace TicketingSample.DomainEntities;

///<summary>
///Core model pre polozku kosika - zoskupuje vybrane podujatie, sektor, rad, sedadlo a cenu listka v case vyberu
///</summary>
public class BasketItemModel
{
    public int EventId { get; set; }
    public int SectorId { get; set; }
    public int RowId { get; set; }
    public int SeatId { get; set; }
    public decimal Price { get; set; }
}