using MediatR;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TicketingSample.Exceptions;
using TicketingSample.ViewModels.Error;

namespace TicketingSample.Pages;

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
[IgnoreAntiforgeryToken]
public class ErrorModel : PageBase<ErrorModel>
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

    public ErrorModel(ILogger<ErrorModel> logger, IMediator mediator) : base(logger, mediator)
    {
    }

    public ErrorViewModelBase Model { get; set; } = null!;

    public void OnGet() => HandleError();
    public void OnPost() => HandleError();    

    protected void HandleError()
        => SetModel(HttpContext.Features.Get<IExceptionHandlerPathFeature>()?.Error);

    protected void SetModel(Exception? ex)
    {
        _logger.LogError(ex, "Error was caught in an exception handler");

        Model = ex switch {
            FluentValidation.ValidationException => new Error400ViewModel(),
            EntityNotFoundException => new Error404ViewModel(),
            null =>  new Error404ViewModel(),
            _ => new Error500ViewModel()
        };
    }
}

