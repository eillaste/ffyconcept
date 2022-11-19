using AutoMapper;
using BLL.App.DTO.Identity;

namespace BLL.App.DTO.MappingProfiles
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AppUser, DAL.App.DTO.Identity.AppUser>().ReverseMap();
            CreateMap<AgeGroup, DAL.App.DTO.AgeGroup>().ReverseMap();
            CreateMap<Category, DAL.App.DTO.Category>().ReverseMap();
            CreateMap<ConsumedFoodItem, DAL.App.DTO.ConsumedFoodItem>().ReverseMap();
            CreateMap<ConsumedNutrient, DAL.App.DTO.ConsumedNutrient>().ReverseMap();
            CreateMap<Diet, DAL.App.DTO.Diet>().ReverseMap();
            CreateMap<DietaryRestriction, DAL.App.DTO.DietaryRestriction>().ReverseMap();
            CreateMap<DishInMenu, DAL.App.DTO.DishInMenu>().ReverseMap();
            CreateMap<DishInOrder, DAL.App.DTO.DishInOrder>().ReverseMap();
            CreateMap<FoodItem, DAL.App.DTO.FoodItem>().ReverseMap();
            CreateMap<HealthSpecification, DAL.App.DTO.HealthSpecification>().ReverseMap();
            CreateMap<HealthSpecificationNutrient, DAL.App.DTO.HealthSpecificationNutrient>().ReverseMap();
            CreateMap<Ingredient, DAL.App.DTO.Ingredient>().ReverseMap();
            CreateMap<Invoice, DAL.App.DTO.Invoice>().ReverseMap();
            CreateMap<Menu, DAL.App.DTO.Menu>().ReverseMap();
            CreateMap<Nutrient, DAL.App.DTO.Nutrient>().ReverseMap();
            CreateMap<NutrientInFoodItem, DAL.App.DTO.NutrientInFoodItem>().ReverseMap();
            CreateMap<NutrientInSupplement, DAL.App.DTO.NutrientInSupplement>().ReverseMap();
            CreateMap<Order, DAL.App.DTO.Order>().ReverseMap();
            CreateMap<PersonAllergen, DAL.App.DTO.PersonAllergen>().ReverseMap();
            CreateMap<PersonDiet, DAL.App.DTO.PersonDiet>().ReverseMap();
            CreateMap<PersonFavoriteRecipe, DAL.App.DTO.PersonFavoriteRecipe>().ReverseMap();
            CreateMap<PersonHealthSpecification, DAL.App.DTO.PersonHealthSpecification>().ReverseMap();
            CreateMap<PersonRecommendedDietaryIntake, DAL.App.DTO.PersonRecommendedDietaryIntake>().ReverseMap();
            CreateMap<PersonSupplement, DAL.App.DTO.PersonSupplement>().ReverseMap();
            CreateMap<Recipe, DAL.App.DTO.Recipe>().ReverseMap();
            CreateMap<RecipeTag, DAL.App.DTO.RecipeTag>().ReverseMap();
            CreateMap<RecommendedDietaryIntake, DAL.App.DTO.RecommendedDietaryIntake>().ReverseMap();
            CreateMap<Restaurant, DAL.App.DTO.Restaurant>().ReverseMap();
            CreateMap<StandardUnit, DAL.App.DTO.StandardUnit>().ReverseMap();
            CreateMap<State, DAL.App.DTO.State>().ReverseMap();
            CreateMap<Stock, DAL.App.DTO.Stock>().ReverseMap();
            CreateMap<Supplement, DAL.App.DTO.Supplement>().ReverseMap();
            CreateMap<Tag, DAL.App.DTO.Tag>().ReverseMap();
            CreateMap<TolerableUpperIntakeLevel, DAL.App.DTO.TolerableUpperIntakeLevel>().ReverseMap();
            CreateMap<AppUser, DAL.App.DTO.Identity.AppUser>().ReverseMap();
            CreateMap<AppRole, DAL.App.DTO.Identity.AppRole>().ReverseMap();
        }
    }
}