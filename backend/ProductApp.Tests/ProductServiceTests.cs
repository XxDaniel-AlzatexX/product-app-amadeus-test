using Microsoft.EntityFrameworkCore;
using ProductApp.Api.Services;
using ProductApp.Api.Data;
using ProductApp.Application.DTOs;

namespace ProductApp.Tests;

// Unit tests for ProductService using in-memory database
public class ProductServiceTests
{
    // Helper method to create a new in-memory DbContext for each test
    private AppDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()) // Ensures a unique DB for each test
            .Options;

        return new AppDbContext(options);
    }

    // Test that CreateAsync adds a product correctly
    [Fact]
    public async Task Create_Should_Add_Product()
    {
        var context = CreateContext();
        var service = new ProductService(context);

        var dto = new CreateProductDto
        {
            Name = "Test",
            Description = "Desc",
            Price = 10,
            Stock = 5,
            Category = "Cat"
        };

        var result = await service.CreateAsync(dto);

        // Assert that the product was created with correct properties
        Assert.Equal("Test", result.Name);
        // Assert that the product exists in the context
        Assert.Equal(1, context.Products.Count());
    }

    // Test that GetAllAsync returns all products
    [Fact]
    public async Task GetAll_Should_Return_All_Products()
    {
        var context = CreateContext();

        // Add sample products to the in-memory database
        context.Products.Add(new() { Name = "A" });
        context.Products.Add(new() { Name = "B" });
        await context.SaveChangesAsync();

        var service = new ProductService(context);

        var result = await service.GetAllAsync();

        // Assert that all products are returned
        Assert.Equal(2, result.Count());
    }

    // Test that DeleteAsync removes a product successfully
    [Fact]
    public async Task Delete_Should_Remove_Product()
    {
        var context = CreateContext();

        var product = new ProductApp.Application.Entities.Product
        {
            Name = "Test"
        };

        context.Products.Add(product);
        await context.SaveChangesAsync();

        var service = new ProductService(context);

        var deleted = await service.DeleteAsync(product.Id);

        // Assert that deletion returns true and the product is removed
        Assert.True(deleted);
        Assert.Empty(context.Products);
    }

    // Test that DeleteAsync returns false when product does not exist
    [Fact]
    public async Task Delete_Should_Return_False_When_NotFound()
    {
        var context = CreateContext();
        var service = new ProductService(context);

        var deleted = await service.DeleteAsync(999); // Non-existing ID

        Assert.False(deleted); // Assert deletion failed
    }
}
