using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Repositories.Contracts;
using WebApplication1.Extensions;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NutrientsController : ControllerBase
{
    private readonly INutrientRepository _nutrientRepository;
    private readonly IProductNutrientRepository _productNutrientRepository;
    private readonly IValidator<CreateNutrientDto> _createNutrientValidator;
    private readonly IValidator<UpdateNutrientDto> _updateNutrientValidator;
    private readonly IValidator<CreateProductNutrientDto> _createProductNutrientValidator;
    private readonly IValidator<UpdateProductNutrientDto> _updateProductNutrientValidator;

    public NutrientsController(
        INutrientRepository nutrientRepository,
        IProductNutrientRepository productNutrientRepository,
        IValidator<CreateNutrientDto> createNutrientValidator,
        IValidator<UpdateNutrientDto> updateNutrientValidator,
        IValidator<CreateProductNutrientDto> createProductNutrientValidator,
        IValidator<UpdateProductNutrientDto> updateProductNutrientValidator)
    {
        _nutrientRepository = nutrientRepository;
        _productNutrientRepository = productNutrientRepository;
        _createNutrientValidator = createNutrientValidator;
        _updateNutrientValidator = updateNutrientValidator;
        _createProductNutrientValidator = createProductNutrientValidator;
        _updateProductNutrientValidator = updateProductNutrientValidator;
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

        return Ok(nutrient);
    }

    [HttpGet("product/{productId}")]
    public IActionResult GetProductNutrients(Guid productId)
    {
        var productNutrients = _productNutrientRepository.GetProductNutrientsByProductId(productId);

        return Ok(productNutrients);
    }

    [HttpPost]
    public IActionResult CreateNutrient([FromBody] CreateNutrientDto nutrientDto)
    {
        if (nutrientDto is null) {
            return BadRequest("NutrientForCreationDto object is null");
        }
           

        var validationResult = _createNutrientValidator.Validate(nutrientDto);
        if (!validationResult.IsValid) {
            validationResult.AddToModelState(ModelState);
            return UnprocessableEntity(ModelState);
        }

        var createdNutrient = _nutrientRepository.CreateNutrient(nutrientDto);

        return CreatedAtAction(nameof(GetNutrient), new { id = createdNutrient.Id }, createdNutrient);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateNutrient(Guid id, [FromBody] UpdateNutrientDto nutrientDto)
    {
        if (nutrientDto is null) {
            return BadRequest("NutrientForUpdateDto object is null");
        }
           

        var validationResult = _updateNutrientValidator.Validate(nutrientDto);
        if (!validationResult.IsValid) {
            validationResult.AddToModelState(ModelState);
            return UnprocessableEntity(ModelState);
        }

        _nutrientRepository.UpdateNutrient(id, nutrientDto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteNutrient(Guid id)
    {
        _nutrientRepository.DeleteNutrient(id);

        return NoContent();
    }

    [HttpPost("product-nutrients")]
    public IActionResult CreateProductNutrient([FromBody] CreateProductNutrientDto productNutrientDto)
    {
        if (productNutrientDto is null) {
            return BadRequest("ProductNutrientForCreationDto object is null");
        }
           
        var validationResult = _createProductNutrientValidator.Validate(productNutrientDto);
        if (!validationResult.IsValid) {
            validationResult.AddToModelState(ModelState);

            return UnprocessableEntity(ModelState);
        }

        var createdProductNutrient = _productNutrientRepository.CreateProductNutrient(productNutrientDto);

        return CreatedAtAction(
            nameof(GetProductNutrients),
            new { productId = createdProductNutrient.ProductId },
            createdProductNutrient);
    }

    [HttpPut("product-nutrients/{id}")]
    public IActionResult UpdateProductNutrient(Guid id, [FromBody] UpdateProductNutrientDto productNutrientDto)
    {
        if (productNutrientDto is null) {
            return BadRequest("ProductNutrientForUpdateDto object is null");
        }
            
        var validationResult = _updateProductNutrientValidator.Validate(productNutrientDto);
        if (!validationResult.IsValid) {
            validationResult.AddToModelState(ModelState);
            return UnprocessableEntity(ModelState);
        }

        _productNutrientRepository.UpdateProductNutrient(id, productNutrientDto);

        return NoContent();
    }

    [HttpDelete("product-nutrients/{id}")]
    public IActionResult DeleteProductNutrient(Guid id)
    {
        _productNutrientRepository.DeleteProductNutrient(id);

        return NoContent();
    }
}