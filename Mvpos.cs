using System.Net;
using MvposSDK.Models.MVPOS;
using Newtonsoft.Json;
using JsonException = System.Text.Json.JsonException;

namespace MvposSDK;

public class Mvpos
{
    private readonly HttpClient _httpClient;
    private readonly string _sessionCookie = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 26);
    
    public Mvpos(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://app.mvpofsales.com/");
    }

    public async Task Login(string email, string password)
    {
        const string endpoint = "api/v1/users/login";
        var queryParams = $"email_address={email}&password={password}&password_reset_token=";

        HttpRequestMessage httpRequest = new()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(string.Join("?", endpoint, queryParams), UriKind.Relative),
            Headers =
            {
                { HttpRequestHeader.Cookie.ToString(), _sessionCookie }
            }
        };

        using var httpResponse = await _httpClient.SendAsync(httpRequest);
        
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
                { HttpRequestHeader.Cookie.ToString(), _sessionCookie }
            },
            Content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new("client_location_id", ((int)location).ToString())
            })
        };

        using var httpResponse = await _httpClient.SendAsync(httpRequest);
        
        if (!httpResponse.IsSuccessStatusCode) 
        {
            throw new HttpRequestException(await httpResponse.Content.ReadAsStringAsync());
        }
    }
    
    public async Task<SaleItems> GetSaleItemsByDateRange(DateTime from, DateTime to)
    {
        const string endpoint = "api/v1/saleitems/date";
        var queryParams = "start_date=" + from.ToString("MM/dd/yyyy") + "&end_date=" + to.ToString("MM/dd/yyyy");

        HttpRequestMessage httpRequest = new()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(string.Join("?", endpoint, queryParams), UriKind.Relative),
            Headers =
            {
                { HttpRequestHeader.Cookie.ToString(), _sessionCookie }
            }
        };

        using var httpResponse = await _httpClient.SendAsync(httpRequest);
        
        if (!httpResponse.IsSuccessStatusCode)
        {
            throw new HttpRequestException(await httpResponse.Content.ReadAsStringAsync());
        }

        var content = await httpResponse.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<SaleItems>(content) ?? throw new JsonException("Deserialized JSON resulted in null value.");
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
