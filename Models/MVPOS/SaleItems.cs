using Newtonsoft.Json;

namespace MvposSDK.Models.MVPOS;

public class SaleItems
{
    [JsonProperty("sale_items")]
    public List<SaleItem>? Items { get; set; }

    [JsonProperty("start_date")]
    public DateTime StartDate { get; set; }

    [JsonProperty("end_date")]
    public DateTime EndDate { get; set; }
}

public class SaleItem
{
    [JsonProperty("sale_id")]
    public int SaleId { get; set; }

    [JsonProperty("sale_date")]
    public DateTime SaleDate { get; set; }

    [JsonProperty("payment_method")]
    public Payment Payment { get; set; } = new();

    [JsonProperty("client_location_id")]
    public int LocationId { get; set; }

    [JsonProperty("item_number")]
    public string? Sku { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("description")]
    public string? Description { get; set; }

    [JsonProperty("price")]
    public decimal Price { get; set; }

    [JsonProperty("quantity")]
    public int Quantity { get; set; }

    [JsonProperty("subtotal")]
    public decimal SubTotal { get; set; }

    [JsonProperty("discount_percentage")]
    public decimal Discount { get; set; }

    [JsonProperty("tax_amount")]
    public decimal Tax { get; set; }

    [JsonProperty("final_cost")]
    public decimal Total { get; set; }
    
    [JsonProperty("vendor_company")]
    public string? VendorCompany { get; set; }
}

public class Payment
{
    [JsonProperty("id")]
    public int? Id { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("order")]
    public string? Order { get; set; }
}