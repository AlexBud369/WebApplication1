namespace WebApplication1.DTOs;

public record ProductNutrientDto(
    Guid Id,
    Guid ProductId,
    Guid NutrientId,
    string NutrientName,
    decimal AmountPer100g,
    string Unit
);

public record CreateProductNutrientDto(
    Guid ProductId,
    Guid NutrientId,
    decimal AmountPer100g
);

public record UpdateProductNutrientDto(
    decimal AmountPer100g
);