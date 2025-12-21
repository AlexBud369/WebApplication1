using WebApplication1.ViewModels;

namespace WebApplication1.Repositories.Contracts;

public interface INutritionStatsRepository
{
    DailyNutritionViewModel GetDailyNutrition(Guid userId, DateOnly date);
}