namespace MvposSDK.Services;

public class BaseService
{
    public HttpClient HttpClient { get; }
    public string SessionCookie { get; }

    protected BaseService(HttpClient httpClient)
    {
        HttpClient = httpClient;
        HttpClient.BaseAddress = new Uri("https://app.mvpofsales.com/");
        // SessionCookie = Guid.NewGuid().ToString().Replace("-", "")[..26];
        SessionCookie = "PHPSESSID=n1bafi5nj9i63vl1a9nlvv3ip6";
    }
}
