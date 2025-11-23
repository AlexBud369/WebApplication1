using WebApplication1.DTOs;

namespace WebApplication1.Repositories.Contracts;

public interface IUserRepository : IRepositoryBase<Models.User>
{
    UserDto GetUserById(Guid id);
    IReadOnlyCollection<UserDto> GetAllUsers();
    IReadOnlyCollection<UserSummaryDto> GetUserSummaries();
}
