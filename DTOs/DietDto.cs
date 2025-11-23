namespace WebApplication1.DTOs;

public record DietDto(
    Guid Id,
    Guid UserId,
    DateOnly StartDate,
    DateOnly EndDate,
    decimal TotalCalories,
    int NutrientBalanceScore
);

public record DietWithUserDto(
    Guid Id,
    Guid UserId,
    string UserEmail,
    DateOnly StartDate,
    DateOnly EndDate,
    decimal TotalCalories,
    int NutrientBalanceScore
);