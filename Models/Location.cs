using Newtonsoft.Json;

namespace MvposSDK.Models;

public class Location
{
    public Location() { }

    public Location(Location location)
    {
        Id = location.Id;
        ClientId = location.ClientId;
        Name = location.Name;
        EmailAddress = location.EmailAddress;
        Timezone = location.Timezone;
    }

    [JsonProperty("id")]
    public readonly int Id;

    [JsonProperty("client_id")]
    public readonly int ClientId;

    [JsonProperty("name")]
    public readonly string? Name;

    [JsonProperty("contact_email_address")]
    public readonly string? EmailAddress;

    [JsonProperty("timezone")]
    public readonly string? Timezone;
}