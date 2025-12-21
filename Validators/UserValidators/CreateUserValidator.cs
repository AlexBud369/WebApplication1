using FluentValidation;
using WebApplication1.DTOs;
using WebApplication1.Data;

namespace WebApplication1.Validators.UserValidators;

public class CreateUserValidator : AbstractValidator<CreateUserDto>
{
   


    public CreateUserValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format")
            .MaximumLength(AppConstants.User.EmailMaxLength).WithMessage($"Email cannot exceed {AppConstants.User.EmailMaxLength} characters");

        RuleFor(x => x.PasswordHash)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(AppConstants.User.PasswordMinLength).WithMessage($"Password must be at least {AppConstants.User.PasswordMinLength} characters")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
            .Matches("[0-9]").WithMessage("Password must contain at least one digit")
            .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character");

        RuleFor(x => x.BirthDate)
            .LessThan(DateOnly.FromDateTime(DateTime.Now)).WithMessage("Birth date cannot be in the future")
            .Must(BeValidAge).WithMessage($"Age must be between {AppConstants.User.MinAge} and {AppConstants.User.MaxAge} years");

        RuleFor(x => x.Gender)
            .NotEmpty().WithMessage("Gender is required")
            .Must(g => g == "Male" || g == "Female" || g == "Other").WithMessage("Gender must be Male, Female or Other")
            .MaximumLength(AppConstants.User.GenderMaxLength).WithMessage($"Gender cannot exceed {AppConstants.User.GenderMaxLength} characters");

        RuleFor(x => x.Weight)
            .GreaterThan(AppConstants.User.MinWeight).WithMessage("Weight must be positive")
            .LessThan(AppConstants.User.MaxWeight).WithMessage($"Weight cannot exceed {AppConstants.User.MaxWeight} kg");

        RuleFor(x => x.Height)
            .GreaterThan(AppConstants.User.MinHeight).WithMessage("Height must be positive")
            .LessThan(AppConstants.User.MaxHeight).WithMessage($"Height cannot exceed {AppConstants.User.MaxHeight} cm");

        RuleFor(x => x.ActivityLevel)
            .NotEmpty().WithMessage("Activity level is required")
            .Must(al => new[] { "Sedentary", "Light", "Moderate", "Active", "VeryActive" }.Contains(al))
            .WithMessage("Invalid activity level")
            .MaximumLength(AppConstants.User.ActivityLevelMaxLength).WithMessage($"Activity level cannot exceed {AppConstants.User.ActivityLevelMaxLength} characters");

        RuleFor(x => x.GoalType)
            .NotEmpty().WithMessage("Goal type is required")
            .Must(gt => new[] { "WeightLoss", "WeightGain", "Maintenance", "MuscleGain" }.Contains(gt))
            .WithMessage("Invalid goal type")
            .MaximumLength(AppConstants.User.GoalTypeMaxLength).WithMessage($"Goal type cannot exceed {AppConstants.User.GoalTypeMaxLength} characters");

        RuleFor(x => x.DietaryRestrictions)
            .MaximumLength(AppConstants.User.DietaryRestrictionsMaxLength).WithMessage($"Dietary restrictions cannot exceed {AppConstants.User.DietaryRestrictionsMaxLength} characters");
    }

    private bool BeValidAge(DateOnly birthDate)
    {
        var today = DateOnly.FromDateTime(DateTime.Now);
        var age = today.Year - birthDate.Year;
        if (birthDate > today.AddYears(-age)) age--;

        return age >= AppConstants.User.MinAge && age <= AppConstants.User.MaxAge;
    }
}