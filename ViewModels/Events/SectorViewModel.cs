using TicketingSample.Features.Events.Get;

namespace TicketingSample.ViewModels.Events;

public class SectorViewModel
{
    public SectorViewModel()
    {
    }

    public SectorViewModel(SectorResponseDTO sector)
    {
        SectorId = sector.Id;
        SetSeats(sector);
    }

    public int SectorId { get; set; }
    public IEnumerable<SeatResponseDTO> Seats { get; set; } = [];
    public IDictionary<int, bool> SelectedSeats { get; set; } = new Dictionary<int, bool>();

    public void SetSeats(SectorResponseDTO sector)
    {
        Seats = sector.Seats ?? [];
        SelectedSeats = new Dictionary<int, bool>(Seats.Select(x => new KeyValuePair<int, bool>(x.Id, false)));
    }
}