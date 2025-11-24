using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Repositories.Contracts;
using WebApplication1.Extensions;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MealsController : ControllerBase
{
    private readonly IMealRepository _mealRepository;
    private readonly IMealProductRepository _mealProductRepository;
    private readonly IValidator<CreateMealDto> _createMealValidator;
    private readonly IValidator<UpdateMealDto> _updateMealValidator;
    private readonly IValidator<CreateMealProductDto> _createMealProductValidator;

    public MealsController(
        IMealRepository mealRepository,
        IMealProductRepository mealProductRepository,
        IValidator<CreateMealDto> createMealValidator,
        IValidator<UpdateMealDto> updateMealValidator,
        IValidator<CreateMealProductDto> createMealProductValidator)
    {
        _mealRepository = mealRepository;
        _mealProductRepository = mealProductRepository;
        _createMealValidator = createMealValidator;
        _updateMealValidator = updateMealValidator;
        _createMealProductValidator = createMealProductValidator;
    }

    [HttpGet]
    public IActionResult GetMeals()
    {
        var meals = _mealRepository.GetAllMeals();

        return Ok(meals);
    }

    [HttpGet("{id}")]
    public IActionResult GetMeal(Guid id)
    {
        var meal = _mealRepository.GetMealById(id);

        return Ok(meal);
    }

    [HttpGet("{mealId}/products")]
    public IActionResult GetMealProducts(Guid mealId)
    {
        var mealProducts = _mealProductRepository.GetMealProductsByMealId(mealId);

        return Ok(mealProducts);
    }

    [HttpPost]
    public IActionResult CreateMeal([FromBody] CreateMealDto mealDto)
    {
        if (mealDto is null) {
            return BadRequest("MealForCreationDto object is null");
        }
           
        var validationResult = _createMealValidator.Validate(mealDto);
        if (!validationResult.IsValid) {
            validationResult.AddToModelState(ModelState);
            return UnprocessableEntity(ModelState);
        }

        var createdMeal = _mealRepository.CreateMeal(mealDto);

        return CreatedAtAction(nameof(GetMeal), new { id = createdMeal.Id }, createdMeal);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMeal(Guid id, [FromBody] UpdateMealDto mealDto)
    {
        if (mealDto is null) {
            return BadRequest("MealForUpdateDto object is null");
        }
            
        var validationResult = _updateMealValidator.Validate(mealDto);
        if (!validationResult.IsValid) {
            validationResult.AddToModelState(ModelState);
            return UnprocessableEntity(ModelState);
        }

        _mealRepository.UpdateMeal(id, mealDto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMeal(Guid id)
    {
        _mealRepository.DeleteMeal(id);

        return NoContent();
    }

    [HttpPost("{mealId}/products")]
    public IActionResult AddProductToMeal(Guid mealId, [FromBody] CreateMealProductDto mealProductDto)
    {
        if (mealProductDto is null) {
            return BadRequest("MealProductForCreationDto object is null");
        }
            
        var validationResult = _createMealProductValidator.Validate(mealProductDto);
        if (!validationResult.IsValid) {
            validationResult.AddToModelState(ModelState);
            return UnprocessableEntity(ModelState);
        }

        var meal = _mealRepository.GetMealById(mealId);
        if (meal is null) {
            return NotFound($"Meal with id: {mealId} doesn't exist in the database.");
        }
            
        var createdMealProduct = _mealProductRepository.CreateMealProduct(mealProductDto);

        return CreatedAtAction(
            nameof(GetMealProducts),
            new { mealId = mealId },
            createdMealProduct);
    }
}