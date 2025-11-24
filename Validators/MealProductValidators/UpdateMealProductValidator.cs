using FluentValidation;
using WebApplication1.DTOs;
using WebApplication1.Data;

namespace WebApplication1.Validators.MealProductValidators;

public class UpdateMealProductValidator : AbstractValidator<UpdateMealProductDto>
{
    public UpdateMealProductValidator()
    {
        RuleFor(x => x.QuantityGrams)
            .GreaterThan(AppConstants.MealProduct.MinQuantity).WithMessage("Quantity must be positive")
            .LessThan(AppConstants.MealProduct.MaxQuantity).WithMessage($"Quantity cannot exceed {AppConstants.MealProduct.MaxQuantity} grams");
    }
}