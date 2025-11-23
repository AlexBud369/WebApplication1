using WebApplication1.DTOs;

namespace WebApplication1.Repositories.Contracts;

public interface IUserRepository : IRepositoryBase<Models.User>
{
    UserDto GetUserById(Guid id);
    IReadOnlyCollection<UserDto> GetAllUsers();
    UserDto CreateUser(CreateUserDto userDto);
    void UpdateUser(Guid id, UpdateUserDto userDto);
    void DeleteUser(Guid id);
}
