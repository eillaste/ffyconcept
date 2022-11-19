using AutoMapper;

namespace PublicApi.DTO.v1.MappingProfiles
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            
            CreateMap<BLL.App.DTO.AgeGroup, PublicApi.DTO.v1.AgeGroupAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.AgeGroup, PublicApi.DTO.v1.AgeGroup>().ReverseMap();
            
            CreateMap<BLL.App.DTO.ConsumedFoodItem, PublicApi.DTO.v1.ConsumedFoodItemAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.ConsumedFoodItem, PublicApi.DTO.v1.ConsumedFoodItem>().ReverseMap();
            
            CreateMap<BLL.App.DTO.Category, PublicApi.DTO.v1.CategoryAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.Category, PublicApi.DTO.v1.Category>().ReverseMap();
            
            CreateMap<BLL.App.DTO.ConsumedNutrient, PublicApi.DTO.v1.ConsumedNutrientAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.ConsumedNutrient, PublicApi.DTO.v1.ConsumedNutrient>().ReverseMap();
            
            CreateMap<BLL.App.DTO.Diet, PublicApi.DTO.v1.DietAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.Diet, PublicApi.DTO.v1.Diet>().ReverseMap();
            
            CreateMap<BLL.App.DTO.DietaryRestriction, PublicApi.DTO.v1.DietaryRestrictionAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.DietaryRestriction, PublicApi.DTO.v1.DietaryRestriction>().ReverseMap();
            
            CreateMap<BLL.App.DTO.DishInMenu, PublicApi.DTO.v1.DishInMenuAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.DishInMenu, PublicApi.DTO.v1.DishInMenu>().ReverseMap();
            
            CreateMap<BLL.App.DTO.DishInOrder, PublicApi.DTO.v1.DishInOrderAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.DishInOrder, PublicApi.DTO.v1.DishInOrder>().ReverseMap();
            
            CreateMap<BLL.App.DTO.FoodItem, PublicApi.DTO.v1.FoodItemAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.FoodItem, PublicApi.DTO.v1.FoodItem>().ReverseMap();
            
            CreateMap<BLL.App.DTO.HealthSpecification, PublicApi.DTO.v1.HealthSpecificationAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.HealthSpecification, PublicApi.DTO.v1.HealthSpecification>().ReverseMap();
            
            CreateMap<BLL.App.DTO.HealthSpecificationNutrient, PublicApi.DTO.v1.HealthSpecificationNutrientAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.HealthSpecificationNutrient, PublicApi.DTO.v1.HealthSpecificationNutrient>().ReverseMap();
            
            CreateMap<BLL.App.DTO.Ingredient, PublicApi.DTO.v1.IngredientAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.Ingredient, PublicApi.DTO.v1.Ingredient>().ReverseMap();
            
            CreateMap<BLL.App.DTO.Invoice, PublicApi.DTO.v1.InvoiceAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.Invoice, PublicApi.DTO.v1.Invoice>().ReverseMap();
            
            CreateMap<BLL.App.DTO.Menu, PublicApi.DTO.v1.MenuAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.Menu, PublicApi.DTO.v1.Menu>().ReverseMap();
            
            CreateMap<BLL.App.DTO.Nutrient, PublicApi.DTO.v1.NutrientAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.Nutrient, PublicApi.DTO.v1.Nutrient>().ReverseMap();
            
            CreateMap<BLL.App.DTO.NutrientInFoodItem, PublicApi.DTO.v1.NutrientInFoodItemAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.NutrientInFoodItem, PublicApi.DTO.v1.NutrientInFoodItem>().ReverseMap();
            
            CreateMap<BLL.App.DTO.NutrientInSupplement, PublicApi.DTO.v1.NutrientInSupplementAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.NutrientInSupplement, PublicApi.DTO.v1.NutrientInSupplement>().ReverseMap();
            
            CreateMap<BLL.App.DTO.Order, PublicApi.DTO.v1.OrderAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.Order, PublicApi.DTO.v1.Order>().ReverseMap();
            
            CreateMap<BLL.App.DTO.PersonAllergen, PublicApi.DTO.v1.PersonAllergenAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.PersonAllergen, PublicApi.DTO.v1.PersonAllergen>().ReverseMap();
            
            CreateMap<BLL.App.DTO.PersonDiet, PublicApi.DTO.v1.PersonDietAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.PersonDiet, PublicApi.DTO.v1.PersonDiet>().ReverseMap();
            
            CreateMap<BLL.App.DTO.PersonFavoriteRecipe, PublicApi.DTO.v1.PersonFavoriteRecipeAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.PersonFavoriteRecipe, PublicApi.DTO.v1.PersonFavoriteRecipe>().ReverseMap();
            
            CreateMap<BLL.App.DTO.PersonHealthSpecification, PublicApi.DTO.v1.PersonHealthSpecificationAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.PersonHealthSpecification, PublicApi.DTO.v1.PersonHealthSpecification>().ReverseMap();
            
            CreateMap<BLL.App.DTO.PersonRecommendedDietaryIntake, PublicApi.DTO.v1.PersonRecommendedDietaryIntakeAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.PersonRecommendedDietaryIntake, PublicApi.DTO.v1.PersonRecommendedDietaryIntake>().ReverseMap();
            
            CreateMap<BLL.App.DTO.PersonSupplement, PublicApi.DTO.v1.PersonSupplementAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.PersonSupplement, PublicApi.DTO.v1.PersonSupplement>().ReverseMap();
            
            CreateMap<BLL.App.DTO.Recipe, PublicApi.DTO.v1.RecipeAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.Recipe, PublicApi.DTO.v1.Recipe>().ReverseMap();
            
            CreateMap<BLL.App.DTO.RecipeTag, PublicApi.DTO.v1.RecipeTagAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.RecipeTag, PublicApi.DTO.v1.RecipeTag>().ReverseMap();
            
            CreateMap<BLL.App.DTO.RecommendedDietaryIntake, PublicApi.DTO.v1.RecommendedDietaryIntakeAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.RecommendedDietaryIntake, PublicApi.DTO.v1.RecommendedDietaryIntake>().ReverseMap();
            
            CreateMap<BLL.App.DTO.Restaurant, PublicApi.DTO.v1.RestaurantAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.Restaurant, PublicApi.DTO.v1.Restaurant>().ReverseMap();
            
            CreateMap<BLL.App.DTO.StandardUnit, PublicApi.DTO.v1.StandardUnitAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.StandardUnit, PublicApi.DTO.v1.StandardUnit>().ReverseMap();
            
            CreateMap<BLL.App.DTO.State, PublicApi.DTO.v1.StateAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.State, PublicApi.DTO.v1.State>().ReverseMap();
            
            CreateMap<BLL.App.DTO.Stock, PublicApi.DTO.v1.StockAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.Stock, PublicApi.DTO.v1.Stock>().ReverseMap();
            
            CreateMap<BLL.App.DTO.Supplement, PublicApi.DTO.v1.SupplementAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.Supplement, PublicApi.DTO.v1.Supplement>().ReverseMap();
            
            CreateMap<BLL.App.DTO.Tag, PublicApi.DTO.v1.TagAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.Tag, PublicApi.DTO.v1.Tag>().ReverseMap();
            
            CreateMap<BLL.App.DTO.TolerableUpperIntakeLevel, PublicApi.DTO.v1.TolerableUpperIntakeLevelAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.TolerableUpperIntakeLevel, PublicApi.DTO.v1.TolerableUpperIntakeLevel>().ReverseMap();
            
            /*
            CreateMap<BLL.App.DTO.GenericEntity, PublicApi.DTO.v1.GenericEntityAddPut>().ReverseMap();
            CreateMap<BLL.App.DTO.GenericEntity, PublicApi.DTO.v1.GenericEntity>().ReverseMap();*/
        }

    }
}