using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackFlow.Api.Data;
using TrackFlow.Api.DTOs;
using TrackFlow.Api.Models;

namespace TrackFlow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssetsController : ControllerBase
{
    private readonly AppDbContext _context;

    public AssetsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Asset>>> GetAssets()
    {
        return await _context.Assets.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Asset>> GetAsset(int id)
    {
        var asset = await _context.Assets.FindAsync(id);
        if (asset == null) return NotFound();
        return asset;
    }

    [HttpGet("{id}/history")]
    public async Task<ActionResult<IEnumerable<AssetHistory>>> GetAssetHistory(int id)
    {
        var exists = await _context.Assets.AnyAsync(a => a.Id == id);
        if (!exists) return NotFound("Asset not found.");

        var history = await _context.AssetHistories
            .Where(h => h.AssetId == id)
            .OrderByDescending(h => h.Timestamp)
            .ToListAsync();

        return Ok(history);
    }

    [HttpPost]
    public async Task<ActionResult<Asset>> CreateAsset(CreateAssetDto dto)
    {
        if (dto.PurchaseCost < 0)
            return BadRequest("Cost must be non-negative.");

        var asset = new Asset
        {
            Name = dto.Name,
            SerialNumber = dto.SerialNumber,
            Category = dto.Category,
            PurchaseCost = dto.PurchaseCost,
            IsAssigned = false,
            AssignedTo = null
        };

        _context.Assets.Add(asset);
        await _context.SaveChangesAsync();

        _context.AssetHistories.Add(new AssetHistory
        {
            AssetId = asset.Id,
            Action = "Created",
            PerformedBy = "Inventory Admin",
            Timestamp = DateTime.UtcNow
        });
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAsset), new { id = asset.Id }, asset);
    }

    [HttpPost("{id}/assign")]
    public async Task<IActionResult> AssignAsset(int id, AssignAssetDto dto)
    {
        var asset = await _context.Assets.FindAsync(id);
        if (asset == null) return NotFound("Asset not found.");

        if (asset.IsAssigned)
            return Conflict("Asset is already assigned.");

        asset.IsAssigned = true;
        asset.AssignedTo = dto.AssignedTo;

        _context.AssetHistories.Add(new AssetHistory
        {
            AssetId = asset.Id,
            Action = "Assigned",
            PerformedBy = dto.AssignedTo,
            Timestamp = DateTime.UtcNow
        });

        await _context.SaveChangesAsync();
        return Ok(asset);
    }

    [HttpPost("{id}/return")]
    public async Task<IActionResult> ReturnAsset(int id)
    {
        var asset = await _context.Assets.FindAsync(id);
        if (asset == null) return NotFound("Asset not found.");

        var previousHolder = asset.AssignedTo ?? "Unknown";

        asset.IsAssigned = false;
        asset.AssignedTo = null;

        _context.AssetHistories.Add(new AssetHistory
        {
            AssetId = asset.Id,
            Action = "Returned",
            PerformedBy = previousHolder,
            Timestamp = DateTime.UtcNow
        });

        await _context.SaveChangesAsync();
        return Ok(asset);
    }
}