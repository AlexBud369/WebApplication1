using AutoMapper;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Models;
using WebApplication1.Repositories.Contracts;

namespace WebApplication1.Repositories.Implementations;

public class NutrientRepository : RepositoryBase<Nutrient>, INutrientRepository
{
    private readonly IMapper _mapper;

    public NutrientRepository(AppDbContext context, IMapper mapper) : base(context)
    {
        _mapper = mapper;
    }

    public NutrientDto GetNutrientById(Guid id)
    {
        var nutrient = FindByCondition(n => n.Id == id, trackChanges: false)
            .FirstOrDefault();
        if (nutrient is null) {
            throw new NutrientNotFoundException(id);
        }


        return _mapper.Map<NutrientDto>(nutrient);
    }

    public IReadOnlyCollection<NutrientDto> GetAllNutrients()
    {
        var nutrients = FindAll(trackChanges: false).ToList();

        return _mapper.Map<IReadOnlyCollection<NutrientDto>>(nutrients);
    }

    public NutrientDto CreateNutrient(CreateNutrientDto nutrientDto)
    {
        var nutrientEntity = _mapper.Map<Nutrient>(nutrientDto);
        Create(nutrientEntity);

        return _mapper.Map<NutrientDto>(nutrientEntity);
    }

    public void UpdateNutrient(Guid id, UpdateNutrientDto nutrientDto)
    {
        var nutrientEntity = FindByCondition(n => n.Id == id, trackChanges: true)
            .FirstOrDefault();
        if (nutrientEntity is null){
            throw new NutrientNotFoundException(id);
        }


        _mapper.Map(nutrientDto, nutrientEntity);
        Update(nutrientEntity);
    }

    public void DeleteNutrient(Guid id)
    {
        var nutrientEntity = FindByCondition(n => n.Id == id, trackChanges: false)
            .FirstOrDefault();
        if (nutrientEntity is null) {
            throw new NutrientNotFoundException(id);
        }

        Delete(nutrientEntity);
    }
}