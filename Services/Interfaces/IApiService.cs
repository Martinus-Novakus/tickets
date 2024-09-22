namespace TicketingSample.Services;

///<summary>
///Sluzba zastresujuca zakladne API funkcie
///</summary>
public interface IApiService
{
    public Task<Stream> GetAsync(string path, CancellationToken cancellationToken);
}