namespace WebApplication1.DTOs;

public record UserDto(
       Guid Id,
       string Email,
       DateOnly BirthDate,
       string Gender,
       decimal Weight,
       decimal Height,
       string ActivityLevel,
       string GoalType,
       string? DietaryRestrictions,
       DateTime CreatedAt
   );

public record UserSummaryDto(
    Guid Id,
    string Email,
    string Gender,
    decimal Weight,
    decimal Height
);
