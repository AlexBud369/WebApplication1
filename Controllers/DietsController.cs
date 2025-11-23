using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repositories.Contracts;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DietsController : ControllerBase
{
    private readonly IDietRepository _dietRepository;

    public DietsController(IDietRepository dietRepository)
    {
        _dietRepository = dietRepository;
    }

    [HttpGet]
    public IActionResult GetDiets()
    {
        var diets = _dietRepository.GetAllDiets();
        return Ok(diets);
    }

    [HttpGet("{id}")]
    public IActionResult GetDiet(Guid id)
    {
        var diet = _dietRepository.GetDietById(id);
        if (diet == null)
        {
            return NotFound();
        }
        return Ok(diet);
    }

    [HttpGet("user/{userId}")]
    public IActionResult GetUserDiets(Guid userId)
    {
        var diets = _dietRepository.GetDietsByUserId(userId);
        return Ok(diets);
    }
}