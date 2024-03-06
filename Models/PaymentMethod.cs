using Newtonsoft.Json;

namespace MvposSDK.Models;

public class PaymentMethod
{
    [JsonProperty("id")]
    public int? Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = "N/A";

    [JsonProperty("order")]
    public string? Order { get; set; }
}
