using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Repositories.Contracts;
using WebApplication1.Extensions;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    private readonly IValidator<CreateProductDto> _createProductValidator;
    private readonly IValidator<UpdateProductDto> _updateProductValidator;

    public ProductsController(
        IProductRepository productRepository,
        IValidator<CreateProductDto> createProductValidator,
        IValidator<UpdateProductDto> updateProductValidator)
    {
        _productRepository = productRepository;
        _createProductValidator = createProductValidator;
        _updateProductValidator = updateProductValidator;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = _productRepository.GetAllProducts();

        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult GetProduct(Guid id)
    {
        var product = _productRepository.GetProductById(id);

        return Ok(product);
    }

    [HttpPost]
    public IActionResult CreateProduct([FromBody] CreateProductDto productDto)
    {
        if (productDto is null) {
            return BadRequest("ProductForCreationDto object is null");
        }
            
        var validationResult = _createProductValidator.Validate(productDto);
        if (!validationResult.IsValid) {
            validationResult.AddToModelState(ModelState);
            return UnprocessableEntity(ModelState);
        }

        var createdProduct = _productRepository.CreateProduct(productDto);

        return CreatedAtAction(nameof(GetProduct), new { id = createdProduct.Id }, createdProduct);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(Guid id, [FromBody] UpdateProductDto productDto)
    {
        if (productDto is null) {
            return BadRequest("ProductForUpdateDto object is null");
        }
            
        var validationResult = _updateProductValidator.Validate(productDto);
        if (!validationResult.IsValid) {
            validationResult.AddToModelState(ModelState);
            return UnprocessableEntity(ModelState);
        }

        _productRepository.UpdateProduct(id, productDto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(Guid id)
    {
        _productRepository.DeleteProduct(id);

        return NoContent();
    }
}