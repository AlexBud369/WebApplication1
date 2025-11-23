using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Data.Configurations;

public class MealProductConfiguration : IEntityTypeConfiguration<MealProduct>
{
    public void Configure(EntityTypeBuilder<MealProduct> builder)
    {
        builder.ToTable("MealProduct");

        builder.HasKey(mp => mp.Id);
        builder.Property(mp => mp.Id).ValueGeneratedOnAdd();

        builder.Property(mp => mp.QuantityGrams)
               .HasPrecision(8, 2)
               .IsRequired();

        builder.HasOne(mp => mp.Meal)
               .WithMany(m => m.MealProducts)
               .HasForeignKey(mp => mp.MealId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(mp => mp.Product)
               .WithMany(p => p.MealProducts)
               .HasForeignKey(mp => mp.ProductId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(mp => new { mp.MealId, mp.ProductId })
               .IsUnique();

        builder.HasData(
            new MealProduct
            {
                Id = Guid.Parse("c1c1c1c1-c1c1-c1c1-c1c1-c1c1c1c1c1c1"),
                MealId = Guid.Parse("a1a1a1a1-a1a1-a1a1-a1a1-a1a1a1a1a1a1"),
                ProductId = Guid.Parse("b1b1b1b1-b1b1-b1b1-b1b1-b1b1b1b1b1b1"),
                QuantityGrams = 150
            },
            new MealProduct
            {
                Id = Guid.Parse("c2c2c2c2-c2c2-c2c2-c2c2-c2c2c2c2c2c2"),
                MealId = Guid.Parse("a2a2a2a2-a2a2-a2a2-a2a2-a2a2a2a2a2a2"),
                ProductId = Guid.Parse("b2b2b2b2-b2b2-b2b2-b2b2-b2b2b2b2b2b2"),
                QuantityGrams = 200
            }
        );
    }
}