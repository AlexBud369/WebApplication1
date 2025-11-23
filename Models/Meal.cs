namespace WebApplication1.Models;

public class Meal
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid DietId { get; set; }
    public string MealType { get; set; } = string.Empty;
    public DateTime MealDate { get; set; }

    public Diet Diet { get; set; } = null!;
    public ICollection<MealProduct> MealProducts { get; set; } = new List<MealProduct>();
}