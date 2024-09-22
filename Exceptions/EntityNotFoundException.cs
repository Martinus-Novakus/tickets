namespace TicketingSample.Exceptions;

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