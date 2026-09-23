using System.ComponentModel.DataAnnotations;

namespace ProductCatalogApi.Models;

public class ProductRequest
{
    [Required]
    [StringLength(100)]
    public string Name { get; init; } = string.Empty;

    [StringLength(500)]
    public string Description { get; init; } = string.Empty;

    [Range(0.01, 999999.99)]
    public decimal Price { get; init; }

    [Required]
    [StringLength(50)]
    public string Category { get; init; } = string.Empty;

    [Range(0, int.MaxValue)]
    public int StockQuantity { get; init; }
}
