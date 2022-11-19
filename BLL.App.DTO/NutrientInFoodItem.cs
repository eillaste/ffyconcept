using System;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace BLL.App.DTO
{
    public class NutrientInFoodItem: DomainEntityId
    {

        public Guid NutrientId { get; set; }
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.NutrientInFoodItem), Name = nameof(Nutrient))]
        public virtual Nutrient? Nutrient { get; set; }

        public Guid FoodItemId { get; set; }
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.NutrientInFoodItem), Name = nameof(FoodItem))]
        public virtual FoodItem? FoodItem { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(Resources.Base.Common), ErrorMessageResourceName = "ErrorMessageRequired")]
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.NutrientInFoodItem), Name = nameof(Quantity))]
        public double Quantity { get; set; }
    }
}