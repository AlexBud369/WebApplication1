using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Repositories.Implementations;

public class MealProductRepository : RepositoryBase<MealProduct>, IMealProductRepository
{
    public MealProductRepository(AppDbContext context) : base(context) { }

    public IReadOnlyCollection<MealProductDto> GetMealProductsByMealId(Guid mealId)
    {
        return FindByCondition(mp => mp.MealId == mealId, trackChanges: false)
            .Include(mp => mp.Product)
            .Select(mp => new MealProductDto(
                mp.Id, mp.MealId, mp.ProductId, mp.QuantityGrams,
                mp.Product.Name, mp.Product.CaloriesPer100G * mp.QuantityGrams / 100
            ))
            .ToList()
            .AsReadOnly();
    }

    public MealProductDto GetMealProductById(Guid id)
    {
        return FindByCondition(mp => mp.Id == id, trackChanges: false)
            .Include(mp => mp.Product)
            .Select(mp => new MealProductDto(
                mp.Id, mp.MealId, mp.ProductId, mp.QuantityGrams,
                mp.Product.Name, mp.Product.CaloriesPer100G * mp.QuantityGrams / 100
            ))
            .FirstOrDefault();
    }
}