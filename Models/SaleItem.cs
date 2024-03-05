using MvposSDK.Extensions;
using Newtonsoft.Json;

namespace MvposSDK.Models;

public partial class SaleItem
{
    [JsonProperty("id")]
    public int Id { get; set; }
    
    [JsonProperty("sale_id")]
    public int SaleId { get; set; }
    
    [JsonProperty("vendor_id")]
    public int VendorId { get; set; }

    [JsonProperty("client_location_id")]
    public int LocationId { get; set; }

    public string LocationName => Common.GetDescription((Mvpos.StoreLocation)LocationId);

    [JsonProperty("item_id")]
    public int? ItemId { get; set; }
    
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
    
    [JsonProperty("sale_date")]
    public DateTime SaleDate { get; set; }

    [JsonProperty("vendor_company")]
    public string? VendorCompany { get; set; }
    
    [JsonProperty("vendor_code")]
    public string? VendorCode { get; set; }
    
    [JsonProperty("payment_method")]
    public PaymentMethod Payment { get; set; } = new();
    
}
