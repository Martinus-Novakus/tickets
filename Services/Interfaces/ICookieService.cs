namespace TicketingSample.Services;

public interface ICookieService<T> where T : class
{
    public T? Get();
    public void Update(T basket);
}