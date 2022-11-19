using System;
using Contracts.Domain.Base;
using DAL.App.DTO.Identity;
using Domain.App;
using Domain.Base;

namespace DAL.App.DTO
{
    public class Ingredient: DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {
        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }  = null!;
        public Guid FoodItemId { get; set; }
        public virtual FoodItem? FoodItem { get; set; }

        public Guid RecipeId { get; set; }
        public virtual Recipe? Recipe { get; set; }

        public double Quantity { get; set; }
    }
}