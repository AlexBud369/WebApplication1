using WebApplication1.DTOs;

namespace WebApplication1.Repositories.Contracts;

public interface IMealProductRepository : IRepositoryBase<Models.MealProduct>
{
    IReadOnlyCollection<MealProductDto> GetMealProductsByMealId(Guid mealId);
    MealProductDto GetMealProductById(Guid id);
}
