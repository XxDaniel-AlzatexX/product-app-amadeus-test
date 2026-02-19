using System.ComponentModel.DataAnnotations;

namespace ProductApp.Application.DTOs;

// DTO used for update a existing product
public class UpdateProductDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public string Category { get; set; } = string.Empty;

    public DateTime ExpirationDate { get; set; }

    public bool IsActive { get; set; }
}
