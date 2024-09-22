namespace TicketingSample.Exceptions;

///<summary>
///Exception, vdaka ktorej mozem posuvat stav 404 cez exception handler a nemusel ho manualne vzdy vracat
///</summary>
public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string message) : base(message) { }
}

public class EntityNotFoundException<T> : EntityNotFoundException
{
    public EntityNotFoundException() : base($"Entity of type {typeof(T)} was not found.")
    {
    }
}