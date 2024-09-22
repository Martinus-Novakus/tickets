namespace TicketingSample.ViewModels.Error;

public class Error400ViewModel : ErrorViewModelBase
{
    public Error400ViewModel()
    {
    }

    public override string Title { get; set; } = "Požiadavka zamietnutá";
    public override string SubTitle { get; set; } = "Vami zadané údaje sú neplatné.";
    public override int StatusCode { get; set; } = 400;
}