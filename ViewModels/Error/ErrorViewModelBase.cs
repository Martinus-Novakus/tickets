namespace TicketingSample.ViewModels.Error;

public abstract class ErrorViewModelBase
{
    public abstract string Title { get; set; }
    public abstract string SubTitle { get; set; }
    public abstract int StatusCode { get; set; }
}