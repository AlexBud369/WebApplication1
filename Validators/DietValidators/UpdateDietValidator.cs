using FluentValidation;
using WebApplication1.DTOs;
using WebApplication1.Data;

namespace WebApplication1.Validators.DietValidators;

public class UpdateDietValidator : AbstractValidator<UpdateDietDto>
{
    public UpdateDietValidator()
    {
        RuleFor(x => x.StartDate)
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now))
            .WithMessage("Start date cannot be in the past");

        RuleFor(x => x.EndDate)
            .GreaterThan(x => x.StartDate)
            .WithMessage("End date must be after start date");

        RuleFor(x => x.TotalCalories)
            .GreaterThan(AppConstants.Diet.MinCalories).WithMessage("Calories must be positive")
            .LessThan(AppConstants.Diet.MaxCalories).WithMessage($"Calories cannot exceed {AppConstants.Diet.MaxCalories}");

        RuleFor(x => x.NutrientBalanceScore)
            .InclusiveBetween(AppConstants.Diet.MinNutrientBalanceScore, AppConstants.Diet.MaxNutrientBalanceScore)
            .WithMessage($"Nutrient balance score must be between {AppConstants.Diet.MinNutrientBalanceScore} and {AppConstants.Diet.MaxNutrientBalanceScore}");
    }
}