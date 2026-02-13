using System.ComponentModel.DataAnnotations;

namespace ProductApp.Application.DTOs;

// DTO used for creating a new product
public class CreateProductDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    [Range(0.01, 999999)]
    public decimal Price { get; set; }

    [Range(0, 99999)]
    public int Stock { get; set; }

    [Required]
    public string Category { get; set; } = string.Empty;

    public DateTime ExpirationDate { get; set; }

    public bool IsActive { get; set; }
}
