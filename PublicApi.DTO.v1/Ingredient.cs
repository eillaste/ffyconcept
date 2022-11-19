using System;
using BLL.App.DTO.Identity;
using Contracts.Domain.Base;
using Domain.Base;
using Recipe = PublicApi.DTO.v1.Recipe;

namespace PublicApi.DTO.v1
{
    public class IngredientAddPut: DomainEntityId
    {
        //  public Guid Id { get; set; }
        public Guid AppUserId { get; set; }
        //public virtual AppUser? AppUser { get; set; }
        public Guid FoodItemId { get; set; }
        //public virtual PublicApi.DTO.v1.FoodItem? FoodItem { get; set; }

        public Guid RecipeId { get; set; }
        //public virtual Recipe? Recipe { get; set; }

        public double Quantity { get; set; }
    }
    
    public class Ingredient: DomainEntityId
    {
        //  public Guid Id { get; set; }
        public Guid AppUserId { get; set; }
        //public virtual AppUser? AppUser { get; set; }
        public Guid FoodItemId { get; set; }
        //public virtual PublicApi.DTO.v1.FoodItem? FoodItem { get; set; }

        public Guid RecipeId { get; set; }
        //public virtual Recipe? Recipe { get; set; }

        public double Quantity { get; set; }
    }
}