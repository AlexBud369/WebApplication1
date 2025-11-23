using WebApplication1.DTOs;
using WebApplication1.Repositories.Contracts;
using WebApplication1.Models;
using WebApplication1.Data;
using AutoMapper;
using WebApplication1.Exceptions;

namespace WebApplication1.Repositories.Implementations;

public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    private readonly IMapper _mapper;
    public ProductRepository(AppDbContext context, IMapper mapper) : base(context) {
        _mapper = mapper;
    }

    public ProductDto GetProductById(Guid id)
    {
        var product = FindByCondition(p => p.Id == id, trackChanges: false)
            .FirstOrDefault();
        if (product is null) {
            throw new ProductNotFoundException(id);
        }

        return _mapper.Map<ProductDto>(product);
    }

    public IReadOnlyCollection<ProductDto> GetAllProducts()
    {
        var products = FindAll(trackChanges: false).ToList();

        return _mapper.Map<IReadOnlyCollection<ProductDto>>(products);
    }

    public ProductDto CreateProduct(CreateProductDto productDto)
    {
        var productEntity = _mapper.Map<Product>(productDto);
        Create(productEntity);

        return _mapper.Map<ProductDto>(productEntity);
    }

    public void UpdateProduct(Guid id, UpdateProductDto productDto)
    {
        var productEntity = FindByCondition(p => p.Id == id, trackChanges: true)
            .FirstOrDefault();
        if (productEntity is null) {
            throw new ProductNotFoundException(id); 
        }
          

        _mapper.Map(productDto, productEntity);
        Update(productEntity);
    }

    public void DeleteProduct(Guid id)
    {
        var productEntity = FindByCondition(p => p.Id == id, trackChanges: false)
            .FirstOrDefault();
        if (productEntity is null) {
            throw new ProductNotFoundException(id);
        }

        Delete(productEntity);
    }
}
