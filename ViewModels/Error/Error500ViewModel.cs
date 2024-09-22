namespace TicketingSample.ViewModels.Error;

public class Error500ViewModel : ErrorViewModelBase
{
    public Error500ViewModel()
    {
    }

    public override string Title { get; set; } = "Nastala chyba";
    public override string SubTitle { get; set; } = "Niečo sa pokazilo. Skúste to prosím neskôr, alebo kontaktujte administrátora.";
    public override int StatusCode { get; set; } = 500;
}