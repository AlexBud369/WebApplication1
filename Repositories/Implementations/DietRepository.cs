using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Models;
using WebApplication1.Repositories.Contracts;

namespace WebApplication1.Repositories.Implementations;

public class DietRepository : RepositoryBase<Diet>, IDietRepository
{
    private readonly IMapper _mapper;
    public DietRepository(AppDbContext context, IMapper mapper) : base(context) {
        _mapper = mapper;
    }

    public DietDto GetDietById(Guid id)
    {
        var diet = FindByCondition(d => d.Id == id, trackChanges: false)
               .FirstOrDefault();
        if (diet is null) {
            throw new DietNotFoundException(id);
        }

        return _mapper.Map<DietDto>(diet);
    }

    public IReadOnlyCollection<DietWithUserDto> GetAllDiets()
    {
        var diets = FindAll(trackChanges: false)
                .Include(d => d.User)
                .ToList();

        return _mapper.Map<IReadOnlyCollection<DietWithUserDto>>(diets);
    }

    public IReadOnlyCollection<DietDto> GetDietsByUserId(Guid userId)
    {
        var diets = FindByCondition(d => d.UserId == userId, trackChanges: false).ToList();

        return _mapper.Map<IReadOnlyCollection<DietDto>>(diets);
    }

    public DietDto CreateDiet(CreateDietDto dietDto)
    {
        var userExists = _context.Users.Any(u => u.Id == dietDto.UserId);
        if (!userExists)
        {
            throw new InvalidRequestException($"User with id {dietDto.UserId} does not exist");
        }

        var dietEntity = _mapper.Map<Diet>(dietDto);
        Create(dietEntity);

        return _mapper.Map<DietDto>(dietEntity);
    }

    public void UpdateDiet(Guid id, UpdateDietDto dietDto)
    {
        var dietEntity = FindByCondition(d => d.Id == id, trackChanges: true)
            .FirstOrDefault();
        if (dietEntity is null) {
            throw new DietNotFoundException(id);
        }

        _mapper.Map(dietDto, dietEntity);
        Update(dietEntity);
    }

    public void DeleteDiet(Guid id)
    {
        var dietEntity = FindByCondition(d => d.Id == id, trackChanges: false)
            .FirstOrDefault();
        if (dietEntity is null) {
            throw new DietNotFoundException(id);
        }
           

        Delete(dietEntity);
    }
}