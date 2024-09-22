using TicketingSample.DomainEntities;
using TicketingSample.Features.Events.Get;

namespace TicketingSample.Helpers;

public static class SeatsHelper
{
    private static readonly Random _random = new();
    private static readonly int _maxRows = 15;
    private static readonly int _maxSeats = 30;

    ///<summary>
    ///Vygenerovanie sedadiel sektora podla zadanych vstupov
    ///</summary>
    public static List<SeatModel> GenerateSeats(int rowCount, int seatCount, bool randomOccupation = false)
    {
        var result = new List<SeatModel>();
        var index = 1;
        foreach(var rowId in Enumerable.Range(1, rowCount).ToList())
        {
            foreach(var seatId in Enumerable.Range(1, seatCount).ToList())
            {
                result.Add(new SeatModel(index, rowId, seatId, randomOccupation && _random.Next(1, 100) < 30));
                index++;
            }
        }
        return result;
    }

    ///<summary>
    ///Vygenerovanie sedadiel sektora nahodne
    ///</summary>
    public static List<SeatModel> GenerateRandomSeats()
        => GenerateSeats(
            _random.Next(1, _maxRows),
            _random.Next(1, _maxSeats),
            true
        );

    ///<summary>
    ///Ziskanie poctu radov zo zoznamu sedadiel sektora
    ///</summary>
    public static int GetRowCount(IEnumerable<SeatResponseDTO> seats)
        => seats.Select(x => x.RowId).Distinct().Count();

    ///<summary>
    ///Ziskanie poctu sedadiel zo zoznamu sedadiel sektora
    ///</summary>
    public static int GetSeatCount(IEnumerable<SeatResponseDTO> seats)
        => seats.Select(x => x.SeatId).Distinct().Count();
}