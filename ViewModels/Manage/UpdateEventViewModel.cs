
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TicketingSample.Features.Events.Get;
using TicketingSample.Helpers;

namespace TicketingSample.ViewModels.Manage;

public class UpdateEventViewModel
{
    public UpdateEventViewModel()
    {
    }

    public UpdateEventViewModel(
        EventResponseDTO evnt,
        SectorResponseDTO sector
    )
    {
        Id = evnt.Id;
        Name = evnt.Name;
        PlaceName = evnt.PlaceName;
        StreetAndNumber = evnt.StreetAndNumber;
        City = evnt.City;
        Description = evnt.Description;
        EventStart = evnt.EventStart;
        EventReservationsEnd = evnt.EventReservationsEnd;
        
        SectorId = sector.Id;
        SectorName = sector.Name;
        Price = sector.Price;
        RowCount = SeatsHelper.GetRowCount(sector.Seats);
        SeatsPerRow = SeatsHelper.GetSeatCount(sector.Seats);
    }

    public int Id { get; set; }
    
    [DisplayName("Kategória podujatia"),
    Required(ErrorMessage = Constants.ValidationMessages.Required)]
    public int CategoryId { get; set; }

    [DisplayName("Názov podujatia"),
    Required(ErrorMessage = Constants.ValidationMessages.Required), 
    MaxLength(100, ErrorMessage = Constants.ValidationMessages.MaxLength)]
    public string Name { get; set; } = string.Empty;

    [DisplayName("Miesto podujatia"),
    Required(ErrorMessage = Constants.ValidationMessages.Required), 
    MaxLength(100, ErrorMessage = Constants.ValidationMessages.MaxLength)]
    public string PlaceName { get; set; } = string.Empty;

    [DisplayName("Ulica a číslo"),
    Required(ErrorMessage = Constants.ValidationMessages.Required), 
    MaxLength(255, ErrorMessage = Constants.ValidationMessages.MaxLength)]
    public string StreetAndNumber { get; set; } = string.Empty;
    
    [DisplayName("Mesto"),
    Required(ErrorMessage = Constants.ValidationMessages.Required), 
    MaxLength(50, ErrorMessage = Constants.ValidationMessages.MaxLength)]
    public string City { get; set; } = string.Empty;
    
    [DisplayName("Popis podujatia"),
    Required(ErrorMessage = Constants.ValidationMessages.Required), 
    MaxLength(5000, ErrorMessage = Constants.ValidationMessages.MaxLength)]
    public string Description { get; set; } = string.Empty;

    [DisplayName("Začiatok podujatia"),
    Required(ErrorMessage = Constants.ValidationMessages.Required)]
    public DateTime? EventStart { get; set; }

    [DisplayName("Koniec rezervácií"),
    Required(ErrorMessage = Constants.ValidationMessages.Required)]
    public DateTime? EventReservationsEnd { get; set; }    

    [DisplayName("Výber sektora")]
    public int SectorId { get; set; }

    [DisplayName("Cena lístka"),
    Required(ErrorMessage = Constants.ValidationMessages.Required), 
    Range(1,1000000, ErrorMessage = Constants.ValidationMessages.Range)]
    public decimal? Price { get; set; }

    [DisplayName("Názov sektora"),
    Required(ErrorMessage = Constants.ValidationMessages.Required), 
    MaxLength(100, ErrorMessage = Constants.ValidationMessages.MaxLength)]
    public string SectorName { get; set; } = string.Empty;

    [DisplayName("Počet radov sektora"),
    Required(ErrorMessage = Constants.ValidationMessages.Required),
    Range(1,100, ErrorMessage = Constants.ValidationMessages.Range)]
    public int? RowCount { get; set; }

    [DisplayName("Počet sedadiel v rade"),
    Required(ErrorMessage = Constants.ValidationMessages.Required),
    Range(1,100, ErrorMessage = Constants.ValidationMessages.Range)]
    public int? SeatsPerRow { get; set; }
}