using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Nutrient",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Category = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Unit = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutrient", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Category = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CaloriesPer100G = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ProteinPer100G = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    FatPer100G = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CarbsPer100G = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    IsVerified = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Weight = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ActivityLevel = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GoalType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DietaryRestrictions = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductNutrient",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProductId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NutrientId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AmountPer100g = table.Column<decimal>(type: "decimal(10,3)", precision: 10, scale: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductNutrient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductNutrient_Nutrient_NutrientId",
                        column: x => x.NutrientId,
                        principalTable: "Nutrient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductNutrient_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Diet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    TotalCalories = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    NutrientBalanceScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diet_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Meal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DietId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MealType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MealDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meal_Diet_DietId",
                        column: x => x.DietId,
                        principalTable: "Diet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MealProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MealId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProductId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    QuantityGrams = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealProduct_Meal_MealId",
                        column: x => x.MealId,
                        principalTable: "Meal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Nutrient",
                columns: new[] { "Id", "Category", "Name", "Unit" },
                values: new object[,]
                {
                    { new Guid("e1e1e1e1-e1e1-e1e1-e1e1-e1e1e1e1e1e1"), "Vitamins", "Vitamin C", "mg" },
                    { new Guid("e2e2e2e2-e2e2-e2e2-e2e2-e2e2e2e2e2e2"), "Minerals", "Iron", "mg" },
                    { new Guid("e3e3e3e3-e3e3-e3e3-e3e3-e3e3e3e3e3e3"), "Minerals", "Calcium", "mg" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CaloriesPer100G", "CarbsPer100G", "Category", "FatPer100G", "IsVerified", "Name", "ProteinPer100G" },
                values: new object[,]
                {
                    { new Guid("b1b1b1b1-b1b1-b1b1-b1b1-b1b1b1b1b1b1"), 165m, 0m, "Meat", 3.6m, true, "Chicken Breast", 31m },
                    { new Guid("b2b2b2b2-b2b2-b2b2-b2b2-b2b2b2b2b2b2"), 130m, 28m, "Grains", 1.0m, true, "Brown Rice", 2.7m }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "ActivityLevel", "BirthDate", "CreatedAt", "DietaryRestrictions", "Email", "Gender", "GoalType", "Height", "PasswordHash", "Weight" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Moderate", new DateOnly(1990, 1, 1), new DateTime(2025, 11, 22, 11, 46, 34, 63, DateTimeKind.Utc).AddTicks(2037), null, "admin@example.com", "Male", "WeightLoss", 180.0m, "hashed_password_1", 80.5m },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Active", new DateOnly(1995, 5, 15), new DateTime(2025, 11, 22, 11, 46, 34, 63, DateTimeKind.Utc).AddTicks(2041), "Vegetarian", "user@example.com", "Female", "MuscleGain", 165.0m, "hashed_password_2", 60.0m }
                });

            migrationBuilder.InsertData(
                table: "Diet",
                columns: new[] { "Id", "EndDate", "NutrientBalanceScore", "StartDate", "TotalCalories", "UserId" },
                values: new object[,]
                {
                    { new Guid("d1d1d1d1-d1d1-d1d1-d1d1-d1d1d1d1d1d1"), new DateOnly(2025, 1, 31), 85, new DateOnly(2025, 1, 1), 2100.0m, new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("d2d2d2d2-d2d2-d2d2-d2d2-d2d2d2d2d2d2"), new DateOnly(2025, 2, 28), 90, new DateOnly(2025, 2, 1), 1800.0m, new Guid("22222222-2222-2222-2222-222222222222") }
                });

            migrationBuilder.InsertData(
                table: "ProductNutrient",
                columns: new[] { "Id", "AmountPer100g", "NutrientId", "ProductId" },
                values: new object[,]
                {
                    { new Guid("f1f1f1f1-f1f1-f1f1-f1f1-f1f1f1f1f1f1"), 0.5m, new Guid("e1e1e1e1-e1e1-e1e1-e1e1-e1e1e1e1e1e1"), new Guid("b1b1b1b1-b1b1-b1b1-b1b1-b1b1b1b1b1b1") },
                    { new Guid("f2f2f2f2-f2f2-f2f2-f2f2-f2f2f2f2f2f2"), 1.2m, new Guid("e2e2e2e2-e2e2-e2e2-e2e2-e2e2e2e2e2e2"), new Guid("b1b1b1b1-b1b1-b1b1-b1b1-b1b1b1b1b1b1") },
                    { new Guid("f3f3f3f3-f3f3-f3f3-f3f3-f3f3f3f3f3f3"), 10.0m, new Guid("e3e3e3e3-e3e3-e3e3-e3e3-e3e3e3e3e3e3"), new Guid("b2b2b2b2-b2b2-b2b2-b2b2-b2b2b2b2b2b2") }
                });

            migrationBuilder.InsertData(
                table: "Meal",
                columns: new[] { "Id", "DietId", "MealDate", "MealType" },
                values: new object[,]
                {
                    { new Guid("a1a1a1a1-a1a1-a1a1-a1a1-a1a1a1a1a1a1"), new Guid("d1d1d1d1-d1d1-d1d1-d1d1-d1d1d1d1d1d1"), new DateTime(2025, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "Breakfast" },
                    { new Guid("a2a2a2a2-a2a2-a2a2-a2a2-a2a2a2a2a2a2"), new Guid("d1d1d1d1-d1d1-d1d1-d1d1-d1d1d1d1d1d1"), new DateTime(2025, 1, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), "Lunch" }
                });

            migrationBuilder.InsertData(
                table: "MealProduct",
                columns: new[] { "Id", "MealId", "ProductId", "QuantityGrams" },
                values: new object[,]
                {
                    { new Guid("c1c1c1c1-c1c1-c1c1-c1c1-c1c1c1c1c1c1"), new Guid("a1a1a1a1-a1a1-a1a1-a1a1-a1a1a1a1a1a1"), new Guid("b1b1b1b1-b1b1-b1b1-b1b1-b1b1b1b1b1b1"), 150m },
                    { new Guid("c2c2c2c2-c2c2-c2c2-c2c2-c2c2c2c2c2c2"), new Guid("a2a2a2a2-a2a2-a2a2-a2a2-a2a2a2a2a2a2"), new Guid("b2b2b2b2-b2b2-b2b2-b2b2-b2b2b2b2b2b2"), 200m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diet_UserId",
                table: "Diet",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Meal_DietId",
                table: "Meal",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_MealProduct_MealId_ProductId",
                table: "MealProduct",
                columns: new[] { "MealId", "ProductId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MealProduct_ProductId",
                table: "MealProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Nutrient_Name",
                table: "Nutrient",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductNutrient_NutrientId",
                table: "ProductNutrient",
                column: "NutrientId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductNutrient_ProductId_NutrientId",
                table: "ProductNutrient",
                columns: new[] { "ProductId", "NutrientId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealProduct");

            migrationBuilder.DropTable(
                name: "ProductNutrient");

            migrationBuilder.DropTable(
                name: "Meal");

            migrationBuilder.DropTable(
                name: "Nutrient");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Diet");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
