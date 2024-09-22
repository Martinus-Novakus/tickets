namespace TicketingSample.Services;

public interface IApiService
{
    // public Task<string> GetAsync(string path, CancellationToken cancellationToken);
    public Task<Stream> GetAsync(string path, CancellationToken cancellationToken);
}