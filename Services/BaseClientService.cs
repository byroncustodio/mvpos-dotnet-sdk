namespace MvposSDK.Services;

public class BaseClientService
{
    public HttpClient HttpClient { get; }
    public string SessionCookie { get; }

    protected BaseClientService(HttpClient httpClient)
    {
        HttpClient = httpClient;
        HttpClient.BaseAddress = new Uri("https://app.mvpofsales.com/");
        SessionCookie = Guid.NewGuid().ToString().Replace("-", "")[..26];
    }
}
