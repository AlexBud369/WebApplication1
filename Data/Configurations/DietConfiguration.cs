using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Data.Configurations;

public class DietConfiguration : IEntityTypeConfiguration<Diet>
{
    public void Configure(EntityTypeBuilder<Diet> builder)
    {
        builder.ToTable("Diet");

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id).ValueGeneratedOnAdd();

        builder.HasOne(d => d.User)
               .WithMany(u => u.Diets)
               .HasForeignKey(d => d.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(
                 new Diet
                 {
                     Id = Guid.Parse("d1d1d1d1-d1d1-d1d1-d1d1-d1d1d1d1d1d1"),
                     UserId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                     StartDate = new DateOnly(2025, 1, 1),
                     EndDate = new DateOnly(2025, 1, 31),
                     TotalCalories = 2100.0m,
                     NutrientBalanceScore = 85
                 },
                 new Diet
                 {
                     Id = Guid.Parse("d2d2d2d2-d2d2-d2d2-d2d2-d2d2d2d2d2d2"),
                     UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                     StartDate = new DateOnly(2025, 2, 1),
                     EndDate = new DateOnly(2025, 2, 28),
                     TotalCalories = 1800.0m,
                     NutrientBalanceScore = 90
                 }
             );
    }
}