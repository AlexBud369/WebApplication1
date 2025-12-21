using WebApplication1.ViewModels;

namespace WebApplication1.Repositories.Contracts;

public interface IUserStatsRepository
{
    UserDietStatsViewModel GetUserStats(Guid userId);
    IReadOnlyCollection<UserDietStatsViewModel> GetAllUsersStats();
}