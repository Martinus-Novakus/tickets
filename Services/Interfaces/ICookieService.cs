namespace TicketingSample.Services;

///<summary>
///Genericka sluzba zastresujuca pracu s cookies
///</summary>
public interface ICookieService<T> where T : class
{
    public T? Get();
    public void Update(T basket);
}