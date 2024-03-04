using System.Net;
using MvposSDK.Models;
using Newtonsoft.Json;

namespace MvposSDK.Services;

public class VendorService
{
    private readonly BaseClientService _service;

    public VendorService(BaseClientService service) => _service = service;

    public async Task<Vendor> Get(int id)
    {
        var endpoint = $"api/v1/vendors/{id.ToString()}";
        
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
            throw new HttpRequestException(await httpResponse.Content.ReadAsStringAsync());
        }

        var content = await httpResponse.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Vendor>(content) ?? throw new JsonException("Deserialized JSON resulted in null value.");
    }
}
