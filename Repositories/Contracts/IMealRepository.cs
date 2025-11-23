using WebApplication1.DTOs;

namespace WebApplication1.Repositories.Contracts;

public interface IMealRepository : IRepositoryBase<Models.Meal>
{
    MealDto GetMealById(Guid id);
    IReadOnlyCollection<MealDto> GetAllMeals();

    MealDto CreateMeal(CreateMealDto mealDto);
    void UpdateMeal(Guid id, UpdateMealDto mealDto);
    void DeleteMeal(Guid id);
}