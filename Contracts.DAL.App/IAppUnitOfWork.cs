using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using Domain.App;

namespace Contracts.DAL.App
{
    public interface IAppUnitOfWork: IBaseUnitOfWork
    {
        
        //IPersonRepository Persons { get; }
        //we dont have any custom methods yet
        IAppUserRepository AppUsers { get; }
        IAgeGroupRepository AgeGroups { get; }
        ICategoryRepository Categories { get; }
        //IBaseRepository<Company> Companies { get; }
        IConsumedFoodItemRepository ConsumedFoodItems { get; }
        IConsumedNutrientRepository ConsumedNutrients { get; }
        IDietaryRestrictionRepository DietaryRestrictions { get; }
        IDietRepository Diets { get; }
        IDishInMenuRepository DishInMenu { get; }
        IDishInOrderRepository DishInOrder { get; }
        IFoodItemRepository FoodItems { get; }
        IHealthSpecificationNutrientRepository HealthSpecificationNutrients { get; }
        IHealthSpecificationRepository HealthSpecifications { get; }
        IIngredientRepository Ingredients { get; }
        IInvoiceRepository Invoices { get; }
        IMenuRepository Menus { get; }
        INutrientInFoodItemRepository NutrientInFoodItem { get; }
        INutrientInSupplementRepository NutrientInSupplement { get; }
        INutrientRepository Nutrients { get; }
        IOrderRepository Orders { get; }
        IPersonAllergenRepository PersonAllergens { get; }
        IPersonDietRepository PersonDiets { get; }
        IPersonFavoriteRecipeRepository PersonFavoriteRecipes { get; }
        IPersonHealthSpecificationRepository PersonHealthSpecifications { get; }
        IPersonRecommendedDietaryIntakeRepository PersonRecommendedDietaryIntake { get; }

        IPersonSupplementRepository PersonSupplements { get; }
        IRecipeRepository Recipes { get; }
        IRecipeTagRepository RecipeTags { get; }
        IRecommendedDietaryIntakeRepository RecommendedDietaryIntake { get; }
        IRestaurantRepository Restaurants { get; }
        IStandardUnitRepository StandardUnits { get; }
        IStateRepository State { get; }
        IStockRepository Stock { get; }
        ISupplementRepository Supplements { get; }
        ITagRepository Tags { get; }
        ITolerableUpperIntakeLevelRepository TolerableUpperIntakeLevels { get; }
    }
}