using FluentValidation;
using WebApplication1.DTOs;
using WebApplication1.Data;

namespace WebApplication1.Validators.MealProductValidators;

public class CreateMealProductValidator : AbstractValidator<CreateMealProductDto>
{
    public CreateMealProductValidator()
    {
        RuleFor(x => x.MealId)
            .NotEmpty().WithMessage("Meal ID is required");

        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage("Product ID is required");

        RuleFor(x => x.QuantityGrams)
            .GreaterThan(AppConstants.MealProduct.MinQuantity).WithMessage("Quantity must be positive")
            .LessThan(AppConstants.MealProduct.MaxQuantity).WithMessage($"Quantity cannot exceed {AppConstants.MealProduct.MaxQuantity} grams");
    }
}