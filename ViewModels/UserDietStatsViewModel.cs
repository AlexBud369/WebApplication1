namespace WebApplication1.ViewModels;

public record UserDietStatsViewModel(
    Guid UserId,
    string UserEmail,
    int Age,
    string Gender,
    int TotalDiets,
    int TotalMeals,
    decimal AverageCaloriesPerDiet,
    int AverageNutrientScore
);