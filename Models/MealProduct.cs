namespace WebApplication1.Models;

public class MealProduct
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid MealId { get; set; }
    public Guid ProductId { get; set; }
    public decimal QuantityGrams { get; set; }

    public Meal Meal { get; set; } = null!;
    public Product Product { get; set; } = null!;
}
