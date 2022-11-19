using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.Domain.Base;
using DAL.App.DTO;
using Domain.App;
using Microsoft.AspNetCore.Identity;

namespace BLL.App.DTO.Identity
{
    public class AppUser: IdentityUser<Guid>, IDomainEntityId
    {
//        [StringLength(127, MinimumLength = 1)]
//        public string Firstname { get; set; } = default!;
//        [StringLength(127, MinimumLength = 1)]
//        public string Lastname { get; set; } = default!;
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.AppUser), Name = "Born") ]
        public DateTime Born { get; set; }
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.AppUser), Name = "Gender") ]
        public EGender Gender { get; set; }
        public EAccountType AccountType { get; set; } = default!;
        
        public Guid AppRoleId { get; set; }
        //public virtual AppRole? AppRole { get; set; }

        //CLIENT
        public virtual ICollection<PersonDiet>? PersonDiets { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<DishInOrder>? DishInOrders { get; set; }
        public virtual ICollection<PersonAllergen>? PersonAllergens { get; set; }
        public virtual ICollection<ConsumedFoodItem>? ConsumedFoodItems { get; set; }
        public virtual ICollection<PersonSupplement>? PersonSupplements { get; set; }
        public virtual ICollection<ConsumedNutrient>? ConsumedNutrients { get; set; }
        public virtual ICollection<PersonRecommendedDietaryIntake>? PersonRecommendedDietaryIntakes  { get; set; } //system
        public virtual ICollection<PersonHealthSpecification>? PersonHealthSpecifications { get; set; }
        public virtual ICollection<Stock>? Stocks { get; set; }
        public virtual ICollection<PersonFavoriteRecipe>? PersonFavoriteRecipes { get; set; }
        public virtual ICollection<Tag>? Tags { get; set; }
        
        //COMPANY
        [MaxLength(128)] 
        public string? CompanyName { get; set; }
        public virtual ICollection<Restaurant>? Restaurants { get; set; }
        public virtual ICollection<DishInMenu>? DishInMenus { get; set; }
        public virtual ICollection<Ingredient>? Ingredients { get; set; }
        public virtual ICollection<Menu>? Menus { get; set; }
        public virtual ICollection<Recipe>? Recipes { get; set; }
        public virtual ICollection<RecipeTag>? RecipeTags { get; set; }
    }
}