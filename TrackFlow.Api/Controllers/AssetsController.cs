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
    public async Task<ActionResult<IEnumerable<Asset>>> GetAll()
    {
        return Ok(await _context.Assets.AsNoTracking().ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Asset>> GetById(int id)
    {
        var asset = await _context.Assets.FindAsync(id);
        if (asset == null)
        {
            return NotFound($"Asset with ID {id} not found.");
        }

        return Ok(asset);
    }

    [HttpPost]
    public async Task<ActionResult<Asset>> Create([FromBody] CreateAssetDto dto)
    {
        var asset = new Asset
        {
            Name = dto.Name,
            SerialNumber = dto.SerialNumber,
            Category = dto.Category,
            PurchaseCost = dto.PurchaseCost,
            IsAssigned = dto.IsAssigned,
            AssignedTo = dto.AssignedTo
        };

        _context.Assets.Add(asset);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = asset.Id }, asset);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateAssetDto dto)
    {
        var existingAsset = await _context.Assets.FindAsync(id);
        if (existingAsset == null)
        {
            return NotFound($"Asset with ID {id} not found.");
        }

        existingAsset.Name = dto.Name;
        existingAsset.SerialNumber = dto.SerialNumber;
        existingAsset.Category = dto.Category;
        existingAsset.PurchaseCost = dto.PurchaseCost;
        existingAsset.IsAssigned = dto.IsAssigned;
        existingAsset.AssignedTo = dto.AssignedTo;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var asset = await _context.Assets.FindAsync(id);
        if (asset == null)
        {
            return NotFound($"Asset with ID {id} not found.");
        }

        _context.Assets.Remove(asset);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPost("{id}/assign")]
    public async Task<IActionResult> Assign(int id, [FromBody] AssignAssetDto dto)
    {
        var asset = await _context.Assets.FindAsync(id);
        if (asset == null)
        {
            return NotFound($"Asset with ID {id} not found.");
        }

        if (asset.IsAssigned)
        {
            return Conflict($"Asset is already assigned to {asset.AssignedTo}.");
        }

        asset.IsAssigned = true;
        asset.AssignedTo = dto.AssignedTo;

        await _context.SaveChangesAsync();
        return Ok(asset);
    }

    [HttpPost("{id}/return")]
    public async Task<IActionResult> Return(int id)
    {
        var asset = await _context.Assets.FindAsync(id);
        if (asset == null)
        {
            return NotFound($"Asset with ID {id} not found.");
        }

        if (!asset.IsAssigned)
        {
            return BadRequest("Asset is not currently assigned.");
        }

        asset.IsAssigned = false;
        asset.AssignedTo = null;

        await _context.SaveChangesAsync();
        return Ok(asset);
    }
}