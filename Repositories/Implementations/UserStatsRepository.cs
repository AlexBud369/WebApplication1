using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Exceptions;
using WebApplication1.Repositories.Contracts;
using WebApplication1.ViewModels;

namespace WebApplication1.Repositories.Implementations;

public class UserStatsRepository : IUserStatsRepository
{
    private readonly AppDbContext _context;

    public UserStatsRepository(AppDbContext context)
    {
        _context = context;
    }

    public UserDietStatsViewModel GetUserStats(Guid userId)
    {
        var user = _context.Users
            .Include(u => u.Diets)
                .ThenInclude(d => d.Meals)
            .FirstOrDefault(u => u.Id == userId);

        if (user == null) {
            throw new UserNotFoundException(userId);
        }
            

        var diets = user.Diets.ToList();
        var age = CalculateAge(user.BirthDate);

        return new UserDietStatsViewModel(
            user.Id,
            user.Email,
            age,
            user.Gender,
            diets.Count,
            diets.Sum(d => d.Meals.Count),
            diets.Any() ? diets.Average(d => d.TotalCalories) : 0,
            diets.Any() ? (int)diets.Average(d => d.NutrientBalanceScore) : 0
        );
    }

    public IReadOnlyCollection<UserDietStatsViewModel> GetAllUsersStats()
    {
        var usersData = _context.Users
            .Include(u => u.Diets)
                .ThenInclude(d => d.Meals)
            .Select(u => new
            {
                u.Id,
                u.Email,
                u.BirthDate,
                u.Gender,
                Diets = u.Diets.ToList()
            })
            .ToList();

        return usersData
            .Select(u => new UserDietStatsViewModel(
                u.Id,
                u.Email,
                CalculateAge(u.BirthDate),
                u.Gender,
                u.Diets.Count,
                u.Diets.Sum(d => d.Meals.Count),
                u.Diets.Any() ? u.Diets.Average(d => d.TotalCalories) : 0,
                u.Diets.Any() ? (int)u.Diets.Average(d => d.NutrientBalanceScore) : 0
            ))
            .ToList();
    }

    private int CalculateAge(DateOnly birthDate)
    {
        var today = DateOnly.FromDateTime(DateTime.Today);
        var age = today.Year - birthDate.Year;

        if (birthDate.Month > today.Month ||
            (birthDate.Month == today.Month && birthDate.Day > today.Day)) {
            age--;
        }

        return age;
    }
}