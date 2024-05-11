using System.Net;
using MvposSDK.Models;
using Newtonsoft.Json;

namespace MvposSDK.Services;

public class SaleItemService
{
    private readonly BaseService _service;

    public SaleItemService(BaseService service) => _service = service;

    public async Task<SaleItems> List()
    {
        const string endpoint = "api/v1/vendors/0/saleitems/date";
        
        HttpRequestMessage httpRequest = new()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(endpoint, UriKind.Relative),
            Headers =
            {
                { HttpRequestHeader.Cookie.ToString(), _service.SessionCookie }
            }
        };

        using var httpResponse = await _service.HttpClient.SendAsync(httpRequest);
        
        if (!httpResponse.IsSuccessStatusCode)
        {
            throw new HttpRequestException(await httpResponse.Content.ReadAsStringAsync(), null, httpResponse.StatusCode);
        }

        var content = await httpResponse.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<SaleItems>(content) ?? throw new JsonException("Deserialized JSON resulted in null value.");
    }
    
    public async Task<SaleItems> List(DateTime from, DateTime to)
    {
        const string endpoint = "api/v1/vendors/0/saleitems/date";
        var queryParams = $"start_date={from:yyyy-MM-dd}&end_date={to:yyyy-MM-dd}";
        
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
            throw new HttpRequestException(await httpResponse.Content.ReadAsStringAsync(), null, httpResponse.StatusCode);
        }

        var content = await httpResponse.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<SaleItems>(content) ?? throw new JsonException("Deserialized JSON resulted in null value.");
    }
    
    public async Task<SaleItems> ListAll()
    {
        const string endpoint = "api/v1/saleitems/date";
        
        HttpRequestMessage httpRequest = new()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(endpoint, UriKind.Relative),
            Headers =
            {
                { HttpRequestHeader.Cookie.ToString(), _service.SessionCookie }
            }
        };

        using var httpResponse = await _service.HttpClient.SendAsync(httpRequest);
        
        if (!httpResponse.IsSuccessStatusCode)
        {
            throw new HttpRequestException(await httpResponse.Content.ReadAsStringAsync(), null, httpResponse.StatusCode);
        }

        var content = await httpResponse.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<SaleItems>(content) ?? throw new JsonException("Deserialized JSON resulted in null value.");
    }
    
    public async Task<SaleItems> ListAll(DateTime from, DateTime to)
    {
        const string endpoint = "api/v1/saleitems/date";
        var queryParams = $"start_date={from:yyyy-MM-dd}&end_date={to:yyyy-MM-dd}";
        
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
            throw new HttpRequestException(await httpResponse.Content.ReadAsStringAsync(), null, httpResponse.StatusCode);
        }

        var content = await httpResponse.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<SaleItems>(content) ?? throw new JsonException("Deserialized JSON resulted in null value.");
    }
}
