using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repositories.Contracts;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MealsController : ControllerBase
{
    private readonly IMealRepository _mealRepository;
    private readonly IMealProductRepository _mealProductRepository;

    public MealsController(IMealRepository mealRepository, IMealProductRepository mealProductRepository)
    {
        _mealRepository = mealRepository;
        _mealProductRepository = mealProductRepository;
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
        if (meal == null)
        {
            return NotFound();
        }
        return Ok(meal);
    }

    [HttpGet("diet/{dietId}")]
    public IActionResult GetMealsByDiet(Guid dietId)
    {
        var meals = _mealRepository.GetMealsByDietId(dietId);
        return Ok(meals);
    }

    [HttpGet("{id}/with-products")]
    public IActionResult GetMealWithProducts(Guid id)
    {
        var meal = _mealRepository.GetMealWithProducts(id);
        if (meal == null)
        {
            return NotFound();
        }
        return Ok(meal);
    }

    [HttpGet("{mealId}/products")]
    public IActionResult GetMealProducts(Guid mealId)
    {
        var mealProducts = _mealProductRepository.GetMealProductsByMealId(mealId);
        return Ok(mealProducts);
    }
}