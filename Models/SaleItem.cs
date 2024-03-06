using MvposSDK.Extensions;
using Newtonsoft.Json;

namespace MvposSDK.Models;

public class SaleItem
{
    public SaleItem(SaleItem saleItem)
    {
        Id = saleItem.Id;
        SaleId = saleItem.SaleId;
        VendorId = saleItem.VendorId;
        LocationId = saleItem.LocationId;
        ItemId = saleItem.ItemId;
        Sku = saleItem.Sku;
        Name = saleItem.Name;
        Description = saleItem.Description;
        Price = saleItem.Price;
        Quantity = saleItem.Quantity;
        SubTotal = saleItem.SubTotal;
        Discount = saleItem.Discount;
        Tax = saleItem.Tax;
        Total = saleItem.Total;
        SaleDate = saleItem.SaleDate;
        VendorCompany = saleItem.VendorCompany;
        VendorCode = saleItem.VendorCode;
    }

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
