using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Repositories.Contracts;
using WebApplication1.Extensions;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DietsController : ControllerBase
{
    private readonly IDietRepository _dietRepository;
    private readonly IValidator<CreateDietDto> _createDietValidator;
    private readonly IValidator<UpdateDietDto> _updateDietValidator;

    public DietsController(
        IDietRepository dietRepository,
        IValidator<CreateDietDto> createDietValidator,
        IValidator<UpdateDietDto> updateDietValidator)
    {
        _dietRepository = dietRepository;
        _createDietValidator = createDietValidator;
        _updateDietValidator = updateDietValidator;
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
            

        var validationResult = _createDietValidator.Validate(dietDto);
        if (!validationResult.IsValid) {
            validationResult.AddToModelState(ModelState);
            return UnprocessableEntity(ModelState);
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
           

        var validationResult = _updateDietValidator.Validate(dietDto);
        if (!validationResult.IsValid) {
            validationResult.AddToModelState(ModelState);
            return UnprocessableEntity(ModelState);
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