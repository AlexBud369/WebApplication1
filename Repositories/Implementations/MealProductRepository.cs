using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Models;
using WebApplication1.Repositories.Contracts;

namespace WebApplication1.Repositories.Implementations;

public class MealProductRepository : RepositoryBase<MealProduct>, IMealProductRepository
{
    private readonly IMapper _mapper;

    public MealProductRepository(AppDbContext context, IMapper mapper) : base(context)
    {
        _mapper = mapper;
    }

    public IReadOnlyCollection<MealProductDto> GetMealProductsByMealId(Guid mealId)
    {
        var mealProducts = FindByCondition(mp => mp.MealId == mealId, trackChanges: false)
         .Include(mp => mp.Product) 
         .ToList();

        var mealProductDtos = _mapper.Map<List<MealProductDto>>(mealProducts);

        return mealProductDtos.AsReadOnly();
    }

    public MealProductDto GetMealProductById(Guid id)
    {
        var mealProduct = FindByCondition(mp => mp.Id == id, trackChanges: false)
            .Include(mp => mp.Product)
            .FirstOrDefault();
        if (mealProduct is null) {
            throw new MealProductNotFoundException(id);
        }
           

        return _mapper.Map<MealProductDto>(mealProduct);
    }

    public MealProductDto CreateMealProduct(CreateMealProductDto mealProductDto)
    {
        var mealExists = _context.Meals.Any(m => m.Id == mealProductDto.MealId);
        if (!mealExists)
        {
            throw new InvalidRequestException($"Meal with id {mealProductDto.MealId} does not exist");
        }

        var productExists = _context.Products.Any(p => p.Id == mealProductDto.ProductId);
        if (!productExists)
        {
            throw new InvalidRequestException($"Product with id {mealProductDto.ProductId} does not exist");
        }

        var mealProductEntity = _mapper.Map<MealProduct>(mealProductDto);
        Create(mealProductEntity);

        var createdMealProduct = FindByCondition(mp => mp.Id == mealProductEntity.Id, trackChanges: false)
            .Include(mp => mp.Product)
            .FirstOrDefault();

        return _mapper.Map<MealProductDto>(createdMealProduct);
    }

    public void UpdateMealProduct(Guid id, UpdateMealProductDto mealProductDto)
    {
        var mealProductEntity = FindByCondition(mp => mp.Id == id, trackChanges: true)
            .FirstOrDefault();
        if (mealProductEntity is null) {
            throw new MealProductNotFoundException(id);
        }
           

        _mapper.Map(mealProductDto, mealProductEntity);
        Update(mealProductEntity);
    }

    public void DeleteMealProduct(Guid id)
    {
        var mealProductEntity = FindByCondition(mp => mp.Id == id, trackChanges: false)
            .FirstOrDefault();
        if (mealProductEntity is null) {
            throw new MealProductNotFoundException(id);
        }
           

        Delete(mealProductEntity);
    }
}