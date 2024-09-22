namespace TicketingSample.Exceptions;

public class HttpContextUnavailableException : Exception
{
    public HttpContextUnavailableException() : base("Unable to get current HTTP context.") { }
}