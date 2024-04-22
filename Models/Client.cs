using Newtonsoft.Json;

namespace MvposSDK.Models;

public class Client
{
    public Client() { }

    public Client(Client client)
    {
        Id = client.Id;
        Name = client.Name;
        Locations = client.Locations;
    }

    [JsonProperty("id")]
    public readonly int Id;

    [JsonProperty("name")]
    public readonly string? Name;

    [JsonProperty("locations")]
    public readonly IEnumerable<Location>? Locations;
}