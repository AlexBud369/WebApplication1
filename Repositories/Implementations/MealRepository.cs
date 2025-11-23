using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Repositories.Contracts;

namespace WebApplication1.Repositories.Implementations;

public class MealRepository : RepositoryBase<Meal>, IMealRepository
{
    public MealRepository(AppDbContext context) : base(context) { }

    public MealDto GetMealById(Guid id)
    {
        return FindByCondition(m => m.Id == id, trackChanges: false)
            .Select(m => new MealDto(m.Id, m.DietId, m.MealType, m.MealDate))
            .FirstOrDefault();
    }

    public IReadOnlyCollection<MealDto> GetAllMeals()
    {
        return FindAll(trackChanges: false)
            .Select(m => new MealDto(m.Id, m.DietId, m.MealType, m.MealDate))
            .ToList()
            .AsReadOnly();
    }

    public IReadOnlyCollection<MealDto> GetMealsByDietId(Guid dietId)
    {
        return FindByCondition(m => m.DietId == dietId, trackChanges: false)
            .Select(m => new MealDto(m.Id, m.DietId, m.MealType, m.MealDate))
            .ToList()
            .AsReadOnly();
    }

    public MealWithProductsDto GetMealWithProducts(Guid id)
    {
        return FindByCondition(m => m.Id == id, trackChanges: false)
               .Include(m => m.MealProducts)
               .ThenInclude(mp => mp.Product)
               .Select(m => new MealWithProductsDto(
                   m.Id, m.DietId, m.MealType, m.MealDate,
                   m.MealProducts.Select(mp => new MealProductDto(
                       mp.Id, mp.MealId, mp.ProductId, mp.QuantityGrams,
                       mp.Product.Name, mp.Product.CaloriesPer100G * mp.QuantityGrams / 100
                   )).ToList().AsReadOnly()
               ))
               .FirstOrDefault();
    }
}