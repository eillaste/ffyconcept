using System;
using AutoMapper;
using BLL.App.Services;
using BLL.Base;
using Contracts.BLL.App;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;

namespace BLL.App
{
    public class AppBLL : BaseBLL<IAppUnitOfWork>, IAppBLL
    {
        protected IMapper Mapper;
        public AppBLL(IAppUnitOfWork uow, IMapper mapper) : base(uow)
        {
            Mapper = mapper;
        }

        // stats come from stateservice!
        public IStateService Stats => 
            GetService<IStateService>(() => new StateService(Uow, Uow.State, Mapper));
        
        public IAppUserService AppUsers => 
            GetService<IAppUserService>(() => new AppUserService(Uow, Uow.AppUsers, Mapper));

        public IAgeGroupService AgeGroups => 
            GetService<IAgeGroupService>(() => new AgeGroupService(Uow, Uow.AgeGroups, Mapper));
        public ICategoryService Categories => 
            GetService<ICategoryService>(() => new CategoryService(Uow, Uow.Categories, Mapper));
        public IConsumedFoodItemService ConsumedFoodItems => 
            GetService<IConsumedFoodItemService>(() => new ConsumedFoodItemService(Uow, Uow.ConsumedFoodItems, Mapper));
        public IConsumedNutrientService ConsumedNutrients => 
            GetService<IConsumedNutrientService>(() => new ConsumedNutrientService(Uow, Uow.ConsumedNutrients, Mapper));
        public IDietaryRestrictionService DietaryRestrictions => 
            GetService<IDietaryRestrictionService>(() => new DietaryRestrictionService(Uow, Uow.DietaryRestrictions, Mapper));
        public IDietService Diets => 
            GetService<IDietService>(() => new DietService(Uow, Uow.Diets, Mapper));
        public IDishInMenuService DishInMenu => 
            GetService<IDishInMenuService>(() => new DishInMenuService(Uow, Uow.DishInMenu, Mapper));
        public IDishInOrderService DishInOrder => 
            GetService<IDishInOrderService>(() => new DishInOrderService(Uow, Uow.DishInOrder, Mapper));
        public IFoodItemService FoodItems =>
            GetService<IFoodItemService>(() => new FoodItemService(Uow, Uow.FoodItems, Mapper));
        public IHealthSpecificationNutrientService HealthSpecificationNutrients => 
            GetService<IHealthSpecificationNutrientService>(()=> new HealthSpecificationNutrientService(Uow, Uow.HealthSpecificationNutrients, Mapper));
        public IHealthSpecificationService HealthSpecifications => 
            GetService<IHealthSpecificationService>(()=>new HealthSpecificationService(Uow, Uow.HealthSpecifications, Mapper));
        public IIngredientService Ingredients => 
            GetService<IIngredientService>(() => new IngredientService(Uow, Uow.Ingredients, Mapper));
        public IInvoiceService Invoices => 
            GetService<IInvoiceService>(() => new InvoiceService(Uow, Uow.Invoices, Mapper));
        public IMenuService Menus => 
            GetService<IMenuService>(() => new MenuService(Uow, Uow.Menus, Mapper));
        public INutrientInFoodItemService NutrientInFoodItem => 
            GetService<INutrientInFoodItemService>(() => new NutrientInFoodItemService(Uow, Uow.NutrientInFoodItem, Mapper));
        public INutrientInSupplementService NutrientInSupplement => 
            GetService<INutrientInSupplementService>(() => new NutrientInSupplementService(Uow, Uow.NutrientInSupplement, Mapper));
        public INutrientService Nutrients => 
            GetService<INutrientService>(() => new NutrientService(Uow, Uow.Nutrients, Mapper));
        public IOrderService Orders => 
            GetService<IOrderService>(() => new OrderService(Uow, Uow.Orders, Mapper));
        public IPersonAllergenService PersonAllergens => 
            GetService<IPersonAllergenService>(() => new PersonAllergenService(Uow, Uow.PersonAllergens, Mapper));
        public IPersonDietService PersonDiets => 
            GetService<IPersonDietService>(() => new PersonDietService(Uow, Uow.PersonDiets, Mapper));
        public IPersonFavoriteRecipeService PersonFavoriteRecipes => 
            GetService<IPersonFavoriteRecipeService>(() => new PersonFavoriteRecipeService(Uow, Uow.PersonFavoriteRecipes, Mapper));
        public IPersonHealthSpecificationService PersonHealthSpecifications => 
            GetService<IPersonHealthSpecificationService>(() => new PersonHealthSpecificationService(Uow, Uow.PersonHealthSpecifications, Mapper));
        public IPersonRecommendedDietaryIntakeService PersonRecommendedDietaryIntake => 
            GetService<IPersonRecommendedDietaryIntakeService>(() => new PersonRecommendedDietaryIntakeService(Uow, Uow.PersonRecommendedDietaryIntake, Mapper));
        public IPersonSupplementService PersonSupplements => 
            GetService<IPersonSupplementService>(() => new PersonSupplementService(Uow, Uow.PersonSupplements, Mapper));
        public IRecipeService Recipes => 
            GetService<IRecipeService>(() => new RecipeService(Uow, Uow.Recipes, Mapper));
        public IRecipeTagService RecipeTags => 
            GetService<IRecipeTagService>(() => new RecipeTagService(Uow, Uow.RecipeTags, Mapper));
        public IRecommendedDietaryIntakeService RecommendedDietaryIntake => 
            GetService<IRecommendedDietaryIntakeService>(() => new RecommendedDietaryIntakeService(Uow, Uow.RecommendedDietaryIntake, Mapper));
        public IRestaurantService Restaurants => 
            GetService<IRestaurantService>(() => new RestaurantService(Uow, Uow.Restaurants, Mapper));
        public IStandardUnitService StandardUnits => 
            GetService<IStandardUnitService>(() => new StandardUnitService(Uow, Uow.StandardUnits, Mapper));
        public IStateService State => 
            GetService<IStateService>(() => new StateService(Uow, Uow.State, Mapper));
        public IStockService Stock => 
            GetService<IStockService>(() => new StockService(Uow, Uow.Stock, Mapper));
        public ISupplementService Supplements => 
            GetService<ISupplementService>(() => new SupplementService(Uow, Uow.Supplements, Mapper));
        public ITagService Tags => 
            GetService<ITagService>(() => new TagService(Uow, Uow.Tags, Mapper));
        public ITolerableUpperIntakeLevelService TolerableUpperIntakeLevels =>
            GetService<ITolerableUpperIntakeLevelService>(() => new TolerableUpperIntakeLevelService(Uow, Uow.TolerableUpperIntakeLevels, Mapper));

    }
}