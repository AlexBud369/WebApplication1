using WebApplication1.ViewModels;

namespace WebApplication1.Repositories.Contracts;

public interface IProductStatsRepository
{
    IReadOnlyCollection<ProductUsageViewModel> GetProductUsageStats();
    IReadOnlyCollection<ProductUsageViewModel> GetProductUsageByCategory(string category);
}