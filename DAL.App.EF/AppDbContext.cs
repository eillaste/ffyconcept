using System;
using System.Linq;
using Domain.App;
using Domain.App.Identity;
using Domain.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//
namespace DAL.App.EF
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public DbSet<AgeGroup> AgeGroups { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        //public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<ConsumedFoodItem> ConsumedFoodItems { get; set; } = null!;
        public DbSet<ConsumedNutrient> ConsumedNutrients { get; set; } = null!;
        public DbSet<Diet> Diets { get; set; } = null!;
        public DbSet<DietaryRestriction> DietaryRestrictions { get; set; } = null!;
        public DbSet<DishInMenu> DishInMenu { get; set; } = null!;
        public DbSet<DishInOrder> DishInOrder { get; set; } = null!;
        public DbSet<FoodItem> FoodItems { get; set; } = null!;
        public DbSet<HealthSpecification> HealthSpecifications { get; set; } = null!;
        public DbSet<HealthSpecificationNutrient> HealthSpecificationNutrients { get; set; } = null!;
        public DbSet<Ingredient> Ingredients { get; set; } = null!;
        public DbSet<Invoice> Invoices { get; set; } = null!;
        public DbSet<Menu> Menus { get; set; } = null!;
        public DbSet<Nutrient> Nutrients { get; set; } = null!;
        public DbSet<NutrientInFoodItem> NutrientInFoodItem { get; set; } = null!;
        public DbSet<NutrientInSupplement> NutrientInSupplement { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<PersonAllergen> PersonAllergens { get; set; } = null!;
        public DbSet<PersonDiet> PersonDiets { get; set; } = null!;
        public DbSet<PersonFavoriteRecipe> PersonFavoriteRecipes { get; set; } = null!;
        public DbSet<PersonHealthSpecification> PersonHealthSpecifications { get; set; } = null!;
        public DbSet<PersonRecommendedDietaryIntake> PersonRecommendedDietaryIntake { get; set; } = null!;
        public DbSet<PersonSupplement> PersonSupplements { get; set; } = null!;
        public DbSet<Recipe> Recipes { get; set; } = null!;
        public DbSet<RecipeTag> RecipeTags { get; set; } = null!;
        public DbSet<RecommendedDietaryIntake> RecommendedDietaryIntake { get; set; } = null!;
        public DbSet<Restaurant> Restaurants { get; set; } = null!;
        public DbSet<StandardUnit> StandardUnits { get; set; } = null!;
        public DbSet<State> States { get; set; } = null!;
        public DbSet<Stock> Stock { get; set; } = null!;
        public DbSet<Supplement> Supplements { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
        public DbSet<TolerableUpperIntakeLevel> TolerableUpperIntakeLevel { get; set; } = null!;
        public DbSet<AppUser> AppUsers { get; set; } = null!;
        // added this crap
        public DbSet<LangString> LangSrings { get; set; } = default!;
        public DbSet<Translation> Translations { get; set; } = default!;
        //
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            //string ADMIN_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
            string ROLE_ID_ADMIN = Guid.NewGuid().ToString();
            string ROLE_ID_CUSTOMER = Guid.NewGuid().ToString();
            string ROLE_ID_COMPANY = Guid. NewGuid().ToString();
            
            base.OnModelCreating(builder);
            
            builder.Entity<AppRole>().HasData(new AppRole { 
                Name = "admin", 
                NormalizedName = "ADMIN", 
                Id = Guid.Parse(ROLE_ID_ADMIN),
                ConcurrencyStamp = ROLE_ID_ADMIN
            });
            
            builder.Entity<AppRole>().HasData(new AppRole { 
                Name = "customer", 
                NormalizedName = "CUSTOMER", 
                Id = Guid.Parse(ROLE_ID_CUSTOMER),
                ConcurrencyStamp = ROLE_ID_CUSTOMER
            });
            builder.Entity<AppRole>().HasData(new AppRole { 
                Name = "company", 
                NormalizedName = "company", 
                Id = Guid.Parse(ROLE_ID_COMPANY),
                ConcurrencyStamp = ROLE_ID_COMPANY
            });
            
            // disable cascade delete initially for everything
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

        }
    }
}