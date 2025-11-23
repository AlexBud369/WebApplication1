namespace WebApplication1.DTOs;

public record ProductDto(
       Guid Id,
       string Name,
       string Category,
       decimal CaloriesPer100G,
       decimal ProteinPer100G,
       decimal FatPer100G,
       decimal CarbsPer100G,
       bool IsVerified
   );

public record ProductSummaryDto(
    Guid Id,
    string Name,
    string Category,
    decimal CaloriesPer100G
);
