using FluentValidation;
using WebApplication1.DTOs;
using WebApplication1.Data;

namespace WebApplication1.Validators.MealValidators;

public class CreateMealValidator : AbstractValidator<CreateMealDto>
{
    public CreateMealValidator()
    {
        RuleFor(x => x.DietId)
            .NotEmpty().WithMessage("Diet ID is required");

        RuleFor(x => x.MealType)
            .NotEmpty().WithMessage("Meal type is required")
            .Must(mt => new[] { "Breakfast", "Lunch", "Dinner", "Snack" }.Contains(mt))
            .WithMessage("Meal type must be Breakfast, Lunch, Dinner or Snack")
            .MaximumLength(AppConstants.Meal.MealTypeMaxLength).WithMessage($"Meal type cannot exceed {AppConstants.Meal.MealTypeMaxLength} characters");

        RuleFor(x => x.MealDate)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Meal date cannot be in the future")
            .GreaterThan(DateTime.Now.AddYears(-1)).WithMessage("Meal date cannot be more than one year ago");
    }
}