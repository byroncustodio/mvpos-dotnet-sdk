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
    public int Id;

    [JsonProperty("name")]
    public string? Name;

    [JsonProperty("locations")]
    public IEnumerable<Location>? Locations;
}