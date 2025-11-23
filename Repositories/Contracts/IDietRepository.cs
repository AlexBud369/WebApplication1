using WebApplication1.DTOs;

namespace WebApplication1.Repositories.Contracts;

public interface IDietRepository : IRepositoryBase<Models.Diet>
{
    DietDto GetDietById(Guid id);
    IReadOnlyCollection<DietWithUserDto> GetAllDiets();
    IReadOnlyCollection<DietDto> GetDietsByUserId(Guid userId);

    DietDto CreateDiet(CreateDietDto dietDto);
    void UpdateDiet(Guid id, UpdateDietDto dietDto);
    void DeleteDiet(Guid id);
}