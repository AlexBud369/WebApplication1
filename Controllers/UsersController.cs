using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Repositories.Contracts;
using WebApplication1.Extensions;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IValidator<CreateUserDto> _createUserValidator;
    private readonly IValidator<UpdateUserDto> _updateUserValidator;

    public UsersController(
        IUserRepository userRepository,
        IValidator<CreateUserDto> createUserValidator,
        IValidator<UpdateUserDto> updateUserValidator)
    {
        _userRepository = userRepository;
        _createUserValidator = createUserValidator;
        _updateUserValidator = updateUserValidator;
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = _userRepository.GetAllUsers();

        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetUser(Guid id)
    {
        var user = _userRepository.GetUserById(id);

        return Ok(user);
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] CreateUserDto userDto)
    {
        if (userDto is null) {
            return BadRequest("UserForCreationDto object is null");
        }
            

        var validationResult = _createUserValidator.Validate(userDto);
        if (!validationResult.IsValid) {
            validationResult.AddToModelState(ModelState);
            return UnprocessableEntity(ModelState);
        }

        var createdUser = _userRepository.CreateUser(userDto);

        return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(Guid id, [FromBody] UpdateUserDto userDto)
    {
        if (userDto is null) {
            return BadRequest("UserForUpdateDto object is null");
        }
            

        var validationResult = _updateUserValidator.Validate(userDto);
        if (!validationResult.IsValid) {
            validationResult.AddToModelState(ModelState);
            return UnprocessableEntity(ModelState);
        }

        _userRepository.UpdateUser(id, userDto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(Guid id)
    {
        _userRepository.DeleteUser(id);

        return NoContent();
    }
}