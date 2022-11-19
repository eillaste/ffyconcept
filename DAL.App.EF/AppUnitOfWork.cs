using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base.Repositories;
using DAL.App.EF.Repositories;
using DAL.Base.EF;
using DAL.Base.EF.Repositories;
using Domain.App;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DAL.App.EF
{
    public class AppUnitOfWork: BaseUnitOfWork<AppDbContext>, IAppUnitOfWork
    {
        protected IMapper Mapper;
        public AppUnitOfWork(AppDbContext uowDbContext, IMapper mapper) : base(uowDbContext)
        {
            Mapper = mapper;
            // accessing users UowDbContext.AppUsers.First()...
        }

        //public IPersonRepository Persons => GetRepository(() => new PersonRepository(UowDbContext));

        //public IAgeGroupRepository AgeGroups => new AgeGroupRepository(UowDbContext);
        public IAppUserRepository AppUsers => 
            GetRepository(() => new AppUserRepository(UowDbContext, Mapper));
        public IAgeGroupRepository AgeGroups => 
            GetRepository(() => new AgeGroupRepository(UowDbContext, Mapper));
        public ICategoryRepository Categories => 
            GetRepository(() => new CategoryRepository(UowDbContext, Mapper));
        
        public IConsumedFoodItemRepository ConsumedFoodItems => 
            GetRepository(() => new ConsumedFoodItemRepository(UowDbContext, Mapper));
        public IConsumedNutrientRepository ConsumedNutrients => 
            GetRepository(() => new ConsumedNutrientRepository(UowDbContext, Mapper));
        public IDietaryRestrictionRepository DietaryRestrictions => 
            GetRepository(() => new DietaryRestrictionRepository(UowDbContext, Mapper));
        public IDietRepository Diets => 
            GetRepository(() => new DietRepository(UowDbContext, Mapper));
        public IDishInMenuRepository DishInMenu => 
            GetRepository(() => new DishInMenuRepository(UowDbContext, Mapper));
        public IDishInOrderRepository DishInOrder => 
            GetRepository(() => new DishInOrderRepository(UowDbContext, Mapper));
        // Changed this and include now works:
        /*public IBaseRepository<FoodItem> FoodItems => new FoodItemRepository(UowDbContext);*/
        public IFoodItemRepository FoodItems =>
            GetRepository(() => new FoodItemRepository(UowDbContext, Mapper));
        public IHealthSpecificationNutrientRepository HealthSpecificationNutrients => 
            GetRepository(()=> new HealthSpecificationNutrientRepository(UowDbContext, Mapper));
        
        public IHealthSpecificationRepository HealthSpecifications => 
            GetRepository(()=>new HealthSpecificationRepository(UowDbContext, Mapper));
        public IIngredientRepository Ingredients => 
            GetRepository(() => new IngredientRepository(UowDbContext, Mapper));
        public IInvoiceRepository Invoices => 
            GetRepository(() => new InvoiceRepository(UowDbContext, Mapper));
        public IMenuRepository Menus => 
            GetRepository(() => new MenuRepository(UowDbContext, Mapper));
        public INutrientInFoodItemRepository NutrientInFoodItem => 
            GetRepository(() => new NutrientInFoodItemRepository(UowDbContext, Mapper));
        public INutrientInSupplementRepository NutrientInSupplement => 
            GetRepository(() => new NutrientInSupplementRepository(UowDbContext, Mapper));
        public INutrientRepository Nutrients => 
            GetRepository(() => new NutrientRepository(UowDbContext, Mapper));
        public IOrderRepository Orders => 
            GetRepository(() => new OrderRepository(UowDbContext, Mapper));
        public IPersonAllergenRepository PersonAllergens => 
            GetRepository(() => new PersonAllergenRepository(UowDbContext, Mapper));
        public IPersonDietRepository PersonDiets => 
            GetRepository(() => new PersonDietRepository(UowDbContext, Mapper));
        public IPersonFavoriteRecipeRepository PersonFavoriteRecipes => 
            GetRepository(() => new PersonFavoriteRecipeRepository(UowDbContext, Mapper));
        public IPersonHealthSpecificationRepository PersonHealthSpecifications => 
            GetRepository(() => new PersonHealthSpecificationRepository(UowDbContext, Mapper));
        public IPersonRecommendedDietaryIntakeRepository PersonRecommendedDietaryIntake => 
            GetRepository(() => new PersonRecommendedDietaryIntakeRepository(UowDbContext, Mapper));
        public IPersonSupplementRepository PersonSupplements => 
            GetRepository(() => new PersonSupplementRepository(UowDbContext, Mapper));
        public IRecipeRepository Recipes => 
            GetRepository(() => new RecipeRepository(UowDbContext, Mapper));
        public IRecipeTagRepository RecipeTags => 
            GetRepository(() => new RecipeTagRepository(UowDbContext, Mapper));
        public IRecommendedDietaryIntakeRepository RecommendedDietaryIntake => 
            GetRepository(() => new RecommendedDietaryIntakeRepository(UowDbContext, Mapper));
        public IRestaurantRepository Restaurants => 
            GetRepository(() => new RestaurantRepository(UowDbContext, Mapper));
        public IStandardUnitRepository StandardUnits => 
            GetRepository(() => new StandardUnitRepository(UowDbContext, Mapper));
        public IStateRepository State => 
            GetRepository(() => new StateRepository(UowDbContext, Mapper));
        public IStockRepository Stock => 
            GetRepository(() => new StockRepository(UowDbContext, Mapper));
        public ISupplementRepository Supplements => 
            GetRepository(() => new SupplementRepository(UowDbContext, Mapper));
        public ITagRepository Tags => 
            GetRepository(() => new TagRepository(UowDbContext, Mapper));
        public ITolerableUpperIntakeLevelRepository TolerableUpperIntakeLevels =>
            GetRepository(() => new TolerableUpperIntakeLevelRepository(UowDbContext, Mapper));

    }
}