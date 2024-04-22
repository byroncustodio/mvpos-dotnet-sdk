using Newtonsoft.Json;

namespace MvposSDK.Models;

public class Clients
{
    public Clients(Client client)
    {
        Client = client;
    }

    [JsonProperty("client")]
    public Client Client { get; set; }
}