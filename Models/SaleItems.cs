using Newtonsoft.Json;

namespace MvposSDK.Models;

public class SaleItems
{
    [JsonProperty("sale_items")]
    public List<SaleItem> Items { get; set; } = new();

    [JsonProperty("start_date")]
    public DateTime StartDate { get; set; }

    [JsonProperty("end_date")]
    public DateTime EndDate { get; set; }
}