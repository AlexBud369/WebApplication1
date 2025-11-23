using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();

        builder.Property(p => p.Name)
               .HasMaxLength(AppConstants.Product.NameMaxLength)
               .IsRequired();

        builder.Property(p => p.Category)
               .HasMaxLength(AppConstants.Product.CategoryMaxLength)
               .IsRequired();

        builder.HasData(
             new Product
             {
                 Id = Guid.Parse("b1b1b1b1-b1b1-b1b1-b1b1-b1b1b1b1b1b1"),
                 Name = "Chicken Breast",
                 Category = "Meat",
                 CaloriesPer100G = 165,
                 ProteinPer100G = 31,
                 FatPer100G = 3.6m,
                 CarbsPer100G = 0,
                 IsVerified = true
             },
             new Product
             {
                 Id = Guid.Parse("b2b2b2b2-b2b2-b2b2-b2b2-b2b2b2b2b2b2"),
                 Name = "Brown Rice",
                 Category = "Grains",
                 CaloriesPer100G = 130,
                 ProteinPer100G = 2.7m,
                 FatPer100G = 1.0m,
                 CarbsPer100G = 28,
                 IsVerified = true
             }
         );
    }
}
