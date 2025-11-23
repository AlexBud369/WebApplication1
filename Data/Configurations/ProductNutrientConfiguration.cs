using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Data.Configurations;

public class ProductNutrientConfiguration : IEntityTypeConfiguration<ProductNutrient>
{
    public void Configure(EntityTypeBuilder<ProductNutrient> builder)
    {
        builder.ToTable("ProductNutrient");

        builder.HasKey(pn => pn.Id);
        builder.Property(pn => pn.Id).ValueGeneratedOnAdd();

        builder.Property(pn => pn.AmountPer100g)
               .HasPrecision(10, 3)
               .IsRequired();

        builder.HasOne(pn => pn.Product)
               .WithMany(p => p.ProductNutrients)
               .HasForeignKey(pn => pn.ProductId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(pn => pn.Nutrient)
               .WithMany(n => n.ProductNutrients)
               .HasForeignKey(pn => pn.NutrientId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(pn => new { pn.ProductId, pn.NutrientId })
               .IsUnique();

        builder.HasData(
            new ProductNutrient
            {
                Id = Guid.Parse("f1f1f1f1-f1f1-f1f1-f1f1-f1f1f1f1f1f1"),
                ProductId = Guid.Parse("b1b1b1b1-b1b1-b1b1-b1b1-b1b1b1b1b1b1"),
                NutrientId = Guid.Parse("e1e1e1e1-e1e1-e1e1-e1e1-e1e1e1e1e1e1"),
                AmountPer100g = 0.5m
            },
            new ProductNutrient
            {
                Id = Guid.Parse("f2f2f2f2-f2f2-f2f2-f2f2-f2f2f2f2f2f2"),
                ProductId = Guid.Parse("b1b1b1b1-b1b1-b1b1-b1b1-b1b1b1b1b1b1"),
                NutrientId = Guid.Parse("e2e2e2e2-e2e2-e2e2-e2e2-e2e2e2e2e2e2"),
                AmountPer100g = 1.2m
            },
            new ProductNutrient
            {
                Id = Guid.Parse("f3f3f3f3-f3f3-f3f3-f3f3-f3f3f3f3f3f3"),
                ProductId = Guid.Parse("b2b2b2b2-b2b2-b2b2-b2b2-b2b2b2b2b2b2"),
                NutrientId = Guid.Parse("e3e3e3e3-e3e3-e3e3-e3e3-e3e3e3e3e3e3"),
                AmountPer100g = 10.0m
            }
        );
    }
}
