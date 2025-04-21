namespace MvposSDK.Services;

public class BaseService
{
    public HttpClient HttpClient { get; }
    public string SessionCookie { get; }

    protected BaseService(HttpClient httpClient)
    {
        HttpClient = httpClient;
        HttpClient.BaseAddress = new Uri("https://shopmakers.mvpofsales.com/");
        SessionCookie = Guid.NewGuid().ToString().Replace("-", "")[..26];
    }
}
