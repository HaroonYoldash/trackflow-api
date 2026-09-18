using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackFlow.Api.Controllers;
using TrackFlow.Api.Data;
using TrackFlow.Api.DTOs;
using TrackFlow.Api.Models;
using Xunit;

namespace TrackFlow.Tests;

public class AssetsControllerTests
{
    private AppDbContext CreateInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        var context = new AppDbContext(options);
        context.Database.EnsureCreated();
        return context;
    }

    [Fact]
    public async Task GetAssets_ReturnsAllAssets()
    {
        using var context = CreateInMemoryDbContext();
        context.Assets.Add(new Asset { Name = "Test Laptop", SerialNumber = "TL-01", Category = "Laptop", PurchaseCost = 1000m });
        context.Assets.Add(new Asset { Name = "Test Monitor", SerialNumber = "TM-01", Category = "Monitor", PurchaseCost = 300m });
        await context.SaveChangesAsync();

        var controller = new AssetsController(context);

        var result = await controller.GetAssets();

        Assert.Equal(2, result.Value?.Count());
    }

    [Fact]
    public async Task CreateAsset_AddsAssetAndHistoryLog()
    {
        using var context = CreateInMemoryDbContext();
        var controller = new AssetsController(context);
        var dto = new CreateAssetDto
        {
            Name = "Dell XPS",
            SerialNumber = "DX-999",
            Category = "Laptop",
            PurchaseCost = 1200m
        };

        var result = await controller.CreateAsset(dto);

        var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        var asset = Assert.IsType<Asset>(createdResult.Value);
        Assert.Equal("Dell XPS", asset.Name);
        Assert.Single(context.AssetHistories);
        Assert.Equal("Created", context.AssetHistories.First().Action);
    }

    [Fact]
    public async Task AssignAsset_ReturnsConflict_WhenAlreadyAssigned()
    {
        using var context = CreateInMemoryDbContext();
        var asset = new Asset
        {
            Name = "Booked Device",
            SerialNumber = "BK-123",
            Category = "Laptop",
            PurchaseCost = 800m,
            IsAssigned = true,
            AssignedTo = "Existing User"
        };
        context.Assets.Add(asset);
        await context.SaveChangesAsync();

        var controller = new AssetsController(context);
        var dto = new AssignAssetDto { AssignedTo = "New User" };

        var result = await controller.AssignAsset(asset.Id, dto);

        Assert.IsType<ConflictObjectResult>(result);
    }

    [Fact]
    public async Task ReturnAsset_ClearsAssignmentAndLogsHistory()
    {
        using var context = CreateInMemoryDbContext();
        var asset = new Asset
        {
            Name = "Returnable Device",
            SerialNumber = "RT-456",
            Category = "Laptop",
            PurchaseCost = 900m,
            IsAssigned = true,
            AssignedTo = "Someone"
        };
        context.Assets.Add(asset);
        await context.SaveChangesAsync();

        var controller = new AssetsController(context);

        var result = await controller.ReturnAsset(asset.Id);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var updatedAsset = Assert.IsType<Asset>(okResult.Value);
        Assert.False(updatedAsset.IsAssigned);
        Assert.Null(updatedAsset.AssignedTo);
        Assert.Contains(context.AssetHistories, h => h.Action == "Returned");
    }
}