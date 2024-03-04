using System.Net;
using MvposSDK.Models.MVPOS;
using Newtonsoft.Json;

namespace MvposSDK.Services;

public class SaleItemService
{
    private readonly BaseClientService _service;

    public SaleItemService(BaseClientService service) => _service = service;

    public async Task<SaleItems> GetByDateRange(DateTime from, DateTime to)
    {
        const string endpoint = "api/v1/saleitems/date";
        var queryParams = $"start_date={from:d}&end_date={to:d}";
        
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

        var content = await httpResponse.Content.ReadAsStringAsync();
        Console.WriteLine(content);
        return JsonConvert.DeserializeObject<SaleItems>(content) ?? throw new JsonException("Deserialized JSON resulted in null value.");
    }
}
