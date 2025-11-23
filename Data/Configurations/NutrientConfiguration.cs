using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Data.Configurations;

public class NutrientConfiguration : IEntityTypeConfiguration<Nutrient>
{
    public void Configure(EntityTypeBuilder<Nutrient> builder)
    {
        builder.ToTable("Nutrient");

        builder.HasKey(n => n.Id);
        builder.Property(n => n.Id).ValueGeneratedOnAdd();

        builder.Property(n => n.Name)
               .HasMaxLength(AppConstants.Nutrient.NameMaxLength)
               .IsRequired();

        builder.Property(n => n.Category)
               .HasMaxLength(AppConstants.Nutrient.CategoryMaxLength)
               .IsRequired();

        builder.Property(n => n.Unit)
               .HasMaxLength(AppConstants.Nutrient.UnitMaxLength)
               .IsRequired();

        builder.HasIndex(n => n.Name)
               .IsUnique();

        builder.HasData(
            new Nutrient
            {
                Id = Guid.Parse("e1e1e1e1-e1e1-e1e1-e1e1-e1e1e1e1e1e1"),
                Name = "Vitamin C",
                Category = "Vitamins",
                Unit = "mg"
            },
            new Nutrient
            {
                Id = Guid.Parse("e2e2e2e2-e2e2-e2e2-e2e2-e2e2e2e2e2e2"),
                Name = "Iron",
                Category = "Minerals",
                Unit = "mg"
            },
            new Nutrient
            {
                Id = Guid.Parse("e3e3e3e3-e3e3-e3e3-e3e3-e3e3e3e3e3e3"),
                Name = "Calcium",
                Category = "Minerals",
                Unit = "mg"
            }
        );
    }
}
