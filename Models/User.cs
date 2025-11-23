namespace WebApplication1.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public DateOnly BirthDate { get; set; }
    public string Gender { get; set; } = string.Empty;
    public decimal Weight { get; set; }
    public decimal Height { get; set; }
    public string ActivityLevel { get; set; } = string.Empty;
    public string GoalType { get; set; } = string.Empty;
    public string? DietaryRestrictions { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Diet> Diets { get; set; } = new List<Diet>();
}