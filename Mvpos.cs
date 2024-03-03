namespace MvposSDK;

public class Mvpos
{
    private readonly HttpClient _httpClient;
    
    public Mvpos(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("");
    }
}
