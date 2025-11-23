using WebApplication1.DTOs;

namespace WebApplication1.Repositories.Contracts;

public interface IProductRepository : IRepositoryBase<Models.Product>
{
    ProductDto GetProductById(Guid id);
    IReadOnlyCollection<ProductDto> GetAllProducts();

    ProductDto CreateProduct(CreateProductDto productDto);
    void UpdateProduct(Guid id, UpdateProductDto productDto);
    void DeleteProduct(Guid id);
}
