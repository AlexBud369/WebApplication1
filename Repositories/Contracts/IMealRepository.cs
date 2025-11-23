using WebApplication1.DTOs;

namespace WebApplication1.Repositories.Contracts;

public interface IMealRepository : IRepositoryBase<Models.Meal>
{
    MealDto GetMealById(Guid id);
    IReadOnlyCollection<MealDto> GetAllMeals();
    IReadOnlyCollection<MealDto> GetMealsByDietId(Guid dietId);
    MealWithProductsDto GetMealWithProducts(Guid id);
}