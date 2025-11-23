using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Data.Configurations;

public class MealConfiguration : IEntityTypeConfiguration<Meal>
{
    public void Configure(EntityTypeBuilder<Meal> builder)
    {
        builder.ToTable("Meal");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).ValueGeneratedOnAdd();

        builder.Property(m => m.MealType)
               .HasMaxLength(AppConstants.Meal.MealTypeMaxLength)
               .IsRequired();

        builder.HasOne(m => m.Diet)
               .WithMany(d => d.Meals)
               .HasForeignKey(m => m.DietId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(
             new Meal
             {
                 Id = Guid.Parse("a1a1a1a1-a1a1-a1a1-a1a1-a1a1a1a1a1a1"),
                 DietId = Guid.Parse("d1d1d1d1-d1d1-d1d1-d1d1-d1d1d1d1d1d1"),
                 MealType = "Breakfast",
                 MealDate = new DateTime(2025, 1, 1, 8, 0, 0)
             },
             new Meal
             {
                 Id = Guid.Parse("a2a2a2a2-a2a2-a2a2-a2a2-a2a2a2a2a2a2"),
                 DietId = Guid.Parse("d1d1d1d1-d1d1-d1d1-d1d1-d1d1d1d1d1d1"),
                 MealType = "Lunch",
                 MealDate = new DateTime(2025, 1, 1, 13, 0, 0)
             }
         );
    }
}