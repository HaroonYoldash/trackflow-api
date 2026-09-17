namespace TrackFlow.Api.Models;

public class AssetHistory
{
    public int Id { get; set; }
    public int AssetId { get; set; }
    public string Action { get; set; } = string.Empty;
    public string PerformedBy { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}