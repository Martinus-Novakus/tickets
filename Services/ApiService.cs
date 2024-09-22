namespace TicketingSample.Services;

public class ApiService : IApiService
{
    private readonly HttpClient _client;

    public ApiService(
        HttpClient client
    )
    {
        _client = client;
    }

    public async Task<Stream> GetAsync(string path, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync(path, cancellationToken);
        return await response.Content.ReadAsStreamAsync(cancellationToken);
    }
}