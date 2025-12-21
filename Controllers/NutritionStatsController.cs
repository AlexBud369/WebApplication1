using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repositories.Contracts;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NutritionStatsController : ControllerBase
{
    private readonly INutritionStatsRepository _nutritionStatsRepository;

    public NutritionStatsController(INutritionStatsRepository nutritionStatsRepository)
    {
        _nutritionStatsRepository = nutritionStatsRepository;
    }

    [HttpGet("{userId:guid}/{date:datetime}")]
    public IActionResult GetDailyNutrition(Guid userId, DateTime date)
    {
        var dateOnly = DateOnly.FromDateTime(date);
        var nutrition = _nutritionStatsRepository.GetDailyNutrition(userId, dateOnly);
        return Ok(nutrition);
    }
}