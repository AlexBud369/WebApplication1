namespace WebApplication1.DTOs;

public record CreateMealProductDto(
       Guid MealId,
       Guid ProductId,
       decimal QuantityGrams
   );

public record UpdateMealProductDto(
    decimal QuantityGrams
);

public record MealProductDto(
       Guid Id,
       Guid MealId,
       Guid ProductId,
       decimal QuantityGrams,
       string ProductName,
       decimal TotalCalories
   );