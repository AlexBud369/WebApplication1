namespace WebApplication1.Data;

public static class AppConstants
{
    public static class User
    {
        public const int EmailMaxLength = 255;
        public const int GenderMaxLength = 20;
        public const int ActivityLevelMaxLength = 50;
        public const int GoalTypeMaxLength = 50;
        public const int DietaryRestrictionsMaxLength = 500;

        // Validation constants
        public const int MinAge = 18;
        public const int MaxAge = 60;
        public const decimal MinWeight = 0;
        public const decimal MaxWeight = 300;
        public const decimal MinHeight = 0;
        public const decimal MaxHeight = 250;
        public const int PasswordMinLength = 8;
    }

    public static class Meal
    {
        public const int MealTypeMaxLength = 50;
    }

    public static class Product
    {
        public const int NameMaxLength = 255;
        public const int CategoryMaxLength = 100;

        // Validation constants
        public const decimal MinCalories = 0;
        public const decimal MaxCalories = 1000;
        public const decimal MinNutrient = 0;
        public const decimal MaxNutrient = 100;
        public const decimal MaxNutrientSum = 100;
    }

    public static class Nutrient
    {
        public const int NameMaxLength = 255;
        public const int CategoryMaxLength = 100;
        public const int UnitMaxLength = 20;

        // Validation constants
        public const int NameMinLength = 2;
        public const int NameMaxLengthValidation = 50;
        public const int CategoryMaxLengthValidation = 30;
        public const int UnitMaxLengthValidation = 10;
    }

    public static class Diet
    {
        // Validation constants
        public const decimal MinCalories = 0;
        public const decimal MaxCalories = 10000;
        public const int MinNutrientBalanceScore = 0;
        public const int MaxNutrientBalanceScore = 100;
    }

    public static class MealProduct
    {
        // Validation constants
        public const decimal MinQuantity = 0;
        public const decimal MaxQuantity = 10000;
    }

    public static class ProductNutrient
    {
        // Validation constants
        public const decimal MinAmount = 0;
        public const decimal MaxAmount = 1000;
    }
}