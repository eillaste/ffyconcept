using System;
using Contracts.BLL.App.Services;
using Contracts.BLL.Base;

namespace Contracts.BLL.App
{
    public interface IAppBLL : IBaseBLL
    {
        IAppUserService AppUsers { get; }   
        IAgeGroupService AgeGroups { get; }
        ICategoryService Categories { get; }
        IConsumedFoodItemService ConsumedFoodItems { get; }
        IConsumedNutrientService ConsumedNutrients { get; }
        IDietaryRestrictionService DietaryRestrictions { get; }
        IDietService Diets { get; }
        IDishInMenuService DishInMenu { get; }
        IDishInOrderService DishInOrder { get; }
        IFoodItemService FoodItems { get; }
        IHealthSpecificationNutrientService HealthSpecificationNutrients { get; }
        IHealthSpecificationService HealthSpecifications { get; }
        IIngredientService Ingredients { get; }
        IInvoiceService Invoices { get; }
        IMenuService Menus { get; }
        INutrientInFoodItemService NutrientInFoodItem { get; }
        INutrientInSupplementService NutrientInSupplement { get; }
        INutrientService Nutrients { get; }
        IOrderService Orders { get; }
        IPersonAllergenService PersonAllergens { get; }
        IPersonDietService PersonDiets { get; }
        IPersonFavoriteRecipeService PersonFavoriteRecipes { get; }
        IPersonHealthSpecificationService PersonHealthSpecifications { get; }
        IPersonRecommendedDietaryIntakeService PersonRecommendedDietaryIntake { get; }

        IPersonSupplementService PersonSupplements { get; }
        IRecipeService Recipes { get; }
        IRecipeTagService RecipeTags { get; }
        IRecommendedDietaryIntakeService RecommendedDietaryIntake { get; }
        IRestaurantService Restaurants { get; }
        IStandardUnitService StandardUnits { get; }
        IStateService State { get; }
        IStockService Stock { get; }
        ISupplementService Supplements { get; }
        ITagService Tags { get; }
        ITolerableUpperIntakeLevelService TolerableUpperIntakeLevels { get; }
    }
}