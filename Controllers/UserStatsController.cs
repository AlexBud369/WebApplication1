using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repositories.Contracts;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserStatsController : ControllerBase
{
    private readonly IUserStatsRepository _userStatsRepository;

    public UserStatsController(IUserStatsRepository userStatsRepository)
    {
        _userStatsRepository = userStatsRepository;
    }

    [HttpGet("{userId:guid}")]
    public IActionResult GetUserStats(Guid userId)
    {
        var stats = _userStatsRepository.GetUserStats(userId);
        return Ok(stats);
    }

    [HttpGet]
    public IActionResult GetAllUsersStats()
    {
        var stats = _userStatsRepository.GetAllUsersStats();
        return Ok(stats);
    }
}