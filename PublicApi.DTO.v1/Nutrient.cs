using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;
using NutrientInFoodItem = PublicApi.DTO.v1.NutrientInFoodItem;
using NutrientInSupplement = PublicApi.DTO.v1.NutrientInSupplement;
using PersonRecommendedDietaryIntake = PublicApi.DTO.v1.PersonRecommendedDietaryIntake;
using RecommendedDietaryIntake = PublicApi.DTO.v1.RecommendedDietaryIntake;
using StandardUnit = PublicApi.DTO.v1.StandardUnit;
using TolerableUpperIntakeLevel = PublicApi.DTO.v1.TolerableUpperIntakeLevel;

namespace PublicApi.DTO.v1
{
    public class NutrientAddPut: DomainEntityId
    {
        // public Guid Id { get; set; }
        public Guid StandardUnitId { get; set; }
        /*
        public virtual StandardUnit? StandardUnit { get; set; }
        */
        
        [MaxLength(128)]
        public string? Title { get; set; }

        /*
        public virtual ICollection<NutrientInFoodItem>? NutrientInFoodItems { get; set; }
        public virtual ICollection<TolerableUpperIntakeLevel>? TolerableUpperIntakeLevels { get; set; }
        public virtual ICollection<RecommendedDietaryIntake>? RecommendedDietaryIntakes { get; set; }
        public virtual ICollection<PublicApi.DTO.v1.HealthSpecificationNutrient>? HealthSpecificationNutrients { get; set; }
        public virtual ICollection<PersonRecommendedDietaryIntake>? PersonRecommendedDietaryIntakes { get; set; }
        public virtual ICollection<PublicApi.DTO.v1.ConsumedNutrient>? ConsumedNutrients { get; set; }
        public virtual ICollection<NutrientInSupplement>? NutrientInSupplements { get; set; }
        */
        
    }
    
    public class Nutrient: DomainEntityId
    {
        // public Guid Id { get; set; }
        public Guid StandardUnitId { get; set; }
        //public virtual StandardUnit? StandardUnit { get; set; }
        
        [MaxLength(128)]
        public string? Title { get; set; }

        /*
        public virtual ICollection<NutrientInFoodItem>? NutrientInFoodItems { get; set; }
        public virtual ICollection<TolerableUpperIntakeLevel>? TolerableUpperIntakeLevels { get; set; }
        public virtual ICollection<RecommendedDietaryIntake>? RecommendedDietaryIntakes { get; set; }
        public virtual ICollection<PublicApi.DTO.v1.HealthSpecificationNutrient>? HealthSpecificationNutrients { get; set; }
        public virtual ICollection<PersonRecommendedDietaryIntake>? PersonRecommendedDietaryIntakes { get; set; }
        public virtual ICollection<PublicApi.DTO.v1.ConsumedNutrient>? ConsumedNutrients { get; set; }
        public virtual ICollection<NutrientInSupplement>? NutrientInSupplements { get; set; }
        */
        
    }
}