using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace Domain.App
{
    public class Nutrient: DomainEntityId
    {
 
        public Guid StandardUnitId { get; set; }
        public virtual StandardUnit? StandardUnit { get; set; }
        
        [MaxLength(128)]
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