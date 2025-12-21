using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repositories.Contracts;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductStatsController : ControllerBase
{
    private readonly IProductStatsRepository _productStatsRepository;

    public ProductStatsController(IProductStatsRepository productStatsRepository)
    {
        _productStatsRepository = productStatsRepository;
    }

    [HttpGet]
    public IActionResult GetProductStats()
    {
        var stats = _productStatsRepository.GetProductUsageStats();
        return Ok(stats);
    }

    [HttpGet("category/{category}")]
    public IActionResult GetProductStatsByCategory(string category)
    {
        var stats = _productStatsRepository.GetProductUsageByCategory(category);
        return Ok(stats);
    }
}