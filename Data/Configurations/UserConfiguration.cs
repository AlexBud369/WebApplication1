using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).ValueGeneratedOnAdd();

        builder.Property(u => u.Email)
               .HasMaxLength(AppConstants.User.EmailMaxLength)
               .IsRequired();

        builder.Property(u => u.PasswordHash)
               .IsRequired();

        builder.Property(u => u.Gender)
               .HasMaxLength(AppConstants.User.GenderMaxLength);

        builder.Property(u => u.ActivityLevel)
               .HasMaxLength(AppConstants.User.ActivityLevelMaxLength);

        builder.Property(u => u.GoalType)
               .HasMaxLength(AppConstants.User.GoalTypeMaxLength);

        builder.Property(u => u.DietaryRestrictions)
               .HasMaxLength(AppConstants.User.DietaryRestrictionsMaxLength);

        builder.HasIndex(u => u.Email)
               .IsUnique();

        builder.HasData(
                new User
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Email = "admin@example.com",
                    PasswordHash = "hashed_password_1",
                    BirthDate = new DateOnly(1990, 1, 1),
                    Gender = "Male",
                    Weight = 80.5m,
                    Height = 180.0m,
                    ActivityLevel = "Moderate",
                    GoalType = "WeightLoss",
                    DietaryRestrictions = null,
                    CreatedAt = DateTime.UtcNow
                },
                new User
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Email = "user@example.com",
                    PasswordHash = "hashed_password_2",
                    BirthDate = new DateOnly(1995, 5, 15),
                    Gender = "Female",
                    Weight = 60.0m,
                    Height = 165.0m,
                    ActivityLevel = "Active",
                    GoalType = "MuscleGain",
                    DietaryRestrictions = "Vegetarian",
                    CreatedAt = DateTime.UtcNow
                }
            );
    }
}