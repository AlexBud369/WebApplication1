using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Exceptions;
using WebApplication1.Repositories.Contracts;
using WebApplication1.ViewModels;

namespace WebApplication1.Repositories.Implementations;

public class ProductStatsRepository : IProductStatsRepository
{
    private readonly AppDbContext _context;

    public ProductStatsRepository(AppDbContext context)
    {
        _context = context;
    }

    public IReadOnlyCollection<ProductUsageViewModel> GetProductUsageStats()
    {
        var productsData = _context.Products
            .Include(p => p.MealProducts)
            .Select(p => new
            {
                p.Id,
                p.Name,
                p.Category,
                p.IsVerified,
                p.CaloriesPer100G,
                MealProducts = p.MealProducts.ToList()
            })
            .ToList();

        return productsData
            .Select(p => new ProductUsageViewModel(
                p.Id,
                p.Name,
                p.Category,
                p.IsVerified,
                p.CaloriesPer100G,
                p.MealProducts.Count,
                p.MealProducts.Sum(mp => mp.QuantityGrams),
                p.MealProducts.Any()
                    ? p.MealProducts.Average(mp => mp.QuantityGrams)
                    : 0
            ))
            .OrderByDescending(p => p.UsageCount)
            .ToList();
    }

    public IReadOnlyCollection<ProductUsageViewModel> GetProductUsageByCategory(string category)
    {
        if (string.IsNullOrEmpty(category))
            throw new InvalidRequestException("Категория не может быть пустой");

        var productsData = _context.Products
            .Include(p => p.MealProducts)
            .Where(p => p.Category == category)
            .Select(p => new
            {
                p.Id,
                p.Name,
                p.Category,
                p.IsVerified,
                p.CaloriesPer100G,
                MealProducts = p.MealProducts.ToList()
            })
            .ToList();

        return productsData
            .Select(p => new ProductUsageViewModel(
                p.Id,
                p.Name,
                p.Category,
                p.IsVerified,
                p.CaloriesPer100G,
                p.MealProducts.Count,
                p.MealProducts.Sum(mp => mp.QuantityGrams),
                p.MealProducts.Any()
                    ? p.MealProducts.Average(mp => mp.QuantityGrams)
                    : 0
            ))
            .OrderByDescending(p => p.UsageCount)
            .ToList();
    }
}