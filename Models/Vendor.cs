using Newtonsoft.Json;

namespace MvposSDK.Models;

public class Vendor
{
    [JsonProperty("id")]
    public int Id { get; set; }
    
    [JsonProperty("user_id")]
    public int UserId { get; set; }
    
    [JsonProperty("client_location_id")]
    public int LocationId { get; set; }
    
    [JsonProperty("code")]
    public string? Code { get; set; }
    
    [JsonProperty("name")]
    public string? Name { get; set; }
    
    [JsonProperty("company")]
    public string? Company { get; set; }
    
    [JsonProperty("email_address")]
    public string? Email { get; set; }
    
    [JsonProperty("active")]
    public int Active { get; set; }
}
