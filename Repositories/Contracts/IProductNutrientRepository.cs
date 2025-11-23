using WebApplication1.DTOs;

namespace WebApplication1.Repositories.Contracts;

public interface IProductNutrientRepository : IRepositoryBase<Models.ProductNutrient>
{
    IReadOnlyCollection<ProductNutrientDto> GetProductNutrientsByProductId(Guid productId);
    ProductNutrientDto GetProductNutrientById(Guid id);
}