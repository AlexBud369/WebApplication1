namespace WebApplication1.DTOs;

public record CreateUserDto(
       string Email,
       string PasswordHash,
       DateOnly BirthDate,
       string Gender,
       decimal Weight,
       decimal Height,
       string ActivityLevel,
       string GoalType,
       string? DietaryRestrictions
   );

public record UpdateUserDto(
    string Email,
    DateOnly BirthDate,
    string Gender,
    decimal Weight,
    decimal Height,
    string ActivityLevel,
    string GoalType,
    string? DietaryRestrictions
);

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