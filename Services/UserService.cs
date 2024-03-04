using System.Net;

namespace MvposSDK.Services;

public class UserService
{
    private readonly BaseClientService _service;

    public UserService(BaseClientService service) => _service = service;
    
    public async Task Login(string email, string password)
    {
        const string endpoint = "api/v1/users/login";
        var queryParams = $"email_address={email}&password={password}&password_reset_token=";

        HttpRequestMessage httpRequest = new()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"{endpoint}?{queryParams}", UriKind.Relative),
            Headers =
            {
                { HttpRequestHeader.Cookie.ToString(), _service.SessionCookie }
            }
        };

        using var httpResponse = await _service.HttpClient.SendAsync(httpRequest);
        
        if (!httpResponse.IsSuccessStatusCode) 
        {
            throw new HttpRequestException(await httpResponse.Content.ReadAsStringAsync());
        }
    }
    
    public async Task SetStoreLocation(StoreLocation location)
    {
        const string endpoint = "api/v1/users/changeactiveclientlocation";

        HttpRequestMessage httpRequest = new()
        {
            Method = HttpMethod.Put,
            RequestUri = new Uri(endpoint, UriKind.Relative),
            Headers =
            {
                { HttpRequestHeader.Cookie.ToString(), _service.SessionCookie }
            },
            Content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new("client_location_id", ((int)location).ToString())
            })
        };

        using var httpResponse = await _service.HttpClient.SendAsync(httpRequest);
        
        if (!httpResponse.IsSuccessStatusCode) 
        {
            throw new HttpRequestException(await httpResponse.Content.ReadAsStringAsync());
        }
    }
    
    public enum StoreLocation
    {
        Gastown = 212,
        Kitsilano = 213,
        NorthVancouver = 214,
        Victoria = 215,
        Metrotown = 216,
        Guildford = 217,
        Tsawwassen = 252,
        Richmond = 253,
        ParkRoyal = 261,
        Southgate = 262
    }
}
