using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Repositories.Contracts;

namespace WebApplication1.Repositories.Implementations;

public class DietRepository : RepositoryBase<Diet>, IDietRepository
{
    public DietRepository(AppDbContext context) : base(context) { }

    public DietDto GetDietById(Guid id)
    {
        return FindByCondition(d => d.Id == id, trackChanges: false)
            .Select(d => new DietDto(d.Id, d.UserId, d.StartDate,
                    d.EndDate, d.TotalCalories, d.NutrientBalanceScore))
            .FirstOrDefault();
    }

    public IReadOnlyCollection<DietWithUserDto> GetAllDiets()
    {
        return FindAll(trackChanges: false)
            .Include(d => d.User)
            .Select(d => new DietWithUserDto(d.Id, d.UserId, d.User.Email, d.StartDate,
                    d.EndDate, d.TotalCalories, d.NutrientBalanceScore))
            .ToList()
            .AsReadOnly();
    }

    public IReadOnlyCollection<DietDto> GetDietsByUserId(Guid userId)
    {
        return FindByCondition(d => d.UserId == userId, trackChanges: false)
            .Select(d => new DietDto(d.Id, d.UserId, d.StartDate, d.EndDate,
                    d.TotalCalories, d.NutrientBalanceScore))
            .ToList()
            .AsReadOnly();
    }
}