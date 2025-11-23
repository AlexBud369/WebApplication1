namespace WebApplication1.DTOs;

public record MealProductDto(
       Guid Id,
       Guid MealId,
       Guid ProductId,
       decimal QuantityGrams,
       string ProductName,
       decimal TotalCalories
   );