namespace TrackFlow.Api.Models;

public class Asset
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty; 
    public decimal PurchaseCost { get; set; }
    public bool IsAssigned { get; set; } = false;
    public string? AssignedTo { get; set; } 
}