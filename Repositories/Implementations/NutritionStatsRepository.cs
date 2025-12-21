using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Exceptions;
using WebApplication1.Repositories.Contracts;
using WebApplication1.ViewModels;

namespace WebApplication1.Repositories.Implementations;

public class NutritionStatsRepository : INutritionStatsRepository
{
    private readonly AppDbContext _context;

    public NutritionStatsRepository(AppDbContext context)
    {
        _context = context;
    }

    public DailyNutritionViewModel GetDailyNutrition(Guid userId, DateOnly date)
    {
        var userExists = _context.Users.Any(u => u.Id == userId);
        if (!userExists)
            throw new UserNotFoundException(userId);

        var meals = _context.Meals
            .Include(m => m.MealProducts)
                .ThenInclude(mp => mp.Product)
            .Where(m => m.MealDate.Date == date.ToDateTime(new TimeOnly()))
            .Where(m => m.Diet.UserId == userId)
            .ToList();

        var mealProducts = meals.SelectMany(m => m.MealProducts).ToList();

        var totalCalories = 0m;
        var totalProtein = 0m;
        var totalFat = 0m;
        var totalCarbs = 0m;

        foreach (var mp in mealProducts)
        {
            var product = mp.Product;
            var factor = mp.QuantityGrams / 100m;

            totalCalories += product.CaloriesPer100G * factor;
            totalProtein += product.ProteinPer100G * factor;
            totalFat += product.FatPer100G * factor;
            totalCarbs += product.CarbsPer100G * factor;
        }

        var user = _context.Users.Find(userId);

        return new DailyNutritionViewModel(
            date,
            userId,
            user?.Email ?? string.Empty,
            totalCalories,
            totalProtein,
            totalFat,
            totalCarbs,
            meals.Count
        );
    }
}