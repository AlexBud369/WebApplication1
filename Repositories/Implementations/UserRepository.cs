using AutoMapper;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Models;
using WebApplication1.Repositories.Contracts;

namespace WebApplication1.Repositories.Implementations;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    private readonly IMapper _mapper;
    public UserRepository(AppDbContext context, IMapper mapper) : base(context) {
        _mapper = mapper;
    }

    public UserDto GetUserById(Guid id)
    {
        var user = FindByCondition(u => u.Id == id, trackChanges: false)
                .FirstOrDefault();
        if (user is null) {
            throw new UserNotFoundException(id); 
        }

        return _mapper.Map<UserDto>(user);
    }

    public IReadOnlyCollection<UserDto> GetAllUsers()
    {
        var users = FindAll(trackChanges: false).ToList();

        return _mapper.Map<IReadOnlyCollection<UserDto>>(users);
    }

    public UserDto CreateUser(CreateUserDto userDto)
    {
        var userEntity = _mapper.Map<User>(userDto);
        Create(userEntity);

        return _mapper.Map<UserDto>(userEntity);
    }

    public void UpdateUser(Guid id, UpdateUserDto userDto)
    {
        var userEntity = FindByCondition(u => u.Id == id, trackChanges: true)
            .FirstOrDefault();
        if (userEntity is null) { 
            throw new UserNotFoundException(id);
        }
        _mapper.Map(userDto, userEntity);
        Update(userEntity);
    }

    public void DeleteUser(Guid id)
    {
        var userEntity = FindByCondition(u => u.Id == id, trackChanges: false)
            .FirstOrDefault();
        if (userEntity is null) { 
            throw new UserNotFoundException(id);
        }
        Delete(userEntity);
    }
}