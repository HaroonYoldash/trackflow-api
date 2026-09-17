using TrackFlow.Api.Models;

namespace TrackFlow.Api.Data;

public static class DbInitializer
{
    public static void Initialize(AppDbContext context)
    {
        if (context.Assets.Any())
        {
            return; 
        }

        var assets = new Asset[]
        {
            new Asset
            {
                Name = "MacBook Pro 16\"",
                SerialNumber = "APL-MBP-9021",
                Category = "Laptop",
                PurchaseCost = 2399.00m,
                IsAssigned = true,
                AssignedTo = "Sarah Connor"
            },
            new Asset
            {
                Name = "Dell UltraSharp 27\" 4K",
                SerialNumber = "DEL-U27-4410",
                Category = "Monitor",
                PurchaseCost = 549.50m,
                IsAssigned = true,
                AssignedTo = "Alex Murphy"
            },
            new Asset
            {
                Name = "Lenovo ThinkPad X1 Carbon",
                SerialNumber = "LNV-X1C-3382",
                Category = "Laptop",
                PurchaseCost = 1450.00m,
                IsAssigned = false,
                AssignedTo = null
            },
            new Asset
            {
                Name = "Logitech MX Master 3S",
                SerialNumber = "LOG-MX3-8812",
                Category = "Peripherals",
                PurchaseCost = 119.99m,
                IsAssigned = false,
                AssignedTo = null
            },
            new Asset
            {
                Name = "Dell Latitude 5540",
                SerialNumber = "DEL-LAT-1049",
                Category = "Laptop",
                PurchaseCost = 899.00m,
                IsAssigned = false,
                AssignedTo = null
            }
        };

        context.Assets.AddRange(assets);
        context.SaveChanges();
    }
}