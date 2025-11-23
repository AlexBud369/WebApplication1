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
    }

    public static class Meal
    {
        public const int MealTypeMaxLength = 50;
    }

    public static class Product
    {
        public const int NameMaxLength = 255;
        public const int CategoryMaxLength = 100;
    }

    public static class Nutrient
    {
        public const int NameMaxLength = 255;
        public const int CategoryMaxLength = 100;
        public const int UnitMaxLength = 20;
    }
}
