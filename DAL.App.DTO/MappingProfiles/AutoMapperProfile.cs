using AutoMapper;

namespace DAL.App.DTO.MappingProfiles
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DAL.App.DTO.Identity.AppUser, Domain.App.Identity.AppUser>().ReverseMap();
            CreateMap<DAL.App.DTO.AgeGroup, Domain.App.AgeGroup>().ReverseMap();
            CreateMap<DAL.App.DTO.Category, Domain.App.Category>().ReverseMap();
            CreateMap<DAL.App.DTO.ConsumedFoodItem, Domain.App.ConsumedFoodItem>().ReverseMap();
            CreateMap<DAL.App.DTO.ConsumedNutrient, Domain.App.ConsumedNutrient>().ReverseMap();
            CreateMap<DAL.App.DTO.Diet, Domain.App.Diet>().ReverseMap();
            CreateMap<DAL.App.DTO.DietaryRestriction, Domain.App.DietaryRestriction>().ReverseMap();
            CreateMap<DAL.App.DTO.DishInMenu, Domain.App.DishInMenu>().ReverseMap();
            CreateMap<DAL.App.DTO.DishInOrder, Domain.App.DishInOrder>().ReverseMap();
            CreateMap<DAL.App.DTO.FoodItem, Domain.App.FoodItem>().ReverseMap();
            CreateMap<DAL.App.DTO.HealthSpecification, Domain.App.HealthSpecification>().ReverseMap();
            CreateMap<DAL.App.DTO.HealthSpecificationNutrient, Domain.App.HealthSpecificationNutrient>().ReverseMap();
            CreateMap<DAL.App.DTO.Ingredient, Domain.App.Ingredient>().ReverseMap();
            CreateMap<DAL.App.DTO.Invoice, Domain.App.Invoice>().ReverseMap();
            CreateMap<DAL.App.DTO.Menu, Domain.App.Menu>().ReverseMap();
            CreateMap<DAL.App.DTO.Nutrient, Domain.App.Nutrient>().ReverseMap();
            CreateMap<DAL.App.DTO.NutrientInFoodItem, Domain.App.NutrientInFoodItem>().ReverseMap();
            CreateMap<DAL.App.DTO.NutrientInSupplement, Domain.App.NutrientInSupplement>().ReverseMap();
            CreateMap<DAL.App.DTO.Order, Domain.App.Order>().ReverseMap();
            CreateMap<DAL.App.DTO.PersonAllergen, Domain.App.PersonAllergen>().ReverseMap();
            CreateMap<DAL.App.DTO.PersonDiet, Domain.App.PersonDiet>().ReverseMap();
            CreateMap<DAL.App.DTO.PersonFavoriteRecipe, Domain.App.PersonFavoriteRecipe>().ReverseMap();
            CreateMap<DAL.App.DTO.PersonHealthSpecification, Domain.App.PersonHealthSpecification>().ReverseMap();
            CreateMap<DAL.App.DTO.PersonRecommendedDietaryIntake, Domain.App.PersonRecommendedDietaryIntake>().ReverseMap();
            CreateMap<DAL.App.DTO.PersonSupplement, Domain.App.PersonSupplement>().ReverseMap();
            CreateMap<DAL.App.DTO.Recipe, Domain.App.Recipe>().ReverseMap();
            CreateMap<DAL.App.DTO.RecipeTag, Domain.App.RecipeTag>().ReverseMap();
            CreateMap<DAL.App.DTO.RecommendedDietaryIntake, Domain.App.RecommendedDietaryIntake>().ReverseMap();
            CreateMap<DAL.App.DTO.Restaurant, Domain.App.Restaurant>().ReverseMap();
            CreateMap<DAL.App.DTO.StandardUnit, Domain.App.StandardUnit>().ReverseMap();
            CreateMap<DAL.App.DTO.State, Domain.App.State>().ReverseMap();
            CreateMap<DAL.App.DTO.Stock, Domain.App.Stock>().ReverseMap();
            CreateMap<DAL.App.DTO.Supplement, Domain.App.Supplement>().ReverseMap();
            CreateMap<DAL.App.DTO.Tag, Domain.App.Tag>().ReverseMap();
            CreateMap<DAL.App.DTO.TolerableUpperIntakeLevel, Domain.App.TolerableUpperIntakeLevel>().ReverseMap();
            CreateMap<DAL.App.DTO.Identity.AppUser, Domain.App.Identity.AppUser>().ReverseMap();
            CreateMap<DAL.App.DTO.Identity.AppRole, Domain.App.Identity.AppRole>().ReverseMap();
        }
    }
}