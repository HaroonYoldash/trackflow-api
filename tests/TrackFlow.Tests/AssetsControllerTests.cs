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
    private AppDbContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public async Task GetAll_WhenNoAssetsExist_ReturnsEmptyList()
    {
        var context = CreateDbContext();
        var controller = new AssetsController(context);

        var result = await controller.GetAll();

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var assets = Assert.IsAssignableFrom<IEnumerable<Asset>>(okResult.Value);
        Assert.Empty(assets);
    }

    [Fact]
    public async Task Create_ValidAsset_PersistsAndReturnsCreated()
    {
        var context = CreateDbContext();
        var controller = new AssetsController(context);
        var dto = new CreateAssetDto
        {
            Name = "Dell Monitor 24",
            SerialNumber = "DL-1002",
            Category = "Monitor",
            PurchaseCost = 189.99m,
            IsAssigned = false,
            AssignedTo = null
        };

        var result = await controller.Create(dto);

        var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        var returnedAsset = Assert.IsType<Asset>(createdResult.Value);

        Assert.Equal("Dell Monitor 24", returnedAsset.Name);
        Assert.Equal(1, await context.Assets.CountAsync());
    }
}