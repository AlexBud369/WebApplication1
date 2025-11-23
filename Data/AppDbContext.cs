using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Configurations;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Diet> Diets { get; set; }
    public DbSet<Meal> Meals { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<MealProduct> MealProducts { get; set; }
    public DbSet<Nutrient> Nutrients { get; set; }
    public DbSet<ProductNutrient> ProductNutrients { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new DietConfiguration());
        builder.ApplyConfiguration(new MealConfiguration());
        builder.ApplyConfiguration(new ProductConfiguration());
        builder.ApplyConfiguration(new MealProductConfiguration());
        builder.ApplyConfiguration(new NutrientConfiguration());
        builder.ApplyConfiguration(new ProductNutrientConfiguration());

    }
}
