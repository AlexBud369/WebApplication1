using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Repositories.Implementations;

public class ProductNutrientRepository : RepositoryBase<ProductNutrient>, IProductNutrientRepository
{
    public ProductNutrientRepository(AppDbContext context) : base(context) { }

    public IReadOnlyCollection<ProductNutrientDto> GetProductNutrientsByProductId(Guid productId)
    {
        return FindByCondition(pn => pn.ProductId == productId, trackChanges: false)
            .Include(pn => pn.Nutrient)
            .Select(pn => new ProductNutrientDto(
                pn.Id, pn.ProductId, pn.NutrientId, pn.Nutrient.Name,
                pn.AmountPer100g, pn.Nutrient.Unit
            ))
            .ToList()
            .AsReadOnly();
    }

    public ProductNutrientDto GetProductNutrientById(Guid id)
    {
        return FindByCondition(pn => pn.Id == id, trackChanges: false)
            .Include(pn => pn.Nutrient)
            .Select(pn => new ProductNutrientDto(
                pn.Id, pn.ProductId, pn.NutrientId, pn.Nutrient.Name,
                pn.AmountPer100g, pn.Nutrient.Unit
            ))
            .FirstOrDefault();
    }
}