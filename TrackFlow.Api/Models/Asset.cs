namespace TrackFlow.Api.Models;

public class Asset
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty; // e.g., "Laptop", "Monitor"
    public decimal PurchaseCost { get; set; }
    public bool IsAssigned { get; set; } = false;
    public string? AssignedTo { get; set; } // The name or email of the employee holding it (can be null)
}