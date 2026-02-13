using Microsoft.EntityFrameworkCore;
using ProductApp.Application.Entities;

namespace ProductApp.Api.Data;

// Represents the application's database context, responsible for interacting with the database
public class AppDbContext : DbContext
{
    // Constructor accepting DbContextOptions to configure the context (e.g., connection string, provider)
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // Represents the Products table in the database
    // DbSet allows querying and saving instances of Product
    public DbSet<Product> Products => Set<Product>();
}
