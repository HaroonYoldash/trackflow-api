using System.ComponentModel.DataAnnotations;

namespace TrackFlow.Api.DTOs;
public class AssignAssetDto
{
    [Required(ErrorMessage = "Employee name or email is required.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Assignee name must be between 2 and 100 characters.")]
    public string AssignedTo { get; set; } = string.Empty;
}
public class CreateAssetDto
{
    [Required(ErrorMessage = "Asset name is required.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Serial number is required.")]
    public string SerialNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "Category is required.")]
    public string Category { get; set; } = string.Empty;

    [Range(0.01, 100000.00, ErrorMessage = "Purchase cost must be greater than zero.")]
    public decimal PurchaseCost { get; set; }

    public bool IsAssigned { get; set; } = false;
    public string? AssignedTo { get; set; }
}

public class UpdateAssetDto
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string SerialNumber { get; set; } = string.Empty;

    [Required]
    public string Category { get; set; } = string.Empty;

    [Range(0.01, 100000.00)]
    public decimal PurchaseCost { get; set; }

    public bool IsAssigned { get; set; }
    public string? AssignedTo { get; set; }
}