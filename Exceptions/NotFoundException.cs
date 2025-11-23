namespace WebApplication1.Exceptions;

public abstract class NotFoundException : Exception
{
    protected NotFoundException(string message) : base(message) { }
}

public sealed class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(Guid userId)
        : base($"User with id: {userId} doesn't exist in the database.") { }
}

public sealed class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException(Guid productId)
        : base($"Product with id: {productId} doesn't exist in the database.") { }
}

public sealed class DietNotFoundException : NotFoundException
{
    public DietNotFoundException(Guid dietId)
        : base($"Diet with id: {dietId} doesn't exist in the database.") { }
}

public sealed class MealNotFoundException : NotFoundException
{
    public MealNotFoundException(Guid mealId)
        : base($"Meal with id: {mealId} doesn't exist in the database.") { }
}

public sealed class NutrientNotFoundException : NotFoundException
{
    public NutrientNotFoundException(Guid nutrientId)
        : base($"Nutrient with id: {nutrientId} doesn't exist in the database.") { }
}

public sealed class MealProductNotFoundException : NotFoundException
{
    public MealProductNotFoundException(Guid mealProductId)
        : base($"MealProduct with id: {mealProductId} doesn't exist in the database.") { }
}

public sealed class ProductNutrientNotFoundException : NotFoundException
{
    public ProductNutrientNotFoundException(Guid productNutrientId)
        : base($"ProductNutrient with id: {productNutrientId} doesn't exist in the database.") { }
}