namespace MvposSDK.Services;

public class BaseClientService
{
    public HttpClient HttpClient { get; set; }

    public readonly string SessionCookie = Guid.NewGuid().ToString().Replace("-", "")[..26];

    public BaseClientService(HttpClient httpClient) => HttpClient = httpClient;
}
