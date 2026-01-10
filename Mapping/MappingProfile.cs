using AutoMapper;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<CreateUserDto, User>();
        CreateMap<UpdateUserDto, User>();

        CreateMap<Product, ProductDto>();
        CreateMap<CreateProductDto, Product>();
        CreateMap<UpdateProductDto, Product>();

        CreateMap<Diet, DietDto>();
        CreateMap<Diet, DietWithUserDto>()
            .ForMember(dest => dest.UserEmail,
                opt => opt.MapFrom(src => src.User.Email));
        CreateMap<CreateDietDto, Diet>();
        CreateMap<UpdateDietDto, Diet>();

        CreateMap<Meal, MealDto>();
        CreateMap<CreateMealDto, Meal>();
        CreateMap<UpdateMealDto, Meal>();

        CreateMap<Nutrient, NutrientDto>();
        CreateMap<CreateNutrientDto, Nutrient>();
        CreateMap<UpdateNutrientDto, Nutrient>();

        CreateMap<MealProduct, MealProductDto>()
            .ConstructUsing(src => new MealProductDto(
                src.Id,
                src.MealId,
                src.ProductId,
                src.QuantityGrams,
                src.Product != null ? src.Product.Name : string.Empty,
                src.Product != null ? src.Product.CaloriesPer100G * src.QuantityGrams / 100 : 0));
        CreateMap<CreateMealProductDto, MealProduct>();
        CreateMap<UpdateMealProductDto, MealProduct>();

        CreateMap<ProductNutrient, ProductNutrientDto>()
           .ConstructUsing(src => new ProductNutrientDto(
               src.Id,
               src.ProductId,
               src.NutrientId,
               src.Nutrient != null ? src.Nutrient.Name : string.Empty,
               src.AmountPer100g,
               src.Nutrient != null ? src.Nutrient.Unit : string.Empty));
        CreateMap<CreateProductNutrientDto, ProductNutrient>();
        CreateMap<UpdateProductNutrientDto, ProductNutrient>(); 
    }
}
