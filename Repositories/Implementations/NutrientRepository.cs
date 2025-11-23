using WebApplication1.DTOs;
using WebApplication1.Repositories.Contracts;
using WebApplication1.Models;
using WebApplication1.Data;

namespace WebApplication1.Repositories.Implementations;

public class NutrientRepository : RepositoryBase<Nutrient>, INutrientRepository
{
    public NutrientRepository(AppDbContext context) : base(context) { }

    public NutrientDto GetNutrientById(Guid id)
    {
        return FindByCondition(n => n.Id == id, trackChanges: false)
            .Select(n => new NutrientDto(n.Id, n.Name, n.Category, n.Unit))
            .FirstOrDefault();
    }

    public IReadOnlyCollection<NutrientDto> GetAllNutrients()
    {
        return FindAll(trackChanges: false)
            .Select(n => new NutrientDto(n.Id, n.Name, n.Category, n.Unit))
            .ToList()
            .AsReadOnly();
    }

    public IReadOnlyCollection<NutrientSummaryDto> GetNutrientSummaries()
    {
        return FindAll(trackChanges: false)
            .Select(n => new NutrientSummaryDto(n.Id, n.Name, n.Unit))
            .ToList()
            .AsReadOnly();
    }
}