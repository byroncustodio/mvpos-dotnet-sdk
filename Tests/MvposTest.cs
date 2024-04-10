using System.Diagnostics;

namespace MvposSDK.Tests;

public class Tests
{
    private Mvpos? _mvpos;

    private const string Email = "mirusakii@gmail.com";

    private const string Password = "Sakura780";
    
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
        var location = Mvpos.StoreLocation.Guildford;
        
        Debug.Assert(_mvpos != null, nameof(_mvpos) + " != null");
        await TestUser_Login();

        await _mvpos.Users.SetStoreLocation(location);
    }
    
    [Test]
    public async Task TestSaleItem_List()
    {
        var from = new DateTime(2024, 1, 1);
        var to = new DateTime(2024, 1, 31);
        
        Debug.Assert(_mvpos != null, nameof(_mvpos) + " != null");
        await TestUser_SetStoreLocation();

        await Assert.ThatAsync(async () => (await _mvpos.SaleItems.List(from, to)).Items.Count, Is.GreaterThan(0));
    }
}