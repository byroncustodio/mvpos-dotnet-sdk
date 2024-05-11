using MvposSDK.Services;

namespace MvposSDK;

public class Mvpos : BaseService
{
    public VendorService Vendors { get; }
    public SaleItemService SaleItems { get; }
    public UserService Users { get; }
    public ClientService Clients { get; }

    public Mvpos(HttpClient httpClient) : base(httpClient)
    {
        Vendors = new VendorService(this);
        SaleItems = new SaleItemService(this);
        Users = new UserService(this);
        Clients = new ClientService(this);
    }
    
    public enum StoreLocation
    {
        Gastown = 212,
        Kitsilano = 213,
        [System.ComponentModel.Description("North Vancouver")]
        NorthVancouver = 214,
        Victoria = 215,
        Metrotown = 216,
        Guildford = 217,
        Mapleview = 252, // Previously Tsawwassen Mills
        Richmond = 253,
        [System.ComponentModel.Description("Park Royal")]
        ParkRoyal = 261,
        Southgate = 262,
        [System.ComponentModel.Description("West Edmonton")]
        WestEdmonton = 314,
    }
}
