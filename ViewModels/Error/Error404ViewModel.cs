namespace TicketingSample.ViewModels.Error;

public class Error404ViewModel : ErrorViewModelBase
{
    public Error404ViewModel()
    {
    }

    public override string Title { get; set; } = "Stránka nenájdená";
    public override string SubTitle { get; set; } = "Klikli ste na zlý odkaz, alebo ste zadali neplatnú URL adresu.";
    public override int StatusCode { get; set; } = 404;
}