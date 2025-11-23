namespace WebApplication1.Models;

public class ProductNutrient
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ProductId { get; set; }
    public Guid NutrientId { get; set; }
    public decimal AmountPer100g { get; set; }

    public Product Product { get; set; } = null!;
    public Nutrient Nutrient { get; set; } = null!;
}
