using ProductApp.Application.DTOs;

namespace ProductApp.Application.Services;

// Defines the contract for product-related operations
// This interface separates the service logic from the controller
public interface IProductService
{
    Task<List<ProductDto>> GetAllAsync();

    Task<ProductDto?> GetByIdAsync(int id);

    Task<ProductDto> CreateAsync(CreateProductDto dto);

    Task<bool> UpdateAsync(int id, UpdateProductDto dto);

    Task<bool> DeleteAsync(int id);
}
