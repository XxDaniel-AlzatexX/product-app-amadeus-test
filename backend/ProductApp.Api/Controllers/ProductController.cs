using Microsoft.AspNetCore.Mvc;
using ProductApp.Application.Services;
using ProductApp.Application.DTOs;

namespace ProductApp.Api.Controllers;

[ApiController] // Indicates that this class is an API controller
[Route("api/[controller]")] // Sets the base route to "api/products"
public class ProductsController : ControllerBase
{
    private readonly IProductService _service; // Dependency injection of the product service

    // Constructor injecting the product service
    public ProductsController(IProductService service)
    {
        _service = service;
    }

    // GET api/products
    // Retrieves all products
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllAsync());

    // GET api/products/{id}
    // Retrieves a single product by its ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _service.GetByIdAsync(id));
        
    // POST api/products
    // Creates a new product using the provided DTO
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto dto)
        => Ok(await _service.CreateAsync(dto));

    // PUT api/products/{id}
    // Updates an existing product; returns 204 NoContent if successful, 404 NotFound if product doesn't exist
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateProductDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);
        return updated ? NoContent() : NotFound();
    }

    // DELETE api/products/{id}
    // Deletes a product by its ID; returns 204 NoContent if successful, 404 NotFound if product doesn't exist
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        return result ? NoContent() : NotFound();
    }
}
