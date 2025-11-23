using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Repositories.Contracts;
using WebApplication1.Models;

namespace WebApplication1.Repositories.Implementations;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context) { }

    public UserDto GetUserById(Guid id)
    {
        return FindByCondition(u => u.Id == id, trackChanges: false)
            .Select(u => new UserDto(
                u.Id, u.Email, u.BirthDate, u.Gender, u.Weight, u.Height,
                u.ActivityLevel, u.GoalType, u.DietaryRestrictions, u.CreatedAt
            ))
            .FirstOrDefault();
    }

    public IReadOnlyCollection<UserDto> GetAllUsers()
    {
        return FindAll(trackChanges: false)
            .Select(u => new UserDto(
                u.Id, u.Email, u.BirthDate, u.Gender, u.Weight, u.Height,
                u.ActivityLevel, u.GoalType, u.DietaryRestrictions, u.CreatedAt
            ))
            .ToList()
            .AsReadOnly();
    }

    public IReadOnlyCollection<UserSummaryDto> GetUserSummaries()
    {
        return FindAll(trackChanges: false)
            .Select(u => new UserSummaryDto(u.Id, u.Email, u.Gender, u.Weight, u.Height))
            .ToList()
            .AsReadOnly();
    }
}