namespace WebApplication1.ViewModels;

public record DailyNutritionViewModel(
    DateOnly Date,
    Guid UserId,
    string UserEmail,
    decimal TotalCalories,
    decimal TotalProtein,
    decimal TotalFat,
    decimal TotalCarbs,
    int MealCount
);