namespace WebApplication1.ViewModels;

public record ProductUsageViewModel(
    Guid ProductId,
    string ProductName,
    string Category,
    bool IsVerified,
    decimal CaloriesPer100G,
    int UsageCount,
    decimal TotalQuantityGrams,
    decimal AverageQuantityPerUse
);