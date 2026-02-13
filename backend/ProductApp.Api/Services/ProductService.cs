using Microsoft.EntityFrameworkCore;
using ProductApp.Api.Data;
using ProductApp.Application.DTOs;
using ProductApp.Application.Entities;
using ProductApp.Application.Services;

namespace ProductApp.Api.Services;

// Implements the IProductService interface to handle product-related operations
public class ProductService : IProductService
{
    private readonly AppDbContext _context; // Database context for EF Core operations

    // Constructor injecting the database context
    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    // Retrieves all products and maps them to ProductDto
    public async Task<List<ProductDto>> GetAllAsync()
    {
        return await _context.Products
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock,
                Category = p.Category,
                ExpirationDate = p.ExpirationDate,
                IsActive = p.IsActive
            })
            .ToListAsync(); // Executes the query asynchronously
    }

    // Retrieves a single product by its ID and maps it to ProductDto
    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        return await _context.Products
            .Where(p => p.Id == id)
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock,
                Category = p.Category,
                ExpirationDate = p.ExpirationDate,
                IsActive = p.IsActive
            })
            .FirstOrDefaultAsync(); // Returns null if the product does not exist
    }

    // Creates a new product in the database and returns it as ProductDto
    public async Task<ProductDto> CreateAsync(CreateProductDto dto)
    {
        var product = new Product
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            Stock = dto.Stock,
            Category = dto.Category,
            ExpirationDate = dto.ExpirationDate,
            IsActive = dto.IsActive
        };

        _context.Products.Add(product); // Adds the new product to the DbSet
        await _context.SaveChangesAsync(); // Persists changes to the database

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock,
            Category = product.Category,
            ExpirationDate = product.ExpirationDate,
            IsActive = product.IsActive
        };
    }

    // Updates an existing product; returns false if the product does not exist
    public async Task<bool> UpdateAsync(int id, UpdateProductDto dto)
    {
        var product = await _context.Products.FindAsync(id); // Find product by primary key

        if (product is null) return false; // Return false if product not found

        // Update properties with new values
        product.Name = dto.Name;
        product.Description = dto.Description;
        product.Price = dto.Price;
        product.Stock = dto.Stock;
        product.Category = dto.Category;
        product.ExpirationDate = dto.ExpirationDate;
        product.IsActive = dto.IsActive;

        await _context.SaveChangesAsync(); // Persist changes

        return true; // Indicate successful update
    }  

    // Deletes a product by ID; returns false if product does not exist
    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product is null) return false; // Return false if product not found

        _context.Products.Remove(product); // Remove product from DbSet
        await _context.SaveChangesAsync(); // Persist changes

        return true; // Indicate successful deletion
    }
}
