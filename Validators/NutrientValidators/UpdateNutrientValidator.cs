using FluentValidation;
using WebApplication1.DTOs;
using WebApplication1.Data;

namespace WebApplication1.Validators.NutrientValidators;

public class UpdateNutrientValidator : AbstractValidator<UpdateNutrientDto>
{
    public UpdateNutrientValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nutrient name is required")
            .Length(AppConstants.Nutrient.NameMinLength, AppConstants.Nutrient.NameMaxLengthValidation)
            .WithMessage($"Nutrient name must be between {AppConstants.Nutrient.NameMinLength} and {AppConstants.Nutrient.NameMaxLengthValidation} characters");

        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("Category is required")
            .MaximumLength(AppConstants.Nutrient.CategoryMaxLengthValidation)
            .WithMessage($"Category cannot exceed {AppConstants.Nutrient.CategoryMaxLengthValidation} characters");

        RuleFor(x => x.Unit)
            .NotEmpty().WithMessage("Unit is required")
            .MaximumLength(AppConstants.Nutrient.UnitMaxLengthValidation)
            .WithMessage($"Unit cannot exceed {AppConstants.Nutrient.UnitMaxLengthValidation} characters");
    }
}