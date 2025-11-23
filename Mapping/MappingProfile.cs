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
            .ForMember(dest => dest.ProductName,
                opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.TotalCalories,
                opt => opt.MapFrom(src => src.Product.CaloriesPer100G * src.QuantityGrams / 100));
        CreateMap<CreateMealProductDto, MealProduct>();
        CreateMap<UpdateMealProductDto, MealProduct>();

        CreateMap<ProductNutrient, ProductNutrientDto>()
            .ForMember(dest => dest.NutrientName,
                opt => opt.MapFrom(src => src.Nutrient.Name))
            .ForMember(dest => dest.Unit,
                opt => opt.MapFrom(src => src.Nutrient.Unit));
        CreateMap<CreateProductNutrientDto, ProductNutrient>();
        CreateMap<UpdateProductNutrientDto, ProductNutrient>(); 
    }
}
