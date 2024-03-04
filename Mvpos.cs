using MvposSDK.Services;

namespace MvposSDK;

public abstract class Mvpos
{
    public VendorService Vendors { get; }
    public SaleItemService SaleItems { get; }
    public UserService Users { get; }

    protected Mvpos(HttpClient httpClient)
    {
        var service = new BaseClientService(httpClient);
        
        Vendors = new VendorService(service);
        SaleItems = new SaleItemService(service);
        Users = new UserService(service);
    }
}
