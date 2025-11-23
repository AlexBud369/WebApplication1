namespace WebApplication1.Models;

public class Product
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public decimal CaloriesPer100G { get; set; }
    public decimal ProteinPer100G { get; set; }
    public decimal FatPer100G { get; set; }
    public decimal CarbsPer100G { get; set; }
    public bool IsVerified { get; set; }

    public ICollection<MealProduct> MealProducts { get; set; } = new List<MealProduct>();
    public ICollection<ProductNutrient> ProductNutrients { get; set; } = new List<ProductNutrient>();
}
