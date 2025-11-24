using FluentValidation;
using WebApplication1.DTOs;
using WebApplication1.Data;

namespace WebApplication1.Validators.ProductNutrientValidators;

public class UpdateProductNutrientValidator : AbstractValidator<UpdateProductNutrientDto>
{
    public UpdateProductNutrientValidator()
    {
        RuleFor(x => x.AmountPer100g)
            .GreaterThanOrEqualTo(AppConstants.ProductNutrient.MinAmount).WithMessage("Amount cannot be negative")
            .LessThan(AppConstants.ProductNutrient.MaxAmount).WithMessage($"Amount cannot exceed {AppConstants.ProductNutrient.MaxAmount}");
    }
}