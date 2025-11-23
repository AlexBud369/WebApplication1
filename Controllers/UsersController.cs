using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repositories.Contracts;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
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
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpGet("summary")]
    public IActionResult GetUserSummaries()
    {
        var summaries = _userRepository.GetUserSummaries();
        return Ok(summaries);
    }
}