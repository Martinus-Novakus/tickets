namespace TicketingSample.DomainEntities;

public class SeatModel : EntityBaseModel
{
    public SeatModel(int id, int rowId, int seatId, bool reserved) : base(id)
    {
        RowId = rowId;
        SeatId = seatId;
        Reserved = reserved;
    }

    public int RowId { get; set; }
    public int SeatId { get; set; }
    public bool Reserved { get; set; }
}