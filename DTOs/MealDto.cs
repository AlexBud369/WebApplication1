namespace WebApplication1.DTOs;

public record MealDto(
       Guid Id,
       Guid DietId,
       string MealType,
       DateTime MealDate
   );

public record MealWithProductsDto(
    Guid Id,
    Guid DietId,
    string MealType,
    DateTime MealDate,
    IReadOnlyCollection<MealProductDto> MealProducts
);