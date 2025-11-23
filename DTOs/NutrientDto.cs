namespace WebApplication1.DTOs;
public record NutrientDto(
    Guid Id,
    string Name,
    string Category,
    string Unit
);

public record CreateNutrientDto(
    string Name,
    string Category,
    string Unit
);

public record UpdateNutrientDto(
        string Name,
        string Category,
        string Unit
    );
