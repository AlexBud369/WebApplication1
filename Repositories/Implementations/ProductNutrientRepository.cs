using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Models;
using WebApplication1.Repositories.Contracts;

namespace WebApplication1.Repositories.Implementations;

public class ProductNutrientRepository : RepositoryBase<ProductNutrient>, IProductNutrientRepository
{
    private readonly IMapper _mapper;

    public ProductNutrientRepository(AppDbContext context, IMapper mapper) : base(context)
    {
        _mapper = mapper;
    }

    public IReadOnlyCollection<ProductNutrientDto> GetProductNutrientsByProductId(Guid productId)
    {
        var productNutrients = FindByCondition(pn => pn.ProductId == productId, trackChanges: false)
            .Include(pn => pn.Nutrient)
            .ToList();

        return _mapper.Map<IReadOnlyCollection<ProductNutrientDto>>(productNutrients);
    }

    public ProductNutrientDto GetProductNutrientById(Guid id)
    {
        var productNutrient = FindByCondition(pn => pn.Id == id, trackChanges: false)
            .Include(pn => pn.Nutrient)
            .FirstOrDefault();
        if (productNutrient is null) {
            throw new ProductNutrientNotFoundException(id);

        }

        return _mapper.Map<ProductNutrientDto>(productNutrient);
    }

    public ProductNutrientDto CreateProductNutrient(CreateProductNutrientDto productNutrientDto)
    {
        var productNutrientEntity = _mapper.Map<ProductNutrient>(productNutrientDto);
        Create(productNutrientEntity);

        var createdProductNutrient = FindByCondition(pn => pn.Id == productNutrientEntity.Id, trackChanges: false)
            .Include(pn => pn.Nutrient)
            .FirstOrDefault();

        return _mapper.Map<ProductNutrientDto>(createdProductNutrient);
    }

    public void UpdateProductNutrient(Guid id, UpdateProductNutrientDto productNutrientDto)
    {
        var productNutrientEntity = FindByCondition(pn => pn.Id == id, trackChanges: true)
            .FirstOrDefault();
        if (productNutrientEntity is null) {
            throw new ProductNutrientNotFoundException(id);
        }
          

        _mapper.Map(productNutrientDto, productNutrientEntity);
        Update(productNutrientEntity);
    }

    public void DeleteProductNutrient(Guid id)
    {
        var productNutrientEntity = FindByCondition(pn => pn.Id == id, trackChanges: false)
            .FirstOrDefault();
        if (productNutrientEntity is null) {
            throw new ProductNutrientNotFoundException(id);
        }
           

        Delete(productNutrientEntity);
    }
}