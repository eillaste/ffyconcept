using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.Domain.Base;
using DAL.App.DTO.Identity;
using Domain.App;
using Domain.Base;

namespace DAL.App.DTO
{
    public class Recipe: DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {
        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }  = null!;
        [MaxLength(256)]
        public string Description { get; set; } = null!;
        
        [MaxLength(2048)]
        public string Instructions { get; set; } = null!;

        public int Servings { get; set; }
        public TimeSpan PrepTime { get; set; }
        public bool RestaurantRecipe { get; set; }
        public string Image { get; set; } = null!;

        public virtual ICollection<RecipeTag>? RecipeTags {get; set; }
        public virtual ICollection<DishInMenu>? DishInMenus { get; set; }
        public virtual ICollection<Ingredient>? Ingredients { get; set; }
        public virtual ICollection<PersonFavoriteRecipe>? PersonFavoriteRecipes { get; set; }
        
    }
}