namespace TicketingSample.Exceptions;

///<summary>
///Exception, ktora moze nastat, ked HttpContextAccessor nevrati kontext - za beznych okolnosti by sa nemalo stavat...
///</summary>
public class HttpContextUnavailableException : Exception
{
    public HttpContextUnavailableException() : base("Unable to get current HTTP context.") { }
}