namespace MvposSDK.Services;

public class BaseClientService
{
    public HttpClient HttpClient { get; set; }
    
    public string SessionCookie { get; set; } = Guid.NewGuid().ToString().Replace("-", "")[..26];

    public BaseClientService(HttpClient httpClient)
    {
        HttpClient = httpClient;
        HttpClient.BaseAddress = new Uri("https://app.mvpofsales.com/");
    }
}
