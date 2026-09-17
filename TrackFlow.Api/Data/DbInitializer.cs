using TrackFlow.Api.Models;

namespace TrackFlow.Api.Data;

public static class DbInitializer
{
    public static void Initialize(AppDbContext context)
    {
        context.Database.EnsureCreated();

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
                PurchaseCost = 2499.00m,
                IsAssigned = true,
                AssignedTo = "Sarah Connor"
            },
            new Asset
            {
                Name = "Dell UltraSharp 27\"",
                SerialNumber = "DEL-U27-3312",
                Category = "Monitor",
                PurchaseCost = 489.50m,
                IsAssigned = false,
                AssignedTo = null
            },
            new Asset
            {
                Name = "Lenovo ThinkPad X1",
                SerialNumber = "LEN-TP-1104",
                Category = "Laptop",
                PurchaseCost = 1450.00m,
                IsAssigned = false,
                AssignedTo = null
            },
            new Asset
            {
                Name = "Apple Magic Keyboard",
                SerialNumber = "APL-KB-7781",
                Category = "Accessory",
                PurchaseCost = 99.00m,
                IsAssigned = true,
                AssignedTo = "John Doe"
            }
        };

        context.Assets.AddRange(assets);
        context.SaveChanges();
    }
}