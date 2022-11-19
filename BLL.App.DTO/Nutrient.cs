using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.App.DTO;
using Domain.Base;

namespace BLL.App.DTO
{
    public class Nutrient: DomainEntityId
    {
 
        public Guid StandardUnitId { get; set; }
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.Nutrient), Name = nameof(StandardUnit))]
        public virtual StandardUnit? StandardUnit { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(Resources.Base.Common), ErrorMessageResourceName = "ErrorMessageRequired")]
        [MaxLength(128)]
        [Display(ResourceType = typeof(Resources.BLL.App.DTO.Nutrient), Name = nameof(Title))]
        public string? Title { get; set; }

        public virtual ICollection<NutrientInFoodItem>? NutrientInFoodItems { get; set; }
        public virtual ICollection<TolerableUpperIntakeLevel>? TolerableUpperIntakeLevels { get; set; }
        public virtual ICollection<RecommendedDietaryIntake>? RecommendedDietaryIntakes { get; set; }
        public virtual ICollection<HealthSpecificationNutrient>? HealthSpecificationNutrients { get; set; }
        public virtual ICollection<PersonRecommendedDietaryIntake>? PersonRecommendedDietaryIntakes { get; set; }
        public virtual ICollection<ConsumedNutrient>? ConsumedNutrients { get; set; }
        public virtual ICollection<NutrientInSupplement>? NutrientInSupplements { get; set; }
        
    }
}