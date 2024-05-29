using System.Diagnostics;
using Newtonsoft.Json;

namespace MvposSDK.Tests;

public class Tests
{
    private Mvpos? _mvpos;

    private const string Email = "";

    private const string Password = "";
    
    [SetUp]
    public void Setup()
    {
        _mvpos = new Mvpos(new HttpClient());
    }

    [Test]
    public async Task TestUser_Login()
    {
        Debug.Assert(_mvpos != null, nameof(_mvpos) + " != null");
        await _mvpos.Users.Login(Email, Password);
    }

    [Test]
    public async Task TestUser_SetStoreLocation()
    {
        var location = Mvpos.StoreLocation.Mapleview;
        
        Debug.Assert(_mvpos != null, nameof(_mvpos) + " != null");
        await TestUser_Login();

        await _mvpos.Users.SetStoreLocation(location);
    }
    
    [Test]
    public async Task TestSaleItem_List()
    {
        var from = new DateTime(2024, 4, 1);
        var to = new DateTime(2024, 4, 30);
        
        Debug.Assert(_mvpos != null, nameof(_mvpos) + " != null");
        await TestUser_SetStoreLocation();

        var a = (await _mvpos.SaleItems.ListAll(from, to)).Items;
        var b = a.GroupBy(x => x.VendorCompany)
            .Select(y => new
            {
                Vendor = y.First().VendorCompany,
                Sales = y.Count(),
                Profit = y.Sum(z => z.Total)
            })
            .ToList();

        var c = JsonConvert.SerializeObject(b);
        
        await Assert.ThatAsync(async () => (await _mvpos.SaleItems.List(from, to)).Items.Count, Is.GreaterThan(0));
    }
}