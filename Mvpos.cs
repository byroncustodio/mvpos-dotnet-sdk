using MvposSDK.Services;

namespace MvposSDK;

public class Mvpos
{
    public VendorService Vendors { get; }
    public SaleItemService SaleItems { get; }
    public UserService Users { get; }
    
    private readonly HttpClient _httpClient;
    
    public Mvpos(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://app.mvpofsales.com/");

        Vendors = new VendorService(new BaseClientService(_httpClient));
        SaleItems = new SaleItemService(new BaseClientService(_httpClient));
        Users = new UserService(new BaseClientService(_httpClient));
    }
}
