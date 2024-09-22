
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TicketingSample.Features.Events.Get;
using TicketingSample.Helpers;

namespace TicketingSample.ViewModels.Manage;

public class UpdateSectorViewModel
{
    public UpdateSectorViewModel()
    {
    }

    public UpdateSectorViewModel(
        SectorResponseDTO sector
    )
    {
        Id = sector.Id;
        Name = sector.Name;
        Price = sector.Price;
        RowCount = SeatsHelper.GetRowCount(sector.Seats);
        SeatsPerRow = SeatsHelper.GetSeatCount(sector.Seats);
    }

    [DisplayName("Výber sektora")]
    public int Id { get; set; }

    [DisplayName("Cena lístka"),
    Required(ErrorMessage = Constants.ValidationMessages.Required), 
    Range(1,1000000, ErrorMessage = Constants.ValidationMessages.Range)]
    public decimal? Price { get; set; }

    [DisplayName("Názov sektora"),
    Required(ErrorMessage = Constants.ValidationMessages.Required), 
    MaxLength(100, ErrorMessage = Constants.ValidationMessages.MaxLength)]
    public string Name { get; set; } = string.Empty;

    [DisplayName("Počet radov sektora"),
    Required(ErrorMessage = Constants.ValidationMessages.Required),
    Range(1,100, ErrorMessage = Constants.ValidationMessages.Range)]
    public int? RowCount { get; set; }

    [DisplayName("Počet sedadiel v rade"),
    Required(ErrorMessage = Constants.ValidationMessages.Required),
    Range(1,100, ErrorMessage = Constants.ValidationMessages.Range)]
    public int? SeatsPerRow { get; set; }
}