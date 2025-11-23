using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repositories.Contracts;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
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
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpGet("category/{category}")]
    public IActionResult GetProductsByCategory(string category)
    {
        var products = _productRepository.GetProductsByCategory(category);
        return Ok(products);
    }

    [HttpGet("summary")]
    public IActionResult GetProductSummaries()
    {
        var summaries = _productRepository.GetProductSummaries();
        return Ok(summaries);
    }
}
