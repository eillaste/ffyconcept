using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;
using Nutrient = PublicApi.DTO.v1.Nutrient;
using PersonRecommendedDietaryIntake = PublicApi.DTO.v1.PersonRecommendedDietaryIntake;

namespace PublicApi.DTO.v1
{
    public class HealthSpecificationNutrientAddPut: DomainEntityId
    {

        public Guid HealthSpecificationId { get; set; }
        public virtual PublicApi.DTO.v1.HealthSpecification? HealthSpecification { get; set; }

        public Guid NutrientId { get; set; }
        public virtual Nutrient? Nutrient { get; set; }

        public double Quantity { get; set; }

        [MaxLength(128)]
        public string Comment { get; set; } = null!;
        
        public virtual ICollection<PersonRecommendedDietaryIntake>? PersonRecommendedDietaryIntakes { get; set; }
    }
    
    public class HealthSpecificationNutrient: DomainEntityId
    {

        public Guid HealthSpecificationId { get; set; }
        public virtual PublicApi.DTO.v1.HealthSpecification? HealthSpecification { get; set; }

        public Guid NutrientId { get; set; }
        public virtual Nutrient? Nutrient { get; set; }

        public double Quantity { get; set; }

        [MaxLength(128)]
        public string Comment { get; set; } = null!;
        
        public virtual ICollection<PersonRecommendedDietaryIntake>? PersonRecommendedDietaryIntakes { get; set; }
    }
}