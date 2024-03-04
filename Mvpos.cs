using MvposSDK.Services;

namespace MvposSDK;

public class Mvpos : BaseClientService
{
    public VendorService Vendors { get; }
    public SaleItemService SaleItems { get; }
    public UserService Users { get; }

    public Mvpos(HttpClient httpClient) : base(httpClient)
    {
        Vendors = new VendorService(this);
        SaleItems = new SaleItemService(this);
        Users = new UserService(this);
    }
}
