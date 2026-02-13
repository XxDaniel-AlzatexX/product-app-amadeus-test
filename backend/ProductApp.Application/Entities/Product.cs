namespace ProductApp.Application.Entities;

// Represents the Product entity in the database
public class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public string Category { get; set; } = string.Empty;

    public DateTime ExpirationDate { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
