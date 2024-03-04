namespace MvposSDK.Services;

public class BaseClientService
{
    public HttpClient HttpClient { get; set; }
    
    public BaseClientService(HttpClient httpClient) => HttpClient = httpClient;
}
