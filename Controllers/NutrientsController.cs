using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repositories.Contracts;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NutrientsController : ControllerBase
{
    private readonly INutrientRepository _nutrientRepository;
    private readonly IProductNutrientRepository _productNutrientRepository;

    public NutrientsController(INutrientRepository nutrientRepository, IProductNutrientRepository productNutrientRepository)
    {
        _nutrientRepository = nutrientRepository;
        _productNutrientRepository = productNutrientRepository;
    }

    [HttpGet]
    public IActionResult GetNutrients()
    {
        var nutrients = _nutrientRepository.GetAllNutrients();
        return Ok(nutrients);
    }

    [HttpGet("{id}")]
    public IActionResult GetNutrient(Guid id)
    {
        var nutrient = _nutrientRepository.GetNutrientById(id);
        if (nutrient == null)
        {
            return NotFound();
        }
        return Ok(nutrient);
    }

    [HttpGet("summary")]
    public IActionResult GetNutrientSummaries()
    {
        var summaries = _nutrientRepository.GetNutrientSummaries();
        return Ok(summaries);
    }

    [HttpGet("product/{productId}")]
    public IActionResult GetProductNutrients(Guid productId)
    {
        var productNutrients = _productNutrientRepository.GetProductNutrientsByProductId(productId);
        return Ok(productNutrients);
    }
}