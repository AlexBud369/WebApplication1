namespace WebApplication1.Models;

public class Nutrient
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Unit { get; set; } = string.Empty;

    public ICollection<ProductNutrient> ProductNutrients { get; set; } = new List<ProductNutrient>();
}
