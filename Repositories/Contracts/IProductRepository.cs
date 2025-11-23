using WebApplication1.DTOs;

namespace WebApplication1.Repositories.Contracts;

public interface IProductRepository : IRepositoryBase<Models.Product>
{
    ProductDto GetProductById(Guid id);
    IReadOnlyCollection<ProductDto> GetAllProducts();
    IReadOnlyCollection<ProductSummaryDto> GetProductSummaries();
    IReadOnlyCollection<ProductDto> GetProductsByCategory(string category);
}
