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
    
    public enum StoreLocation
    {
        Gastown = 212,
        Kitsilano = 213,
        NorthVancouver = 214,
        Victoria = 215,
        Metrotown = 216,
        Guildford = 217,
        Tsawwassen = 252,
        Richmond = 253,
        ParkRoyal = 261,
        Southgate = 262
    }
}
