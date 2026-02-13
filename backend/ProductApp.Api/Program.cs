using Microsoft.EntityFrameworkCore;
using ProductApp.Api.Data;
using ProductApp.Application.Services;
using ProductApp.Api.Services;

// Create a WebApplication builder
var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers(); // Adds controller support for API endpoints
builder.Services.AddEndpointsApiExplorer(); // Enables endpoint metadata for Swagger
builder.Services.AddSwaggerGen(); // Adds Swagger generation for API documentation

// Dependency injection: register ProductService as implementation of IProductService
builder.Services.AddScoped<IProductService, ProductService>();

// Configure Entity Framework Core with SQL Server using connection string from configuration
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure CORS to allow requests from Angular frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy
                .WithOrigins("http://localhost:4200") // Allow only Angular app origin
                .AllowAnyHeader() // Allow any HTTP headers
                .AllowAnyMethod(); // Allow any HTTP methods (GET, POST, PUT, DELETE)
        });
});

// Build the application
var app = builder.Build();

// Enable CORS middleware using the configured policy
app.UseCors("AllowAngular");

// Redirect HTTP requests to HTTPS
app.UseHttpsRedirection();

// Map controller routes
app.MapControllers();

// Configure Swagger UI only in development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Enable Swagger middleware
    app.UseSwaggerUI(); // Enable Swagger UI for testing endpoints
}

// Run the application
app.Run();
