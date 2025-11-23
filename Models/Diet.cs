namespace WebApplication1.Models;

public class Diet
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public decimal TotalCalories { get; set; }
    public int NutrientBalanceScore { get; set; }

    public User User { get; set; } = null!;
    public ICollection<Meal> Meals { get; set; } = new List<Meal>();
}
