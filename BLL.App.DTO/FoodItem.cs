using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.App.DTO;
using Domain.Base;

namespace BLL.App.DTO
{
    public class FoodItem: DomainEntityId
    {

        [Required(ErrorMessageResourceType = typeof(Resources.Base.Common), ErrorMessageResourceName = "ErrorMessageRequired")]
        [MaxLength(128)]
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.FoodItem), Name = nameof(Title))]
        public string? Title { get; set; }

        public Guid StandardUnitId { get; set; }
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.FoodItem), Name = nameof(StandardUnit))]
        public virtual StandardUnit? StandardUnit { get; set; }

        public Guid CategoryId { get; set; }
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.FoodItem), Name = nameof(Category))]
        public virtual Category? Category { get; set; }

        public virtual ICollection<PersonAllergen>? PersonAllergens { get; set; }
        public virtual ICollection<Ingredient>? Ingredients { get; set; }
        public virtual ICollection<Stock>? Stocks { get; set; }
        public virtual ICollection<DietaryRestriction>? DietaryRestrictions { get; set; }
        public virtual ICollection<NutrientInFoodItem>? NutrientInFoodItems { get; set; }
        public virtual ICollection<ConsumedFoodItem>? ConsumedFoodItems { get; set; }


    }
}