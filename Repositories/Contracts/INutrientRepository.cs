using WebApplication1.DTOs;

namespace WebApplication1.Repositories.Contracts;

public interface INutrientRepository : IRepositoryBase<Models.Nutrient>
{
    NutrientDto GetNutrientById(Guid id);
    IReadOnlyCollection<NutrientDto> GetAllNutrients();
    NutrientDto CreateNutrient(CreateNutrientDto nutrientDto);
    void UpdateNutrient(Guid id, UpdateNutrientDto nutrientDto);
    void DeleteNutrient(Guid id);
}