using WebApplication1.DTOs;
using WebApplication1.Repositories.Contracts;
using WebApplication1.Models;
using WebApplication1.Data;

namespace WebApplication1.Repositories.Implementations;

public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context) { }

    public ProductDto GetProductById(Guid id)
    {
        return FindByCondition(p => p.Id == id, trackChanges: false)
            .Select(p => new ProductDto(
                p.Id, p.Name, p.Category, p.CaloriesPer100G,
                p.ProteinPer100G, p.FatPer100G, p.CarbsPer100G, p.IsVerified
            ))
            .FirstOrDefault();
    }

    public IReadOnlyCollection<ProductDto> GetAllProducts()
    {
        return FindAll(trackChanges: false)
            .Select(p => new ProductDto(
                p.Id, p.Name, p.Category, p.CaloriesPer100G,
                p.ProteinPer100G, p.FatPer100G, p.CarbsPer100G, p.IsVerified
            ))
            .ToList()
            .AsReadOnly();
    }

    public IReadOnlyCollection<ProductSummaryDto> GetProductSummaries()
    {
        return FindAll(trackChanges: false)
            .Select(p => new ProductSummaryDto(p.Id, p.Name, p.Category, p.CaloriesPer100G))
            .ToList()
            .AsReadOnly();
    }

    public IReadOnlyCollection<ProductDto> GetProductsByCategory(string category)
    {
        return FindByCondition(p => p.Category == category, trackChanges: false)
            .Select(p => new ProductDto(
                p.Id, p.Name, p.Category, p.CaloriesPer100G,
                p.ProteinPer100G, p.FatPer100G, p.CarbsPer100G, p.IsVerified
            ))
            .ToList()
            .AsReadOnly();
    }
}
