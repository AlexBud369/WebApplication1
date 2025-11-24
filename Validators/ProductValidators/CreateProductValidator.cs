using FluentValidation;
using WebApplication1.DTOs;
using WebApplication1.Data;

namespace WebApplication1.Validators.ProductValidators;

public class CreateProductValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Product name is required")
            .MaximumLength(AppConstants.Product.NameMaxLength)
            .WithMessage($"Product name cannot exceed {AppConstants.Product.NameMaxLength} characters");

        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("Category is required")
            .MaximumLength(AppConstants.Product.CategoryMaxLength)
            .WithMessage($"Category cannot exceed {AppConstants.Product.CategoryMaxLength} characters");

        RuleFor(x => x.CaloriesPer100G)
            .GreaterThanOrEqualTo(AppConstants.Product.MinCalories)
            .WithMessage("Calories cannot be negative")
            .LessThan(AppConstants.Product.MaxCalories)
            .WithMessage($"Calories cannot exceed {AppConstants.Product.MaxCalories} per 100g");

        RuleFor(x => x.ProteinPer100G)
            .GreaterThanOrEqualTo(AppConstants.Product.MinNutrient)
            .WithMessage("Protein cannot be negative")
            .LessThan(AppConstants.Product.MaxNutrient)
            .WithMessage($"Protein cannot exceed {AppConstants.Product.MaxNutrient}g per 100g");

        RuleFor(x => x.FatPer100G)
            .GreaterThanOrEqualTo(AppConstants.Product.MinNutrient)
            .WithMessage("Fat cannot be negative")
            .LessThan(AppConstants.Product.MaxNutrient)
            .WithMessage($"Fat cannot exceed {AppConstants.Product.MaxNutrient}g per 100g");

        RuleFor(x => x.CarbsPer100G)
            .GreaterThanOrEqualTo(AppConstants.Product.MinNutrient)
            .WithMessage("Carbs cannot be negative")
            .LessThan(AppConstants.Product.MaxNutrient)
            .WithMessage($"Carbs cannot exceed {AppConstants.Product.MaxNutrient}g per 100g");

        RuleFor(x => x)
            .Must(HaveValidNutrientSum)
            .WithMessage($"Sum of protein, fat and carbs cannot exceed {AppConstants.Product.MaxNutrientSum}g per 100g of product");
    }

    private bool HaveValidNutrientSum(CreateProductDto product)
    {
        var total = product.ProteinPer100G + product.FatPer100G + product.CarbsPer100G;
        return total <= AppConstants.Product.MaxNutrientSum;
    }
}