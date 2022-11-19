using System;
using System.ComponentModel.DataAnnotations;
using BLL.App.DTO.Identity;
using Contracts.Domain.Base;
using DAL.App.DTO;
using Domain.Base;

namespace BLL.App.DTO
{
    public class Ingredient: DomainEntityId, IDomainAppUserId, IDomainAppUser<AppUser>
    {
        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }  = null!;
        public Guid FoodItemId { get; set; }
        
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.Ingredient), Name = nameof(FoodItem))]
        public virtual FoodItem? FoodItem { get; set; }

        public Guid RecipeId { get; set; }
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.Ingredient), Name = nameof(Recipe))]
        public virtual Recipe? Recipe { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(Resources.Base.Common), ErrorMessageResourceName = "ErrorMessageRequired")]
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.Ingredient), Name = nameof(Quantity))]
        public double Quantity { get; set; }
    }
}