using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
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

        return Ok(diet);
    }

    [HttpGet("user/{userId}")]
    public IActionResult GetUserDiets(Guid userId)
    {
        var diets = _dietRepository.GetDietsByUserId(userId);

        return Ok(diets);
    }

    [HttpPost]
    public IActionResult CreateDiet([FromBody] CreateDietDto dietDto)
    {
        if (dietDto is null) {
            return BadRequest("DietForCreationDto object is null");
        }
            

        var createdDiet = _dietRepository.CreateDiet(dietDto);

        return CreatedAtAction(nameof(GetDiet), new { id = createdDiet.Id }, createdDiet);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateDiet(Guid id, [FromBody] UpdateDietDto dietDto)
    {
        if (dietDto is null) {
            return BadRequest("DietForUpdateDto object is null");
        }
            

        _dietRepository.UpdateDiet(id, dietDto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteDiet(Guid id)
    {
        _dietRepository.DeleteDiet(id);

        return NoContent();
    }
}