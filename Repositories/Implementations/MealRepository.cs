using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Models;
using WebApplication1.Repositories.Contracts;

namespace WebApplication1.Repositories.Implementations;

public class MealRepository : RepositoryBase<Meal>, IMealRepository
{
    private readonly IMapper _mapper;

    public MealRepository(AppDbContext context, IMapper mapper) : base(context)
    {
        _mapper = mapper;
    }

    public MealDto GetMealById(Guid id)
    {
        var meal = FindByCondition(m => m.Id == id, trackChanges: false)
             .FirstOrDefault();
        if (meal is null) {
            throw new MealNotFoundException(id);
        }
           

        return _mapper.Map<MealDto>(meal);
    }

    public IReadOnlyCollection<MealDto> GetAllMeals()
    {
        var meals = FindAll(trackChanges: false).ToList();

        return _mapper.Map<IReadOnlyCollection<MealDto>>(meals);
    }


    public MealDto CreateMeal(CreateMealDto mealDto)
    {
        var mealEntity = _mapper.Map<Meal>(mealDto);
        Create(mealEntity);

        return _mapper.Map<MealDto>(mealEntity);
    }

    public void UpdateMeal(Guid id, UpdateMealDto mealDto)
    {
        var mealEntity = FindByCondition(m => m.Id == id, trackChanges: true)
            .FirstOrDefault();
        if (mealEntity is null) { 
            throw new MealNotFoundException(id);
        }

        _mapper.Map(mealDto, mealEntity);
        Update(mealEntity);
    }

    public void DeleteMeal(Guid id)
    {
        var mealEntity = FindByCondition(m => m.Id == id, trackChanges: false)
            .FirstOrDefault();
        if (mealEntity is null) {
            throw new MealNotFoundException(id);
        }

        Delete(mealEntity);
    }
}