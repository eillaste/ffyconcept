using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BLL.App.DTO.Identity;
using Contracts.Domain.Base;
using Domain.Base;
using RecipeTag = PublicApi.DTO.v1.RecipeTag;

namespace PublicApi.DTO.v1
{
    
    public class RecipeAddPut: DomainEntityId
    {
        // public Guid Id { get; set; }
        public Guid AppUserId { get; set; }
        //public virtual AppUser? AppUser { get; set; }
        [MaxLength(256)]
        public string Description { get; set; } = null!;
        
        [MaxLength(2048)]
        public string Instructions { get; set; } = null!;

        public int Servings { get; set; }
        public TimeSpan PrepTime { get; set; }
        public bool RestaurantRecipe { get; set; }
        public string Image { get; set; } = null!;

        /*
        public virtual ICollection<RecipeTag>? RecipeTags {get; set; }
        public virtual ICollection<PublicApi.DTO.v1.DishInMenu>? DishInMenus { get; set; }
        public virtual ICollection<PublicApi.DTO.v1.Ingredient>? Ingredients { get; set; }
        public virtual ICollection<PublicApi.DTO.v1.PersonFavoriteRecipe>? PersonFavoriteRecipes { get; set; }
        */
        
    }
    public class Recipe: DomainEntityId
    {
        // public Guid Id { get; set; }
        public Guid AppUserId { get; set; }
        //public virtual AppUser? AppUser { get; set; }
        [MaxLength(256)]
        public string Description { get; set; } = null!;
        
        [MaxLength(2048)]
        public string Instructions { get; set; } = null!;

        public int Servings { get; set; }
        public TimeSpan PrepTime { get; set; }
        public bool RestaurantRecipe { get; set; }
        public string Image { get; set; } = null!;

        /*
        public virtual ICollection<RecipeTag>? RecipeTags {get; set; }
        public virtual ICollection<PublicApi.DTO.v1.DishInMenu>? DishInMenus { get; set; }
        public virtual ICollection<PublicApi.DTO.v1.Ingredient>? Ingredients { get; set; }
        public virtual ICollection<PublicApi.DTO.v1.PersonFavoriteRecipe>? PersonFavoriteRecipes { get; set; }
        */
        
    }
}