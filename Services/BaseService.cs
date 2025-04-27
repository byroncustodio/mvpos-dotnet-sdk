namespace MvposSDK.Services;

public class BaseService
{
    public HttpClient HttpClient { get; }
    public string SessionCookie { get; }

    protected BaseService(HttpClient httpClient)
    {
        HttpClient = httpClient;
        HttpClient.BaseAddress = new Uri("https://shopmakers.mvpofsales.com/");
        HttpClient.Timeout = TimeSpan.FromSeconds(600);
        SessionCookie = Guid.NewGuid().ToString().Replace("-", "")[..26];
    }
}
