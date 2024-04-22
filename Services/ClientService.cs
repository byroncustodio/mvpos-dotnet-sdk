using System.Net;
using MvposSDK.Models;
using Newtonsoft.Json;

namespace MvposSDK.Services;

public class ClientService
{
    private readonly BaseService _service;

    public ClientService(BaseService service) => _service = service;

    public async Task<Clients> Get(int id)
    {
        var endpoint = $"api/v1/clients/{id}";
        
        HttpRequestMessage httpRequest = new()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"{endpoint}", UriKind.Relative),
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
        return JsonConvert.DeserializeObject<Clients>(content) ?? throw new JsonException("Deserialized JSON resulted in null value.");
    }
}